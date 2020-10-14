using Abp.Authorization;
using Elifx.Authorization.Roles;
using Elifx.Authorization.Users;

namespace Elifx.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
