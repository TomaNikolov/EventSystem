namespace EventSystem.Web
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScriptBundels(bundles);
            RegisterStyleBundels(bundles);
        }

        private static void RegisterScriptBundels(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/theme").Include(
                    "~/Content/Theme/js/gmaps.js",
                     "~/Content/Theme/js/smoothscroll.js",
                      "~/Content/Theme/js/coundown-timer.js",
                       "~/Content/Theme/js/parallax.js",
                       "~/Content/Theme/js/jquery.scrollTo.js",
                       "~/Content/Theme/js/main.js"));
        }

        private static void RegisterStyleBundels(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/styleBundles/theme")
                .Include("~/Content/Theme/css/bootstrap.min.css")
                .Include("~/Content/Theme/css/font-awesome.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/Theme/css/main.css")
                .Include("~/Content/Theme/css/animate.css")
                .Include("~/Content/Theme/css/animate.css")
                .Include("~/Content/Theme/css/responsive.css"));

            bundles.Add(new StyleBundle("~/styleBundles/css")
                .Include( "~/Content/Site.css"));
        }
    }
}
