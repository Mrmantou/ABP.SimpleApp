using System.Collections.Generic;
using EventCloud.Roles.Dto;
using EventCloud.Users.Dto;

namespace EventCloud.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
