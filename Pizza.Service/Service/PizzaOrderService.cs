using Pizza.Interface.Service;
using Pizza.Model.Model;
using Pizza.Service.Manager.Interface;
using System.Threading.Tasks;

namespace Pizza.Service.Service
{
    public class PizzaOrderService : IPizzaOrderService
    {
        private readonly IPizzaOrderManager pizzaOrderManager;

        public PizzaOrderService(IPizzaOrderManager pizzaOrderManager)
        {
            this.pizzaOrderManager = pizzaOrderManager;
        }

        public async Task AddOrder(PizzaOrderDTO pizzaOrder)
        {
            await pizzaOrderManager.AddOrder(pizzaOrder);
        }
    }
}