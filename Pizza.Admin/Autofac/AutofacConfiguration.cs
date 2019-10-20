using Autofac;
using Pizza.Service.Autofac;

namespace Pizza.Admin.Autofac
{
    public class AutofacConfiguration
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>();

            builder.RegisterModule(new PizzaServiceModule());

            // Set the dependency resolver to be Autofac.
            return builder.Build();
        }
    }
}