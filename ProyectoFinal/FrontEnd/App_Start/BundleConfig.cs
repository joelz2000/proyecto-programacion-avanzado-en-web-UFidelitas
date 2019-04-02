using System.Web;
using System.Web.Optimization;

namespace FrontEnd
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
           bundles.Add(new ScriptBundle("~/bundles/JSAdmin").Include(
                        "~/Scripts/jquery.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Content/dist/js/adminlte.min.js",
                        "~/Content/bower_components/datatables.net/js/jquery.dataTables.min.js",
                        "~/Content/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js",
                        "~/Scripts/sweetalert2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables4").Include(
                        "~/Scripts/Datatables/jquery.dataTables.min.js",
                        "~/Scripts/Datatables/dataTables.bootstrap4.min.js",
                        "~/Scripts/Datatables/dataTables.min.js",
                        "~/Scripts/Datatables/responsive.bootstrap4.min.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                        "~/Content/bower_components/datatables.net/js/jquery.dataTables.min.js",
                        "~/Content/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/bundles/datatablesCss").Include(
                        "~/Content/bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                        "~/Scripts/umd/popper.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/adminlte").Include(
                        "~/dist/js/adminlte.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/sweetalert").Include(
                        "~/Scripts/sweetalert2.min.js"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/theme.min.css",
                      "~/Content/sweetalert2.min.css",
                      "~/Content/bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/Datatables4").Include(
                      "~/Content/Datatables/dataTables.bootstrap4.min.css",
                      "~/Content/Datatables/dataTables.min.css",
                      "~/Content/Datatables/responsive.bootstrap4.min.css"));
        }
    }
}
