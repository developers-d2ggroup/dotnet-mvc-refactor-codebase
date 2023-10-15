using Refactoring.Web.DomainModels;
using System.Threading.Tasks;

namespace Refactoring.Web.Services
{
    public interface IOrderService
    {
        Task ProcessOrder(Order order);
        Order GetOrder();
    }
}