using Autofac;
using Pizza.Admin.Autofac;

namespace Pizza.Admin
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = AutofacConfiguration.Configure();
            var task = container.Resolve<Application>().Run(args);
            task.Wait();
        }
    }
}