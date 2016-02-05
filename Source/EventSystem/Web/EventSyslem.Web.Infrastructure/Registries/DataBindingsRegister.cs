namespace EventSystem.Web.Infrastructure.Registries
{
    using Data;
    using Data.Repositories;
    using Ninject;
    using Ninject.Web.Common;

    public class DataBindingsRegister : INinjectRegistry
    {
        public void Register(IKernel kernel)
        {
            kernel.Bind<IEventSystemDbContext>().To<EventSystemDbContext>().InRequestScope();
            kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));
        }
    }
}
