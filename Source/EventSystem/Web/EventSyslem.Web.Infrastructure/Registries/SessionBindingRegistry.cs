namespace EventSystem.Web.Infrastructure.Registries
{
    using System.Web;

    using EventSystem.Web.Infrastructure.Adapters;
    using Ninject;
    using Ninject.Web.Common;

    public class SessionBindingRegistry : INinjectRegistry
    {
        public void Register(IKernel kernel)
        {
            kernel.Bind<ISessionAdapter>()
                  .To<SessionAdapter>()
                  .InRequestScope()
                  .WithConstructorArgument(
                      "session",
                      ninjectContext => new HttpSessionStateWrapper(HttpContext.Current.Session)
                  );
        }
    }
}
