using System.Collections.Generic;
using Elifx.Roles.Dto;

namespace Elifx.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
