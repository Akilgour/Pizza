using Pizza.RepositoryCore.Model;
using System.Threading.Tasks;

namespace Pizza.RepositoryCore.Repository.Interface
{
    public interface IPizzaOrderRepository
    {
        Task Create(PizzaOrder pizzaOrder);
    }
}