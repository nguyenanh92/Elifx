using System.Web.Mvc;
using System.Web.Routing;

namespace PCar
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Default", "{aliasMenuSub}/{idSub}/{aliasSub}", new
                {
                    controller = "HomePage",
                    action = "Index",
                    aliasMenuSub = UrlParameter.Optional,
                    idSub = UrlParameter.Optional,
                    aliasSub = UrlParameter.Optional
                }
          );
        }
    }
}