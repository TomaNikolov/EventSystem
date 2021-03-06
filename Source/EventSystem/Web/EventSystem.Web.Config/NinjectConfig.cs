[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(EventSystem.Web.Config.NinjectConfig), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(EventSystem.Web.Config.NinjectConfig), "Stop")]

namespace EventSystem.Web.Config
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Web;

    using Infrastructure.Constants;
    using Infrastructure.Registries;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectConfig
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            var registries =
               Assembly.Load(Assemblies.Infrastructure)
                   .GetExportedTypes()
                   .Where(t => t.IsClass && typeof(INinjectRegistry).IsAssignableFrom(t));

            foreach (var registry in registries)
            {
                var registryInstance = (INinjectRegistry)Activator.CreateInstance(registry);
                registryInstance.Register(kernel);
            }
        }
    }
}
