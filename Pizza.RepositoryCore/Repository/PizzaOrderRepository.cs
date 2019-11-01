using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Pizza.RepositoryCore.Context;
using Pizza.RepositoryCore.Logging;
using Pizza.RepositoryCore.Model;
using Pizza.RepositoryCore.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.RepositoryCore.Repository
{
    public class PizzaOrderRepository : IPizzaOrderRepository
    {
        private readonly PizzaContext context;
        private DbContextOptions options;

        public PizzaOrderRepository(PizzaContext context)
        {
            this.context = context;
          //TODO PUT BACK IN  context.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());
        }

        public PizzaOrderRepository(DbContextOptions options)
        {
            this.options = options;
        }

        public async Task AddRange(List<PizzaOrder> pizzaOrders)
        {
            try
            {
                await context.AddRangeAsync(pizzaOrders);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PizzaOrder>> GetByBaseType(string baseType)
        {
            try
            {
                var result = await context.PizzaOrder.Where(x => x.BaseType == baseType).ToListAsync();
                return result;
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
                //   context.Create(pizzaOrder);

                context.ChangeTracker.TrackGraph(pizzaOrder, e => ApplyStateUsingIsKeySet(e.Entry));

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //TODO Refactor into helper with TESTS
        public static void ApplyStateUsingIsKeySet(EntityEntry entity)
        {
            if (entity.IsKeySet)
            {
                entity.State = EntityState.Unchanged;
            }
            else
            {
                entity.State = EntityState.Added;
            }
        }

    }
}