using System.Web;
using System.Web.Optimization;

namespace Tracy.WebFrameworks.Offline.Site
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //js
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jeasyui").Include(
                        "~/Scripts/easyui/jquery.easyui.min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //css
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/easyui/default/easyui.css",
                      "~/Content/easyui/icon.css",
                      "~/Content/site.css"));
        }
    }
}
