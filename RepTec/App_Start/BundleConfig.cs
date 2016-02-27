using System.Web.Optimization;

namespace RepTec
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/angular").IncludeDirectory("~/App", "*.js", true));

            bundles.Add(new ScriptBundle("~/Scripts/libraries").Include(
                "~/Scripts/modernizr-{version}.js",
                "~/Scripts/angular.js",
                "~/Scripts/angular-route.js"));

            bundles.Add(new StyleBundle("~/Content/css").IncludeDirectory("~/Content", "*.css", true));

            #if (!DEBUG)
                BundleTable.EnableOptimizations = true;
            #endif

        }
    }
}