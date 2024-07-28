using System.Web;
using System.Web.Optimization;

namespace ScheduledTasksCindy
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

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/select2.min.css",
                      "~/Content/site.css",
                      "~/Content/fullcalendar/fullcalendar.min.css",
                      "~/Content/jquery-ui.min.css"
                      ));


            bundles.Add(new ScriptBundle("~/bundles/fullcalendar").Include(
                   "~/Scripts/fullcalendar/moment.min.js",
                   "~/Scripts/fullcalendar/fullcalendar.min.js"
                   ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                "~/Scripts/jquery-ui.min.js"
                     ));

            bundles.Add(new ScriptBundle("~/bundles/select2").Include(
                "~/Scripts/select2.min.js"
                     ));
        }
    }
}
