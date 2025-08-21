using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Event_Managment_and_Ticketing_System
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Custom Route: /Admin will go to AdminPannel/AddNewEvent
            routes.MapRoute(
                name: "AdminShort",
                url: "Admin",
                defaults: new { controller = "Admin", action = "AdminPannel" }
            );

            // Custom Route: /Account will go to Account/LoginPage
            routes.MapRoute(
                name: "AccountShort",
                url: "Account",
                defaults: new { controller = "Account", action = "LoginPage" }
            );

            // Custom Route: /Home will go to Home/Index
            routes.MapRoute(
                name: "HomeShort",
                url: "Home",
                defaults: new { controller = "Home", action = "Index" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            //routes.MapRoute(
            //    name: "Default1",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Account", action = "LoginPage", id = UrlParameter.Optional }
            //);
            //routes.MapRoute(
            //    name: "Default2",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Admin", action = "AdminPannel", id = UrlParameter.Optional }
            //);
        }
    }
}
