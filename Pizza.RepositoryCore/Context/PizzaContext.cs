using Microsoft.EntityFrameworkCore;
using Pizza.RepositoryCore.Model;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza.RepositoryCore.Context
{
    public class PizzaContext :  BaseContext
    {


        public PizzaContext(DbContextOptions options) : base(options)
        {
        }

        public PizzaContext(AsyncRetryPolicy asyncRetryPolicy) : base(asyncRetryPolicy)
        { }

        public PizzaContext() : base()
        {
        }
      

        public virtual DbSet<PizzaOrder> PizzaOrder { get; set; }


    }
}
