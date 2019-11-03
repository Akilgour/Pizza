using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza.RepositoryCore.Model
{
    //This is not a entity in the DB
    public class PizzaOrderWithTime
    {
        public string BaseType { get; set; }
        public string SauceType { get; set; }
        public int SizeInCM { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime Created { get; set; }
        public double HowOld { get; set; }
        public int HowOldHours { get; internal set; }
    }
}
