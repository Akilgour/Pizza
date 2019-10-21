using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Pizza.RepositoryCore.Context;
using Pizza.RepositoryCore.Logging;
using Pizza.RepositoryCore.Model;
using Pizza.RepositoryCore.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.RepositoryCore.Repository
{
    public class PizzaOrderRepository : IPizzaOrderRepository
    {
        private readonly PizzaContext context;

        public PizzaOrderRepository(PizzaContext context)
        {
            this.context = context;
            context.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());
        }

        public async Task AddRange(List<PizzaOrder> pizzaOrders)
        {
            try
            {
              

             context.AddRange(pizzaOrders);
                  context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Create(PizzaOrder pizzaOrder)
        {
            try
            {
                context.Create(pizzaOrder);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}