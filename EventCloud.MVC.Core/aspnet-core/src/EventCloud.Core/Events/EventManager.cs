using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.UI;
using EventCloud.Authorization.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventCloud.Events
{
    public class EventManager : IEventManager
    {
        public IEventBus EventBus { get; set; }

        private readonly IEventRegistrationPolicy registrationPolicy;
        private readonly IRepository<EventRegistration> eventRegistrationRepository;
        private readonly IRepository<Event, Guid> eventRepository;

        public EventManager(IEventRegistrationPolicy registrationPolicy, IRepository<EventRegistration> eventRegistrationRepository, IRepository<Event, Guid> eventRepository)
        {
            this.registrationPolicy = registrationPolicy;
            this.eventRegistrationRepository = eventRegistrationRepository;
            this.eventRepository = eventRepository;

            EventBus = NullEventBus.Instance;
        }

        public void Cancel(Event @event)
        {
            @event.Cancel();
            EventBus.Trigger(new EventCancelledEvent(@event));
        }

        public async Task CreateAsync(Event @event)
        {
            await eventRepository.InsertAsync(@event);
        }

        public async Task<Event> GetAsync(Guid id)
        {
            var @event = await eventRepository.FirstOrDefaultAsync(id);

            if (@event == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted!");
            }
            return @event;
        }

        public async Task<IReadOnlyList<User>> GetRegisteredUsersAsync(Event @event)
        {
            return await eventRegistrationRepository.GetAll()
                .Include(r => r.User)
                .Where(r => r.EventId == @event.Id)
                .Select(r => r.User)
                .ToListAsync();
        }

        public async Task<EventRegistration> RegisterAsync(Event @event, User user)
        {
            return await eventRegistrationRepository.InsertAsync(await EventRegistration.CreateAsync(@event, user, registrationPolicy));
        }

        public async Task CancelRegistrationAsync(Event @event, User user)
        {
            var registration = await eventRegistrationRepository.FirstOrDefaultAsync(r => r.EventId == @event.Id && r.UserId == user.Id);

            if (registration == null)
            {
                //No need to cancel since there is no such a registration
                return;
            }

            await registration.CancelAsync(eventRegistrationRepository);
        }

    }
}
