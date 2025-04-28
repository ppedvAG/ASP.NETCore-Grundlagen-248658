using BusinessModel.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvcApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IRecipeService _recipeService;

        public string UserName => User.Identity.Name ?? "Guest";

        public OrdersController(IOrderService orderService, IRecipeService recipeService)
        {
            _orderService = orderService;
            _recipeService = recipeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Order(long recipeId, int quantity)
        {
            var recipe = await _recipeService.GetById(recipeId);
            await _orderService.AddOrderItem(UserName, recipe, quantity);

            return RedirectToAction("Index", "Recipes");
        }

        [HttpPost]
        public async Task<IActionResult> Done(IFormCollection form)
        {
            await _orderService.FinishOrder(UserName);

            return RedirectToAction("Index", "Dashboard");
        }
    }
}
