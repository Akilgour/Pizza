using Pizza.Admin.Factory;
using Pizza.Interface.Service;
using System;
using System.Threading.Tasks;

namespace Pizza.Admin
{
    public class Application
    {
        private readonly IPizzaOrderService pizzaService;

        public Application(IPizzaOrderService pizzaService)
        {
            this.pizzaService = pizzaService;
        }

        public async Task Run(string[] args)
        {
            char keyPress;
            do
            {
                Console.WriteLine(" 1. Add Large Pizza to Orders");
                Console.WriteLine(" 2. Add Small Pizza to Orders");

                Console.WriteLine(" 0. Exit");
                keyPress = Console.ReadKey().KeyChar;

                switch (keyPress)
                {
                    case '1':
                       await pizzaService.AddOrder(LargePizzaFactory.Create());
                        break;

                    case '2':
                        await pizzaService.AddOrder(SmallPizzaFactory.Create());

                        break;

                    default:
                        break;
                }

            } while (keyPress != 0);
        }
    }
}