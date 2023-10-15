using Microsoft.AspNetCore.Mvc;
using Refactoring.Web.Services;
using System.Threading.Tasks;
using Refactoring.Web.DomainModels;


namespace Refactoring.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitOrder(string selectedDistrict, decimal orderAmount)
        {
            var order = new Order();
            order.District = selectedDistrict;
            order.Total = orderAmount;

            // Use the injected OrderService to process the order
            await _orderService.ProcessOrder(order);
            var completedOrder = _orderService.GetOrder();

            return View(completedOrder);
        }
    }
}
