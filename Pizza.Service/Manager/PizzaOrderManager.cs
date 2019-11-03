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
                OrderFor = PersonFullName.Create(pizzaOrderDTO.GivenName, pizzaOrderDTO.SurName)
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

        public async Task<List<PizzaOrderWithTimeDTO>> GetAllWithTime()
        {
            var pizzaOrders = await pizzaOrderRepository.GetAllWithTime();
            var pizzaOrderWithTimeDTOs = new List<PizzaOrderWithTimeDTO>();
            foreach (var item in pizzaOrders)
            {
                pizzaOrderWithTimeDTOs.Add(new PizzaOrderWithTimeDTO()
                {
                    SauceType = item.SauceType,
                    BaseType = item.BaseType,
                    SizeInCM = item.SizeInCM,
                    HowOld = item.HowOld,
                    HowOldHours = item.HowOldHours
                });
            }
            return pizzaOrderWithTimeDTOs;
        }

        public async Task<int> GetPizzaOrderCountBySurName(string surName)
        {
            return await pizzaOrderRepository.GetPizzaOrderCountBySurName(surName);
        }

        public async Task<List<PizzaOrderStatsDTO>> GetPizzaOrderStats()
        {
            var pizzaOrders = await pizzaOrderRepository.GetPizzaOrderStats();
            var pizzaOrderStatsDTOs = new List<PizzaOrderStatsDTO>();

            foreach (var item in pizzaOrders)
            {
                pizzaOrderStatsDTOs.Add(new PizzaOrderStatsDTO()
                {
                    SauceType = item.SauceType,
                    BaseType = item.BaseType,
                    SizeInCM = item.SizeInCM,
                    GivenName = item.GivenName,
                    OrderFor_SurName = item.OrderFor_SurName,
                    TotalOrders = item.TotalOrders
                });
            }
            return pizzaOrderStatsDTOs;
        }

        public async Task GiveJohnsToRingos()
        {
            var pizzaOrders = await pizzaOrderRepository.GetAllWithSurName("Lennon");

            foreach (var item in pizzaOrders)
            {
                item.OrderFor = PersonFullName.Create("Ringo", "Starr");

                await pizzaOrderRepository.Save(item);
            }

        }

    }
}