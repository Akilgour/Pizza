using Microsoft.EntityFrameworkCore;
using Pizza.RepositoryCore.Context;
using System;

namespace Pizza.RepositoryCore.Test
{
    public class DbContextOptionsBuilderFactory
    {
        public static DbContextOptions Create() => new DbContextOptionsBuilder<PizzaContext>()
                        .UseInMemoryDatabase("InMemoryDatabase" + Guid.NewGuid()).Options;
    }
}