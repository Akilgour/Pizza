using Microsoft.EntityFrameworkCore;
using Pizza.RepositoryCore.Model;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza.RepositoryCore.Context
{
    public class PizzaContext : BaseContext
    {

        public PizzaContext(AsyncRetryPolicy asyncRetryPolicy) : base(asyncRetryPolicy)
        { }

        [Obsolete("The is only here so EF has a parameterless constuctor, DO NOT USE for anything else.", true)]
        public PizzaContext() : base(null)
        { }


        public virtual DbSet<PizzaOrder> PizzaOrder { get; set; }
    }
}
