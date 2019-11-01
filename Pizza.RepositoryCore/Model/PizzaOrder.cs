using System;

namespace Pizza.RepositoryCore.Model
{
    public class PizzaOrder
    {
       public Guid Id { get; set; }

        public string BaseType { get; set; }
      
        public string SauceType { get; set; }

        public int SizeInCM { get; set; }
    }
}