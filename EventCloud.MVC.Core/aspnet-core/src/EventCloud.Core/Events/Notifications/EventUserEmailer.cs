using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.Events.Bus.Entities;
using Abp.Events.Bus.Handlers;
using Abp.Threading;
using Castle.Core.Logging;
using EventCloud.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventCloud.Events.Notifications
{
    public class EventUserEmailer :
        IEventHandler<EntityCreatedEventData<Event>>,
        IEventHandler<EventDateChangedEvent>,
        IEventHandler<EventCancelledEvent>,
        ITransientDependency
    {
        public ILogger Logger { get; set; }

        private readonly UserManager userManager;
        private readonly IEventManager eventManager;

        public EventUserEmailer(UserManager userManager, IEventManager eventManager)
        {
            this.userManager = userManager;
            this.eventManager = eventManager;

            Logger = NullLogger.Instance;
        }

        [UnitOfWork]
        public void HandleEvent(EntityCreatedEventData<Event> eventData)
        {
            //TODO: Send email to all tenant users as a notification

            var users = userManager
                .Users
                .Where(u => u.TenantId == eventData.Entity.TenantId)
                .ToList();

            foreach (var user in users)
            {
                var message = $"Hey! There is a new event '{eventData.Entity.Title}' on {eventData.Entity.Date}! Want to register?";

                Logger.Debug($"TODO: Send email to {user.EmailAddress} -> {message}");
            }
        }

        public void HandleEvent(EventDateChangedEvent eventData)
        {
            //TODO: Send email to all registered users!

            var registeredUsers = AsyncHelper.RunSync(() => eventManager.GetRegisteredUsersAsync(eventData.Entity));

            foreach (var user in registeredUsers)
            {
                var message = eventData.Entity.Title + " event's date is changed! New date is: " + eventData.Entity.Date;
                Logger.Debug(string.Format("TODO: Send email to {0} -> {1}", user.EmailAddress, message));
            }
        }

        public void HandleEvent(EventCancelledEvent eventData)
        {
            //TODO: Send email to all registered users!

            var registeredUsers = AsyncHelper.RunSync(() => eventManager.GetRegisteredUsersAsync(eventData.Entity));

            foreach (var user in registeredUsers)
            {
                var message = eventData.Entity.Title + " event is canceled!";
                Logger.Debug(string.Format("TODO: Send email to {0} -> {1}", user.EmailAddress, message));
            }
        }
    }
}
