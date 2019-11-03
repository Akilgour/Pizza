using System;

namespace Pizza.Model.Model
{
    public class PizzaOrderStatsDTO
    {
        public Guid Id { get;  set; }
        public string BaseType { get;  set; }
        public string SauceType { get;  set; }
        public int SizeInCM { get;  set; }
        public DateTime Created { get;  set; }
        public DateTime LastModified { get;  set; }
        public string GivenName { get;  set; }
        public string OrderFor_SurName { get;  set; }
        public int TotalOrders { get;  set; }
    }
}