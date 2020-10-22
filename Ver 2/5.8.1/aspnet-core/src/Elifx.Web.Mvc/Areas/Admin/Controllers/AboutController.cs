using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Elifx.Controllers;

namespace Elifx.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : ElifxControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
