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
            routes.MapRoute("PostIndex", "PostIndex", new { controller = "Post", action = "Index" });
            routes.MapRoute("NewPost", "NewPost", new { controller = "Post", action = "NewPost" });
            routes.MapRoute("Ilceler", "Ilceler", new { controller = "Post", action = "IlcelerByIlId" });
            routes.MapRoute("Profile", "Profile", new { controller = "Profile", action = "Index" });
            routes.MapRoute("AddExtraImage", "AddExtraImage", new { controller = "Post", action = "AddExtraImage" });
            routes.MapRoute("EditProfile", "EditProfile", new { controller = "Profile", action = "Edit" });
            routes.MapRoute("ShowExtPost", "ShowExtPost", new { controller = "Pages", action = "ExtraImages" });
            routes.MapRoute("ClickedProfile", "ClickedProfile", new { controller = "Profile", action = "ClickedProfile" });
            routes.MapRoute("FollowingUser", "FollowingUser", new { controller = "Profile", action = "FollowingUser" });
            routes.MapRoute("DeletePost", "DeletePost", new { controller = "Post", action = "Delete" });
            routes.MapRoute("UnFollowUser", "UnFollowUser", new { controller = "Profile", action = "UnFollowUser" });






        }
    }
}
