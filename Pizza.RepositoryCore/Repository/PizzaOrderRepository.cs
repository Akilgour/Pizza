using Pizza.RepositoryCore.Context;
using Pizza.RepositoryCore.Model;
using Pizza.RepositoryCore.Repository.Interface;
using System;
using System.Threading.Tasks;

namespace Pizza.RepositoryCore.Repository
{
    public class PizzaOrderRepository : IPizzaOrderRepository
    {
        private readonly PizzaContext context;

        public PizzaOrderRepository(PizzaContext context)
        {
            this.context = context;
        }

        public async Task Create(PizzaOrder pizzaOrder)
        {
            try
            {
                context.Create(pizzaOrder);
                await context.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}