using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Pizza.RepositoryCore.Context;
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
                await context.SaveChangesAsync();
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

        public async Task<List<PizzaOrder>> GetAll()
        {
            try
            {
                return await context.PizzaOrder.OrderBy(x => EF.Property<DateTime>(x, "Created")).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PizzaOrder>> GetAllWithSurName(string surName)
        {
            try
            {
                return await context.PizzaOrder.Where(x => x.OrderFor.SurName == surName)
                                                .OrderBy(x => EF.Property<DateTime>(x, "Created")).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PizzaOrderWithDetails>> GetAllWithDetails()
        {
            try
            {
                var result = await context.PizzaOrder.Select(x => new PizzaOrderWithDetails()
                {
                    BaseType = x.BaseType,
                    SauceType = x.SauceType,
                    SizeInCM = x.SizeInCM,
                    Created = EF.Property<DateTime>(x, "Created"),
                    LastModified = EF.Property<DateTime>(x, "LastModified")
                }).ToListAsync();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Save(PizzaOrder item)
        {
            var pizzaOrder = await context.PizzaOrder.FirstAsync(x => x.Id == item.Id);
            pizzaOrder.OrderFor = PersonFullName.Create(item.OrderFor.GivenName, item.OrderFor.SurName);
            await context.SaveChangesAsync();
        }
    }
}