namespace Pizza.Model.Model
{
    public class PizzaOrderDTO : BaseModel
    {
        public string BaseType { get; set; }

        public string SauceType { get; set; }

        public int SizeInCM { get; set; }
    }
}