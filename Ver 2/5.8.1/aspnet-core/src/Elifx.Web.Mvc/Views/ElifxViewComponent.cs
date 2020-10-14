using Abp.AspNetCore.Mvc.ViewComponents;

namespace Elifx.Web.Views
{
    public abstract class ElifxViewComponent : AbpViewComponent
    {
        protected ElifxViewComponent()
        {
            LocalizationSourceName = ElifxConsts.LocalizationSourceName;
        }
    }
}
