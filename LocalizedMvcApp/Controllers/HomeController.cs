using LocalizedMvcApp.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using System.Globalization;

namespace LocalizedMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            return View(new HomeViewModel 
            { 
                Greeting = _localizer["Greeting"] 
            });
        }

        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            var value = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture));
            var options = new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) };
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, value, options);

            return LocalRedirect(returnUrl);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
