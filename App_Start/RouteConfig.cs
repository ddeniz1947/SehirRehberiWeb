using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SehirRehberiApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.MapRoute("HomePage", "", new { controller = "Home", action = "Index" });
            routes.MapRoute("Register", "Register", new { controller = "Register", action = "Index" });
            routes.MapRoute("RegisterIn", "RegisterIn", new { controller = "Register", action = "Register" });
            routes.MapRoute("Login", "Login", new { controller = "Login", action = "Login" });
            routes.MapRoute("Logout", "Logout", new { controller = "Login", action = "Logout" });
            routes.MapRoute("About", "About", new { controller = "Home", action = "About" });
            routes.MapRoute("Contact", "Contact", new { controller = "Home", action = "Contact" });
            routes.MapRoute("FirstPage", "FirstPage", new { controller = "Pages", action = "FirstPage" });
        }
    }
}
