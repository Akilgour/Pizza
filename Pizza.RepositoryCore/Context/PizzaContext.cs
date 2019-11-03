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
      

        public virtual DbSet<PizzaOrder> PizzaOrders { get; set; }
        public virtual DbQuery<PizzaOrderStats> PizzaOrderStats { get; set; }


        [DbFunction(Schema = "dbo")]
        public static int PizzaOrderCountBySurName(string surName)
        {
            throw new Exception("This will get thrown if someone trys to call it as a method, but not if called from linq");
        }
    }
}
