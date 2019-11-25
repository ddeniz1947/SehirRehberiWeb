using System.Web.Mvc;

namespace SehirRehberiApp.Areas.AdminArea
{
    public class AdminAreaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AdminArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute("AdminPanel", "AdminPanel",   new { action = "Index", controller = "Admin" });
            context.MapRoute("AdminPanelEdit", "AdminPanelEdit",   new { action = "Edit", controller = "Admin" });
            context.MapRoute("AdminPanelDelete", "AdminPanelDelete", new { action = "Delete", controller = "Admin" });
        }
    }
}