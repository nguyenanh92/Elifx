using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Elifx.Web.Views
{
    public abstract class ElifxRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected ElifxRazorPage()
        {
            LocalizationSourceName = ElifxConsts.LocalizationSourceName;
        }
    }
}
