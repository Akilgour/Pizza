using Pizza.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Interface.Service
{
    public interface IPizzaOrderService
    {
        Task AddOrder(PizzaOrderDTO pizzaOrder);
        Task AddMultipleOrder(List<PizzaOrderDTO> list);
        Task<List<PizzaOrderDTO>> GetAll();
        Task<List<PizzaOrderWithDetailsDTO>> GetAllWithDetails();
    }
}
