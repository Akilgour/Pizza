using System;

namespace Pizza.Model.Model
{
    public class PizzaOrderWithTimeDTO
    {
        public string BaseType { get; set; }
        public string SauceType { get; set; }
        public int SizeInCM { get; set; }
      
        public double HowOld { get; set; }

        public int HowOldHours { get; set; }
    }
}