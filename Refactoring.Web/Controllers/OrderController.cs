using Microsoft.AspNetCore.Mvc;
using Refactoring.Web.Services;
using System.Threading.Tasks;
using Refactoring.Web.DomainModels;
using Refactoring.Web.Models;


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
            return View(new OrderFormModel()); // Initialize an empty OrderFormModel
        }

        [HttpPost]
        public async Task<IActionResult> SubmitOrder(OrderFormModel model)
        {
            if (!ModelState.IsValid)
            {
                // Add validation errors to ModelState
                ModelState.AddModelError(string.Empty, "There are validation errors. Please correct them.");
                return RedirectToAction("Index", "Home", model);
            }

            var order = new Order();
            order.District = model.SelectedDistrict;
            order.Total = model.OrderAmount;

            // Use the injected OrderService to process the order
            await _orderService.ProcessOrder(order);
            var completedOrder = _orderService.GetOrder();

            return View("SubmitOrder", completedOrder); // Redirect to a success page
        }
    }
}
