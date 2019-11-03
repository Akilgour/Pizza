using Pizza.Model.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Interface.Service
{
    public interface IPizzaOrderService
    {
        Task AddOrder(PizzaOrderDTO pizzaOrder);

        Task AddMultipleOrder(List<PizzaOrderDTO> list);

        Task<List<PizzaOrderDTO>> GetAll();

        Task<List<PizzaOrderWithDetailsDTO>> GetAllWithDetails();

        Task<List<PizzaOrderDTO>> GetAllForHarrison();

        Task GiveJohnsToRingos();

        Task<int> GetPizzaOrderCountBySurName(string surName);
    }
}