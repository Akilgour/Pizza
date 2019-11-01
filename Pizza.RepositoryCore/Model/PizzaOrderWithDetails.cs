using System;

namespace Pizza.RepositoryCore.Model
{
    //This is not a entity in the DB
    public class PizzaOrderWithDetails
    {
        public string BaseType { get; set; }
        public string SauceType { get; set; }
        public int SizeInCM { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime Created { get; set; }
    }
}