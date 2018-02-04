using System.Web;
using System.Web.Optimization;

namespace UploadFile
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery/jquery-3.3.1.min.js",
                        "~/Scripts/scripts.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap/bootstrap.css",
                      "~/Content/style.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
