using System.Web;
using System.Web.Optimization;

namespace GameRetailer
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

            bundles.Add(new ScriptBundle("~/bundles/Guias").Include(
            "~/Scripts/guias.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/gameretailer").Include(
                 "~/Scripts/GameRetailer.js"));

            bundles.Add(new ScriptBundle("~/admin-lte/js").Include(
                "~/admin-lte/js/adminlte.js",
             "~/admin-lte/js/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                   "~/Scripts/DataTables/jquery.dataTables.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/bootstrap.css",
                       "~/Content/bootstrap-theme.css",
                       "~/Content/site.css",
                       "~/Content/font-awesome.css",
                       "~/admin-lte/css/AdminLTE.css",
                       "~/admin-lte/css/skins/skin-black-light.css"
                       ));
        }
    }
}
