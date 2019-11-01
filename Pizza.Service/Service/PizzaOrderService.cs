using Pizza.Interface.Service;
using Pizza.Model.Model;
using Pizza.Service.Manager.Interface;
using System.Collections.Generic;
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

        public async Task AddMultipleOrder(List<PizzaOrderDTO> PizzaOrderDTOs)
        {
            await pizzaOrderManager.AddMultipleOrder(PizzaOrderDTOs);
        }

        public async Task AddOrder(PizzaOrderDTO pizzaOrder)
        {
            await pizzaOrderManager.AddOrder(pizzaOrder);
        }

        public async Task<List<PizzaOrderDTO>> GetAll()
        {
            return await pizzaOrderManager.GetAll();
        }
    }
}