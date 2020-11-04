using System.Web.Mvc;
using System.Web.Routing;

namespace PCar
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Contact", "Contact/Send", new
            {
                controller = "ContactH",
                action = "SubmitContact",
            });
            routes.MapRoute("ContactM", "Contact/Messages", new
            {
                controller = "ContactH",
                action = "Messages",
            });


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