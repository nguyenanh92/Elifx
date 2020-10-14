using System.Collections.Generic;
using Elifx.Roles.Dto;

namespace Elifx.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}