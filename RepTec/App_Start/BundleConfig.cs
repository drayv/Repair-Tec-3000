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
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/angular.js",
                "~/Scripts/angular-route.js",
                "~/Scripts/angular-resource.js"));

            bundles.Add(new ScriptBundle("~/Scripts/semantic").IncludeDirectory("~/Content/Semantic-UI", "*.js", true));

            bundles.Add(new StyleBundle("~/Content/css").IncludeDirectory("~/Content", "*.css", true));

            #if (!DEBUG)
                BundleTable.EnableOptimizations = true;
            #endif

        }
    }
}