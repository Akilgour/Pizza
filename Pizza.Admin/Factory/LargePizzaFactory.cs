using Pizza.Constants.Pizza;
using Pizza.Model.Model;

namespace Pizza.Admin.Factory
{
    public class LargePizzaFactory
    {
        public static PizzaOrderDTO Create()
        {
            return new PizzaOrderDTO() { BaseType = PizzaBaseType.Thick, SauceType = PizzaSauceType.Tommato, SizeInCM = 34 };
        }
    }
}