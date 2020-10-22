using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Common.Constants;

namespace Web.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sess = (UserLogin)Session[UserCons.USER_SESSION];
            if (sess == null)
            {
                filterContext.Result =
                    new RedirectToRouteResult(
                        new RouteValueDictionary(new
                            { controller = "Login", action = "LoginAdmin", Area = "Administrator" }));
            }
            s
            base.OnActionExecuting(filterContext);


        }
    }
}