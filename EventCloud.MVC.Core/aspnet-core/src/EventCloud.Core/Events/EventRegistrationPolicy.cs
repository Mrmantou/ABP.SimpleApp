using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Timing;
using Abp.UI;
using EventCloud.Authorization.Users;
using EventCloud.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventCloud.Events
{
    public class EventRegistrationPolicy : IEventRegistrationPolicy
    {
        private readonly IRepository<EventRegistration> eventRegistrationRepository;
        private readonly ISettingManager settingManager;

        public EventRegistrationPolicy(IRepository<EventRegistration> eventRegistrationRepository, ISettingManager settingManager)
        {
            this.eventRegistrationRepository = eventRegistrationRepository;
            this.settingManager = settingManager;
        }

        public async Task CheckRegistrationAttemptAsync(Event @event, User user)
        {
            if (@event == null)
            {
                throw new ArgumentNullException("event");
            }

            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            CheckEventDate(@event);

            await CheckEventRegistrationFrequencyAsync(user);

        }

        private static void CheckEventDate(Event @event)
        {
            if (@event.IsInPast())
            {
                throw new UserFriendlyException("Can not register event in the past!");
            }
        }

        private async Task CheckEventRegistrationFrequencyAsync(User user)
        {
            var oneMonthAgo = Clock.Now.AddDays(-30);
            var maxAllowedEventRegistrationCountInLast30DaysPerUser = await settingManager.GetSettingValueAsync<int>(AppSettingNames.MaxAllowedEventRegistrationCountInLast30DaysPerUser);

            if (maxAllowedEventRegistrationCountInLast30DaysPerUser > 0)
            {
                var registrationCountInLast30Days = await eventRegistrationRepository.CountAsync(r => r.UserId == user.Id && r.CreationTime > oneMonthAgo);

                if (registrationCountInLast30Days > maxAllowedEventRegistrationCountInLast30DaysPerUser)
                {
                    throw new UserFriendlyException(string.Format("Can not register to more than {0}", maxAllowedEventRegistrationCountInLast30DaysPerUser));
                }
            }
        }
    }
}
