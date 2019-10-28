using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Pizza.RepositoryCore.Context;
using Pizza.RepositoryCore.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.RepositoryCore.Repository
{
    [TestFixture]
    public class PizzaOrderRepositoryTest
    {

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<PizzaContext>()
           .UseInMemoryDatabase("InMemoryDatabase").Options;
            var context = new PizzaContext(options);

            context.PizzaOrder.Add(new Model.PizzaOrder() { BaseType = "thick" });
            context.PizzaOrder.Add(new Model.PizzaOrder() { BaseType = "thick" });
            context.PizzaOrder.Add(new Model.PizzaOrder() { BaseType = "thick" });
            context.PizzaOrder.Add(new Model.PizzaOrder() { BaseType = "thin" });
            context.PizzaOrder.Add(new Model.PizzaOrder() { BaseType = "thin" });
            context.SaveChanges();
        }

        [TestCase("thick", 3)]
        [TestCase("thin", 2)]
        [TestCase("none", 0)]
        public async Task GetByBaseTypeAsync(string baseType, int expected)
        {
            //arrange
            var options = new DbContextOptionsBuilder<PizzaContext>()
            .UseInMemoryDatabase("InMemoryDatabase").Options;
            var context = new PizzaContext(options);
            var pizzaOrderRepository = new PizzaOrderRepository(context);
            //act
            var value = await pizzaOrderRepository.GetByBaseType(baseType);
            //assert
            Assert.AreEqual(expected, value.Count());
        }
    }
}
