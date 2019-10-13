using Microsoft.EntityFrameworkCore;
using Pizza.Repository.Model;
using Polly.Retry;
using System;
using System.Collections.Generic;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Pizza;  Trusted_Connection=Yes;");
        }

        /// <summary>
        /// Sets the default properties of the business object and adds it
        /// to the EF <see cref="DbSet"/>.
        /// </summary>
        /// <typeparam name="T">The business object type.</typeparam>
        /// <param name="entity">The entity to be added.</param>
        /// <returns>The updated entity.</returns>
        public T Create<T>(T entity) where T : BaseModel
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }

            entity.LastModifiedDate = DateTime.UtcNow;
            entity.CreatedDate = DateTime.UtcNow;

            Set<T>().Add(entity);

            return entity;
        }

        /// <summary>
        /// Removes the specified <paramref name="entity"/> from its EF <see cref="DbSet"/>.
        /// </summary>
        /// <typeparam name="T">The type of business object to delete.</typeparam>
        /// <param name="entity">The entity to delete.</param>
        public virtual void Delete<T>(T entity) where T : BaseModel
        {
            if (Entry(entity).State == EntityState.Detached)
            {
                Set<T>().Attach(entity);
            }

            Set<T>().Remove(entity);
        }

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
        public async Task Save()
        {

            await _asyncRetryPolicy.ExecuteAsync(async () =>
            {
                return await SaveChangesAsync();
            });


        }

        public void SaveSync()
        {
            SaveChanges();
        }


    }
}
