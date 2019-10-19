﻿using Pizza.Repository.Model;

namespace Pizza.RepositoryCore.Model
{
    public class PizzaOrder : BaseModel
    {
        public string BaseType { get; set; }
      
        public string SauceType { get; set; }

        public int SizeInCM { get; set; }
    }
}