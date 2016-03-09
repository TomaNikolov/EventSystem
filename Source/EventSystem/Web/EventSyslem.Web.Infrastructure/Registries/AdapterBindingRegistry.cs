namespace EventSystem.Web.Infrastructure.Registries
{
    using System.Web;

    using EventSystem.Web.Infrastructure.Adapters;
    using Ninject;
    using Ninject.Web.Common;

    public class AdapterBindingRegistry : INinjectRegistry
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

            kernel.Bind<IMapPathAdapter>()
                .To<MapPathAdapter>()
                .InRequestScope()
                .WithConstructorArgument(
                    "utility",
                    ninjectContext => HttpContext.Current.Server
                );

            kernel.Bind<IFileSaverAdapter>()
               .To<FileSaverAdapter>()
               .InRequestScope();

            kernel.Bind<IDirectoryAdapter>()
              .To<DirectoryAdapter>()
              .InRequestScope();

            kernel.Bind<IGuidAdapter>()
              .To<GuidAdapter>()
              .InRequestScope();
        }
    }
}
