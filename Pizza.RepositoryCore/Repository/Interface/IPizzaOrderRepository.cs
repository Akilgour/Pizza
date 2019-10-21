using Pizza.RepositoryCore.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.RepositoryCore.Repository.Interface
{
    public interface IPizzaOrderRepository
    {
        Task Create(PizzaOrder pizzaOrder);
        Task AddRange(List<PizzaOrder> pizzaOrders);
    }
}