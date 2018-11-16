using Abp.Domain.Services;
using EventCloud.Authorization.Users;
using System.Threading.Tasks;

namespace EventCloud.Events
{
    public interface IEventRegistrationPolicy : IDomainService
    {
        /// <summary>
        /// Checks if given user can register to <see cref="@event"/> and throws exception if can not.
        /// </summary>
        /// <param name="event"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        Task CheckRegistrationAttemptAsync(Event @event, User user);
    }
}
