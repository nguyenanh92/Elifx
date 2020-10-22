using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DataLibrary.Common;
using DataLibrary.Database;
using DataLibrary.Security;

namespace PCar.Areas.Administrator.Controllers
{
    public class IBaseController : Controller
    {
        //
        // GET: /Administrator/IBase/

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sess = (UserLogin) Session[CommonConstants.USER_SESSION];
            if (sess == null)
            {
                filterContext.Result =
                    new RedirectToRouteResult(
                        new RouteValueDictionary(new
                            { controller = "Login", action = "LoginAdmin", Area = "Administrator" }));
            }
          
            base.OnActionExecuting(filterContext);
                
             
        }
    }
}