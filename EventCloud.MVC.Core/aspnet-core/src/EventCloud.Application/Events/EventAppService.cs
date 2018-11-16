using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using EventCloud.Authorization.Users;
using EventCloud.Events.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventCloud.Events
{
    [AbpAuthorize]
    public class EventAppService : EventCloudAppServiceBase, IEventAppService
    {
        private readonly IEventManager eventManager;
        private readonly IRepository<Event, Guid> eventRepository;

        public EventAppService(IEventManager eventManager, IRepository<Event, Guid> eventRepository)
        {
            this.eventManager = eventManager;
            this.eventRepository = eventRepository;
        }





        public async Task CreateAsync(CreateEventInput input)
        {
            throw new NotImplementedException();
        }

        public async Task<EventDetailOutput> GetDetailAsync(EntityDto<Guid> input)
        {
            throw new NotImplementedException();
        }

        public async Task<ListResultDto<EventListDto>> GetListAsync(GetEventListInput input)
        {
            throw new NotImplementedException();
        }

        public async Task CancelAsync(EntityDto<Guid> input)
        {
            var @event = await eventManager.GetAsync(input.Id);

        }

        public async Task<EventRegisterOutput> RegisterAsync(EntityDto<Guid> input)
        {
            var registration = await RegisterAndSaveAsync(
                await eventManager.GetAsync(input.Id),
                await GetCurrentUserAsync());

            return new EventRegisterOutput
            {
                RegistrationId = registration.Id
            };
        }

        public async Task CancelRegistrationAsync(EntityDto<Guid> input)
        {
            await eventManager.CancelRegistrationAsync(
                await eventManager.GetAsync(input.Id),
                await GetCurrentUserAsync());
        }

        private async Task<EventRegistration> RegisterAndSaveAsync(Event @event, User user)
        {
            var registration = await eventManager.RegisterAsync(@event, user);
            await CurrentUnitOfWork.SaveChangesAsync();
            return registration;
        }
    }
}
