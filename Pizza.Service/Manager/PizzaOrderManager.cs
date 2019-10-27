﻿using Pizza.Model.Model;
using Pizza.RepositoryCore.Model;
using Pizza.RepositoryCore.Repository.Interface;
using Pizza.Service.Manager.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Service.Manager
{
    public class PizzaOrderManager : IPizzaOrderManager
    {
        private readonly IPizzaOrderRepository pizzaOrderRepository;

        public PizzaOrderManager(IPizzaOrderRepository pizzaOrderRepository)
        {
            this.pizzaOrderRepository = pizzaOrderRepository;
        }

        public async Task AddMultipleOrder(List<PizzaOrderDTO> pizzaOrderDTOs)
        {
            var pizzaOrders = new List<PizzaOrder>();
            //TODO Use automapper, that still need to be set up
            foreach (var item in pizzaOrderDTOs)
            {
                pizzaOrders.Add( new PizzaOrder()
                {
                    SauceType = item.SauceType,
                    BaseType = item.BaseType,
                    SizeInCM = item.SizeInCM
                });
            }

            await pizzaOrderRepository.AddRange(pizzaOrders);
        }

        public async Task AddOrder(PizzaOrderDTO pizzaOrderDTO)
        {
            //TODO Use automapper, that still need to be set up
            var pizzaOrder = new PizzaOrder()
            {
                SauceType = pizzaOrderDTO.SauceType,
                BaseType = pizzaOrderDTO.BaseType,
                SizeInCM = pizzaOrderDTO.SizeInCM
            };

            await pizzaOrderRepository.Create(pizzaOrder);
        }
    }
}