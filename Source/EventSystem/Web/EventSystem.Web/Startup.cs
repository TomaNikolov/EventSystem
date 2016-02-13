using Microsoft.Owin;

[assembly: OwinStartupAttribute(typeof(EventSystem.Web.Startup))]
namespace EventSystem.Web
{
    using EventSystem.Web.Config;
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            AuthConfig.Initialize(app);
        }
    }
}
