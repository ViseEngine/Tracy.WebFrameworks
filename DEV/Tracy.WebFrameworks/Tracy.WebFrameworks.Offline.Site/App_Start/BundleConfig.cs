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

            bundles.Add(new ScriptBundle("~/bundles/easyui").Include(
                        "~/Scripts/easyui/jquery.easyui.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryform").Include(
                        "~/Scripts/jquery.form.js"));

            //css
            bundles.Add(new StyleBundle("~/Content/easyui/default").Include(
                      "~/Content/easyui/default/easyui.css",
                      "~/Content/easyui/icon.css"));
            //css.gray
            bundles.Add(new StyleBundle("~/Content/easyui/gray").Include(
                      "~/Content/easyui/gray/easyui.css",
                      "~/Content/easyui/icon.css"));
            //css.bootstrap
            bundles.Add(new StyleBundle("~/Content/easyui/bootstrap").Include(
                      "~/Content/easyui/bootstrap/easyui.css",
                      "~/Content/easyui/icon.css"));
            //css.metro
            bundles.Add(new StyleBundle("~/Content/easyui/metro").Include(
                      "~/Content/easyui/metro/easyui.css",
                      "~/Content/easyui/icon.css"));

            bundles.Add(new StyleBundle("~/Content/site").Include(
                        "~/Content/Site.css"));
        }
    }
}
