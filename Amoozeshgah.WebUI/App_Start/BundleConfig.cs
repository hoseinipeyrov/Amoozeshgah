using System.Web.Optimization;

namespace Amoozeshgah.WebUI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/wwwroot/bundles/jquery").Include(
                        "~/wwwroot/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/wwwroot/bundles/jqueryval").Include(
                        "~/wwwroot/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/wwwroot/bundles/modernizr").Include(
                        "~/wwwroot/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/wwwroot/bundles/bootstrap").Include(
                      "~/wwwroot/bower_components/bootstrap/dist/js/bootstrap.min.js",
                      "~/wwwroot/Scripts/bootstrap.rtl.min.js",
                      "~/wwwroot/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/wwwroot/Content/css").Include(
                      "~/wwwroot/Content/bootstrap.min.css",
                      "~/wwwroot/Content/bootstrap.rtl.css",
                      "~/wwwroot/bower_components/metisMenu/dist/metisMenu.min.css",
                      "~/wwwroot/Content/timeline.css",
                      "~/wwwroot/Content/sb-admin-2.css",
                      "~/wwwroot/Content/vazir-font.css"));

            bundles.Add(new StyleBundle("~/wwwroot/Content/logincss").Include(
                      "~/wwwroot/Content/bootstrap.min.css",
                      "~/wwwroot/Content/bootstrap.rtl.min.css",
                      "~/wwwroot/bower_components/bootsnipp-material-design-switch/checkbox.css",
                      "~/wwwroot/Content/vazir-font.css",
                      "~/wwwroot/bower_components/bootsnipp-buttons-with-labels/buttons-with-labels.css",
                      "~/wwwroot/Content/pages/login.css"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/data-tables").IncludeDirectory(
                "~/wwwroot/app_files/", "*.js", true
                ));













            bundles.Add(new StyleBundle("~/wwwroot/bundles/styles").Include(
                    "~/wwwroot/Content/bootstrap.rtl.min.css",
                    "~/wwwroot/bower_components/metisMenu/dist/metisMenu.min.css",
                    "~/wwwroot/Content/sb-admin-2.css",
                    "~/wwwroot/bower_components/data-tables/datatables.min.css",
                    "~/wwwroot/bower_components/data-tables/DataTables-1.10.16/css/dataTables.bootstrap.css",
                    "~/wwwroot/Content/vazir-font.css",
                    "~/wwwroot/bower_components/iziModal/css/iziModal.css",
                    "~/wwwroot/Content/pages/shared.css",
                    "~/wwwroot/bower_components/data-tables/Buttons-1.5.1/css/buttons.dataTables.css",
                    "~/wwwroot/bower_components/data-tables/Buttons-1.5.1/css/buttons.bootstrap.min.css",
                    "~/wwwroot/bower_components/data-tables/Scroller-1.4.4/css/scroller.dataTables.css",
                    "~/wwwroot/bower_components/data-tables/Scroller-1.4.4/css/scroller.bootstrap.min.css",
                    "~/wwwroot/bower_components/bootsnipp-simple-sard-alerts/card-alert.css",
                    "~/wwwroot/bower_components/bestjquery-tab/bestjquery-tab.css",
                    "~/wwwroot/bower_components/css-image-effect/image-effect.css",
                    "~/wwwroot/bower_components/lobipanel-master/dist/css/lobipanel.min.css",
                    "~/wwwroot/bower_components/bootstrap-breadcrumb/breadcrumb.css",
                    "~/wwwroot/bower_components/bootstrap-sweetalert/dist/sweetalert.css",
                    "~/wwwroot/bower_components/persian-jalali-calendar/style/kamadatepicker.min.css",
                    "~/wwwroot/bower_components/bootstrap-select/dist/css/bootstrap-select.min.css",
                    "~/wwwroot/bower_components/bootstrapformhelpers/css/bootstrap-formhelpers.min.css"
                    ));










            bundles.Add(new ScriptBundle("~/wwwroot/bundles/scripts").Include(
                       "~/wwwroot/Scripts/jquery-3.3.1.min.js",
                       "~/wwwroot/Scripts/jquery.validate.min.js",
                       "~/wwwroot/Scripts/jquery.validate.unobtrusive.min.js",
                       "~/wwwroot/Scripts/bootstrap.rtl.min.js",
                       "~/wwwroot/bower_components/metisMenu/dist/metisMenu.min.js",
                       "~/wwwroot/Scripts/sb-admin-2.js",
                       "~/wwwroot/bower_components/nanobar-master/nanobar.min.js",
                       "~/wwwroot/Content/pages/shared.js",
                       "~/wwwroot/bower_components/iziModal/js/iziModal.min.js",
                       "~/wwwroot/bower_components/data-tables/DataTables-1.10.16/js/jquery.dataTables.js",
                       "~/wwwroot/bower_components/data-tables/DataTables-1.10.16/js/dataTables.bootstrap.min.js",
                       "~/wwwroot/bower_components/data-tables/Buttons-1.5.1/js/dataTables.buttons.min.js",
                       "~/wwwroot/bower_components/data-tables/Buttons-1.5.1/js/buttons.print.min.js",
                       "~/wwwroot/bower_components/data-tables/Buttons-1.5.1/js/buttons.bootstrap.js",
                       "~/wwwroot/bower_components/data-tables/Buttons-1.5.1/js/buttons.html5.min.js",
                       "~/wwwroot/bower_components/data-tables/Buttons-1.5.1/js/buttons.flash.min.js",
                       "~/wwwroot/bower_components/data-tables/pdfmake-0.1.32/pdfmake.min.js",
                       "~/wwwroot/bower_components/data-tables/pdfmake-0.1.32/vfs_fonts.js",
                       "~/wwwroot/bower_components/data-tables/JSZip-2.5.0/jszip.min.js",
                       "~/wwwroot/bower_components/data-tables/Scroller-1.4.4/js/dataTables.scroller.min.js",
                       "~/wwwroot/bower_components/notify-js/notify.min.js",
                       "~/wwwroot/bower_components/select2/dist/js/select2.full.min.js",
                       "~/wwwroot/bower_components/select2/dist/js/i18n/fa.js",
                       "~/wwwroot/bower_components/lobipanel-master/dist/js/lobipanel.min.js",
                       "~/wwwroot/bower_components/livicons/js/raphael-min.js",
                       "~/wwwroot/bower_components/livicons/js/livicons-customizer-1.3.js",
                       "~/wwwroot/bower_components/livicons/js/jquery.inputCtl.min.js",
                       "~/wwwroot/bower_components/livicons/js/jquery.minicolors.min.js",
                       "~/wwwroot/bower_components/livicons/js/customizer.js",
                       "~/wwwroot/bower_components/bootstrap-sweetalert/dist/sweetalert.min.js",
                       "~/wwwroot/bower_components/bootstrap-select/dist/js/bootstrap-select.min.js",
                       "~/wwwroot/bower_components/bootstrap-select/dist/js/i18n/defaults-fa_IR.js",
                       "~/wwwroot/bower_components/bootstrapformhelpers/js/bootstrap-formhelpers.js"
                       ));
            BundleTable.EnableOptimizations = true;
        }
    }
}
