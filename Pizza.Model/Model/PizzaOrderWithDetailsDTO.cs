using System;

namespace Pizza.Model.Model
{
    public class PizzaOrderWithDetailsDTO
    {
        public string BaseType { get; set; }
        public string SauceType { get; set; }
        public int SizeInCM { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime Created { get; set; }
    }
}