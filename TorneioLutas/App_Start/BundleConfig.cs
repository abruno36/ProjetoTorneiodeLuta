using System.Web;
using System.Web.Optimization;

namespace TorneioLutas
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js").Include("~/Scripts/jquery.validate*").Include("~/Scripts/jquery.furl.js").Include("~/Scripts/jquery-ui-1.12.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/default/style").Include("~/Content/css/bootstrap.css", "~/Content/css/default.css"));
        }
    }
}
