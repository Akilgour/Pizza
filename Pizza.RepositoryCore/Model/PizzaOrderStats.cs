using System;

namespace Pizza.RepositoryCore.Model
{
    public class PizzaOrderStats : DbView
    {
        public Guid Id { get; private set; }
        public string BaseType { get; private set; }
        public string SauceType { get; private set; }
        public int SizeInCM { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime LastModified { get; private set; }
        public string GivenName { get; private set; }
        public string OrderFor_SurName { get; private set; }
        public int TotalOrders { get; private set; }
    }
}