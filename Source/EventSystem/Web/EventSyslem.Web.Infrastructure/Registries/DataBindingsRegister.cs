namespace EventSystem.Web.Infrastructure.Registries
{
    using System.Data.Entity;

    using Data;
    using Data.Common.Repositories;
    using Ninject;
    using Ninject.Web.Common;

    public class DataBindingsRegister : INinjectRegistry
    {
        public void Register(IKernel kernel)
        {
            kernel.Bind<DbContext>().To<EventSystemDbContext>().InRequestScope();
            kernel.Bind(typeof(IDbRepository<>)).To(typeof(DbRepository<>));
        }
    }
}
