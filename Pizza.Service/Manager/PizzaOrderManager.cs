using Pizza.Model.Model;
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
                pizzaOrders.Add(new PizzaOrder()
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
                SizeInCM = pizzaOrderDTO.SizeInCM,
                OrderFor = new PersonFullName(pizzaOrderDTO.GivenName, pizzaOrderDTO.SurName)                
            };

            await pizzaOrderRepository.Create(pizzaOrder);
        }

        public async Task<List<PizzaOrderDTO>> GetAll()
        {
            var pizzaOrders = await pizzaOrderRepository.GetAll();
            var pizzaOrderDTOs = new List<PizzaOrderDTO>();
            foreach (var item in pizzaOrders)
            {
                pizzaOrderDTOs.Add(new PizzaOrderDTO()
                {
                    SauceType = item.SauceType,
                    BaseType = item.BaseType,
                    SizeInCM = item.SizeInCM
                });
            }
            return pizzaOrderDTOs;
        }

        public async Task<List<PizzaOrderDTO>> GetAllForHarrison()
        {
            var pizzaOrders = await pizzaOrderRepository.GetAllWithSurName("Harrison");
            var pizzaOrderDTOs = new List<PizzaOrderDTO>();
            foreach (var item in pizzaOrders)
            {
                pizzaOrderDTOs.Add(new PizzaOrderDTO()
                {
                    SauceType = item.SauceType,
                    BaseType = item.BaseType,
                    SizeInCM = item.SizeInCM,
                    GivenName = item.OrderFor.GivenName,
                    SurName = item.OrderFor.SurName
                });
            }
            return pizzaOrderDTOs;
        }

        public async Task<List<PizzaOrderWithDetailsDTO>> GetAllWithDetails()
        {
            var pizzaOrders = await pizzaOrderRepository.GetAllWithDetails();
            var PizzaOrderWithDetailsDTOs = new List<PizzaOrderWithDetailsDTO>();
            foreach (var item in pizzaOrders)
            {
                PizzaOrderWithDetailsDTOs.Add(new PizzaOrderWithDetailsDTO()
                {
                    SauceType = item.SauceType,
                    BaseType = item.BaseType,
                    SizeInCM = item.SizeInCM,
                    Created = item.Created,
                    LastModified = item.LastModified
                });
            }
            return PizzaOrderWithDetailsDTOs;
        }

    }
}