using Microsoft.EntityFrameworkCore;
using Pizza.RepositoryCore.Model;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.RepositoryCore.Context
{
    public abstract class BaseContext : DbContext
    {
        private readonly AsyncRetryPolicy _asyncRetryPolicy;
        

        public BaseContext(AsyncRetryPolicy asyncRetryPolicy)
        {
            _asyncRetryPolicy = asyncRetryPolicy;
        }

        protected BaseContext(DbContextOptions options) : base(options)
        {
           
        }

        protected BaseContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Pizza;  Trusted_Connection=Yes;");

                //The EF log will have the save values.
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                //If not a type of view, add DateTime LastModified and Created
                if (entityType.ClrType.BaseType != typeof(DbView))
                {
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("LastModified");
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("Created");
                }
            }

             modelBuilder.Entity<PizzaOrder>().OwnsOne(x => x.OrderFor).Property(x => x.GivenName).HasColumnName("GivenName");
             modelBuilder.Query<PizzaOrderStats>().ToView("PizzaOrderStats");
        }

        /// <summary>
        /// Sets the default properties of the business object and adds it
        /// to the EF <see cref="DbSet"/>.
        /// </summary>
        /// <typeparam name="T">The business object type.</typeparam>
        /// <param name="entity">The entity to be added.</param>
        /// <returns>The updated entity.</returns>
        //public T Create<T>(T entity) where T : BaseModel
        //{
        //    if (entity.Id == Guid.Empty)
        //    {
        //        entity.Id = Guid.NewGuid();
        //    }

        //    Set<T>().Add(entity);
        //    return entity;
        //}

        //public async void AddRange<T>(IEnumerable<T> entity) where T : BaseModel
        //{
        //    foreach (var item in entity)
        //    {
        //        item.Id = Guid.NewGuid();
        //    }
        //    await Set<T>().AddRangeAsync(entity);
        //}

        /// <summary>
        /// Removes the specified <paramref name="entity"/> from its EF <see cref="DbSet"/>.
        /// </summary>
        /// <typeparam name="T">The type of business object to delete.</typeparam>
        /// <param name="entity">The entity to delete.</param>
        //public virtual void Delete<T>(T entity) where T : BaseModel
        //{
        //    if (Entry(entity).State == EntityState.Detached)
        //    {
        //        Set<T>().Attach(entity);
        //    }

        //    Set<T>().Remove(entity);
        //}

        /// <summary>
        /// Sets the <paramref name="entity"/> as updated, and attaches it to the context if it is detached.
        /// </summary>
        /// <typeparam name="T">The type of business object to update.</typeparam>
        /// <param name="entity">The entity to update.</param>
        //public void Update<T>(T entity) where T : BaseModel
        //{
        //    if (entity.Id == Guid.Empty)
        //    {
        //        throw new InvalidOperationException("Entity is not persisted yet --> create it first");
        //    }
        //    // Set the Last Updated On time to now
        //    entity.LastModifiedDate = DateTime.UtcNow;

        //    if (Entry(entity).State == EntityState.Detached)
        //    {
        //        //This is when the object has been detached from EF (by passing through automapper) and needs to get
        //        //reattached.  It will set the created date and to what is in the DB.
        //        //Have to load the orriganal object so we can get the the dbs created data
        //        var orig = Set<T>().First(x => x.Id == entity.Id);
        //        entity.CreatedDate = orig.CreatedDate;
        //        Set<T>().Update(entity);
        //    }
        //}

        /// <summary>
        /// Saves the changes to the database.
        /// </summary>
        public async Task SaveChangesAsync()
        {
            ChangeTracker.DetectChanges();
            //Setting a var so the date time is the same for create and update on brand new items
            var now = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added ||
             e.State== EntityState.Modified))
            {
                entry.Property("LastModified").CurrentValue = now;
            }

            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added ))
            {
                entry.Property("Created").CurrentValue = now ;
            }
            //TODO Add polly
            //   await _asyncRetryPolicy.ExecuteAsync(async () =>
            //   {
            await base.SaveChangesAsync();
            //    });


        }

        public void SaveSync()
        {
            base.SaveChanges();
        }


    }
}
