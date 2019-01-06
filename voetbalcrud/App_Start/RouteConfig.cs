using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace voetbalcrud
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Positions",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "PlayerList", action = "Index", id = UrlParameter.Optional }

            //);
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
<<<<<<< HEAD
                defaults: new { controller = "HomeController", action = "Create", id = UrlParameter.Optional }

                   );

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Team",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "PlayerListController", action = "Create", id = UrlParameter.Optional }


=======
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
>>>>>>> otherbranch
            );

            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        }
    }
}
