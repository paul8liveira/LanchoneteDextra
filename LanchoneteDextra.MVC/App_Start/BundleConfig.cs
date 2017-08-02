using System.Web.Optimization;

namespace LanchoneteDextra.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery3.2.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/ie_emulation_modes_warning").Include(
                        "~/Scripts/ie_emulation_modes_warning.js"));

            bundles.Add(new ScriptBundle("~/bundles/ie10_viewport_bug_workaround").Include(
                        "~/Scripts/ie10_viewport_bug_workaround.js"));

            bundles.Add(new ScriptBundle("~/bundles/index").Include(
                        "~/Scripts/index.js"));

            bundles.Add(new ScriptBundle("~/bundles/personalizar").Include(
                        "~/Scripts/personalizar.js"));

            //CSS    
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                      "~/Content/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/ie10_viewport_bug_workaround").Include(
                      "~/Content/ie10_viewport_bug_workaround.css"));

            bundles.Add(new StyleBundle("~/Content/jumbotron_narrow").Include(
                      "~/Content/jumbotron_narrow.css"));
            
        }
    }
}
