using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Elifx.Controllers
{
    public abstract class ElifxControllerBase: AbpController
    {
        protected ElifxControllerBase()
        {
            LocalizationSourceName = ElifxConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
