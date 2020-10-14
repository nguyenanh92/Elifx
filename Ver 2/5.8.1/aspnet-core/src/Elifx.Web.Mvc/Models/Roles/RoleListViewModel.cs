using System.Collections.Generic;
using Elifx.Roles.Dto;

namespace Elifx.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
