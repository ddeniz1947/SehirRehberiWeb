using System.Web;
using System.Web.Optimization;

namespace SehirRehberiApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css")
                );

            bundles.Add(new StyleBundle("~/styles")
                  .Include("~/content/css/bootstrap.min.css")
                  .Include("~/content/css/all.css")
                  .Include("~/content/css/mobile.css")
                  .Include("~/content/css/close.css")
                  .Include("~/content/css/buttoncss.css")
                  .Include("~/content/css/buttonavbar.css")
                  );
            bundles.Add(new StyleBundle("~/bundles/angularjs")
                .Include("~/scripts/angular.js")
                .Include("~/scripts/getService.js")
                );
            bundles.Add(new ScriptBundle("~/scripts")
                .Include("~/content/js/jquery-3.4.1.js")
                .Include("~/content/js/angular.min.js")
              .Include("~/content/js/popper.min.js")
              .Include("~/content/js/bootstrap.min.js")
              .Include("~/content/js/all.js")
              .Include("~/content/js/getService.js")
              .Include("~/Areas/AdminArea/Views/Admin/deneme.js")
               );
        }
    }
}
