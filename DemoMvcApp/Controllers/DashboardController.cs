using BusinessModel.Contracts;
using DemoMvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvcApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IOrderService _orderService;

        public DashboardController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            // Wir koennen den Benutzernamen aus dem HttpContext ermitteln
            string userName = User.Identity.Name ?? "Guest";
            var model = new DashboardViewModel
            {
                UserName = userName,
                CurrentOrder = await _orderService.CurrentOrder(userName)
            };

            return View(model);
        }
    }
}
