using Pizza.Constants.Pizza;
using Pizza.Model.Model;

namespace Pizza.Admin.Factory
{
    public class SmallPizzaFactory
    {
        public static PizzaOrderDTO Create()
        {
            return new PizzaOrderDTO() { 
                BaseType = PizzaBaseType.Thin,
                SauceType = PizzaSauceType.Tommato, 
                SizeInCM = 24,
                GivenName = "George",
                SurName = "Harrison"
            };
        }
    }
}