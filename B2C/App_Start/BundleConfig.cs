using System.Web;
using System.Web.Optimization;

namespace B2C
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
             //           "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

           // bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
             //         "~/Scripts/bootstrap.js",
               //       "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                      "~/bower_components/jquery/dist/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/bower_components/bootstrap/dist/js/bootstrap.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/metisMenu").Include(
                      "~/bower_components/metisMenu/dist/metisMenu.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/raphael").Include(
                      "~/bower_components/raphael/raphael-min.js"));


            bundles.Add(new ScriptBundle("~/bundles/morrisjs").Include(
                      "~/bower_components/morrisjs/morris.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/morris").Include(
                      "~/dist/js/morris-data.js"));

            bundles.Add(new ScriptBundle("~/bundles/sbadmin").Include(
                      "~/dist/js/sb-admin-2.js"));


            bundles.Add(new ScriptBundle("~/bundles/dataTables").Include(
                      "~/bower_components/datatables/media/js/jquery.dataTables.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/dataTables_bootstrap").Include(
                      "~/bower_components/datatables-plugins/integration/bootstrap/3/dataTables.bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/table").Include(
                      "~/dist/js/table.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/bower_components/bootstrap/dist/css/bootstrap.min.css",
                      "~/bower_components/metisMenu/dist/metisMenu.min.css",
                      "~/dist/css/timeline.css",
                      "~/dist/css/sb-admin-2.css",
                      "~/bower_components/morrisjs/morris.css",
                      "~/bower_components/font-awesome/css/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/css/dataTables").Include(
                "~/bower_components/datatables-plugins/integration/bootstrap/3/dataTables.bootstrap.css",
                "~/bower_components/datatables-responsive/css/dataTables.responsive.css"));


          


        }
    }
}
