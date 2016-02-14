namespace EventSystem.Web.Infrastructure.Registries
{
    using Data;
    using Data.Repositories;
    using Ninject;
    using Ninject.Web.Common;
    using System.Data.Entity;
    public class DataBindingsRegister : INinjectRegistry
    {
        public void Register(IKernel kernel)
        {
            kernel.Bind<DbContext>().To<EventSystemDbContext>().InRequestScope();
            kernel.Bind(typeof(IDbRepository<>)).To(typeof(GenericRepository<>));
        }
    }
}
