using Autofac;
using Pizza.Admin.Autofac;

namespace Pizza.Admin
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup the DI container
            var container = AutofacConfiguration.Configure();

            var task = container.Resolve<Application>().Run(args);
            task.Wait();

        }
    }
}
