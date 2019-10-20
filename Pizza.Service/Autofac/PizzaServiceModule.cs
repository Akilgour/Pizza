using Autofac;
using Pizza.RepositoryCore.Autofac;
using Pizza.RepositoryCore.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza.Service.Autofac
{
    public class PizzaServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterModule(new PizzaRepositoryModule());

            //"ThisAssembly" means "any types in the same assembly as the module"
            builder.RegisterAssemblyTypes(ThisAssembly)
                 .Where(t => t.Name.EndsWith("Service"))
                 .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Manager"))
                .AsImplementedInterfaces();
        }
    }
}