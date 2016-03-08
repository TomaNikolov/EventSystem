namespace EventSystem.Web.Infrastructure.Registries
{
    using System.Web;

    using EventSystem.Web.Infrastructure.Adapters;
    using Ninject;
    using Ninject.Web.Common;

    public class MapPathBindingRegistry : INinjectRegistry
    {
        public void Register(IKernel kernel)
        {
            kernel.Bind<IMapPathAdapter>()
                .To<MapPathAdapter>()
                .InRequestScope()
                .WithConstructorArgument(
                    "utility",
                    ninjectContext => HttpContext.Current.Server
                );
        }
    }
}
