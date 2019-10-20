using Autofac;
using Pizza.RepositoryCore.Context;
using System.Linq;

namespace Pizza.RepositoryCore.Autofac
{
    public class PizzaRepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .WithParameter("context", new PizzaContext())
                .AsImplementedInterfaces();
        }
    }
}