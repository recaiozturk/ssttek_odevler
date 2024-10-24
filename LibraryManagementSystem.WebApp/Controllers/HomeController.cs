
using LibraryManagementSystem.WebApp.Filters;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.WebApp.Controllers
{
    [ServiceFilter(typeof(StartFinishLogActionFilter))]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult CustomError(string message=null)
        {
            ViewBag.ErrorMessage = message;
            return View();
        }

    }
}
