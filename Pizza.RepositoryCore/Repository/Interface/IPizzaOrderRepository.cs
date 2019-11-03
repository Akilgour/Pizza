using Pizza.RepositoryCore.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.RepositoryCore.Repository.Interface
{
    public interface IPizzaOrderRepository
    {
        Task Create(PizzaOrder pizzaOrder);
        Task AddRange(List<PizzaOrder> pizzaOrders);
        Task<List<PizzaOrder>> GetByBaseType(string baseType);
        Task<List<PizzaOrder>> GetAll();
        Task<List<PizzaOrderWithDetails>> GetAllWithDetails();
        Task<List<PizzaOrder>> GetAllWithSurName(string surName);
        Task Save(PizzaOrder item);
    }
}