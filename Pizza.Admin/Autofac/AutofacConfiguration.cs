using Autofac;

namespace Pizza.Admin.Autofac
{
    public class AutofacConfiguration
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>();

            // Set the dependency resolver to be Autofac.
            return builder.Build();
        }
    }
}