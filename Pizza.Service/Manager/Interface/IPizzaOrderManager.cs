﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizza.Model.Model;

namespace Pizza.Service.Manager.Interface
{
    public interface IPizzaOrderManager
    {
        Task AddOrder(PizzaOrderDTO pizzaOrder);
        Task AddMultipleOrder(List<PizzaOrderDTO> pizzaOrderDTOs);
    }
}