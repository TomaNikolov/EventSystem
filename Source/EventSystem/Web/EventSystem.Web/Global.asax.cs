namespace EventSystem.Web
{
    using Config;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class MvcApplication : System.Web.HttpApplication
    {
        public object ViewEngine { get; private set; }

        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            DbConfig.Initialize();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.RegisterMappings();
        }
    }
}
