using System.Collections.Generic;
using EventCloud.Roles.Dto;

namespace EventCloud.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}