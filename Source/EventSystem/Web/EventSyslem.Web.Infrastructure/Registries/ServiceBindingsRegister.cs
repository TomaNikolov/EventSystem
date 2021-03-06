﻿namespace EventSystem.Web.Infrastructure.Registries
{
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;
    using Services.Contracts;

    public class ServiceBindingsRegister : INinjectRegistry
    {
        public void Register(IKernel kernel)
        {
            kernel.Bind(k => k.FromAssemblyContaining<IService>()
                .SelectAllClasses()
                .BindAllInterfaces()
                .Configure(b => b.InRequestScope()));

            kernel.Bind(k => k.From(Constants.Assemblies.WebServices)
            .SelectAllClasses()
            .BindDefaultInterfaces()
            .Configure(b => b.InRequestScope()));
                
        }
    }
}
