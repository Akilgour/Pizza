using NUnit.Framework;
using Pizza.RepositoryCore.Context;
using Pizza.RepositoryCore.Test;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.RepositoryCore.Repository
{
    [TestFixture]
    public class PizzaOrderRepositoryTest
    {
        [TestCase("thick", 3)]
        [TestCase("thin", 2)]
        [TestCase("none", 0)]
        public async Task GetByBaseTypeAsync(string baseType, int expected)
        {
            //arrange
            var option = DbContextOptionsBuilderFactory.Create();
            var arrangeContext = new PizzaContext(option);

            arrangeContext.PizzaOrders.Add(new Model.PizzaOrder() { BaseType = "thick" });
            arrangeContext.PizzaOrders.Add(new Model.PizzaOrder() { BaseType = "thick" });
            arrangeContext.PizzaOrders.Add(new Model.PizzaOrder() { BaseType = "thick" });
            arrangeContext.PizzaOrders.Add(new Model.PizzaOrder() { BaseType = "thin" });
            arrangeContext.PizzaOrders.Add(new Model.PizzaOrder() { BaseType = "thin" });
            arrangeContext.SaveChanges();

            var context = new PizzaContext(option);
            var pizzaOrderRepository = new PizzaOrderRepository(context);
            //act
            var value = await pizzaOrderRepository.GetByBaseType(baseType);
            //assert
            Assert.AreEqual(expected, value.Count());
        }
    }
}