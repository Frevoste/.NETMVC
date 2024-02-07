using Hotels.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hotels.Controllers
{
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

        public IActionResult Pi()
        {
            return View();
        }
        public IActionResult NoAccess()
        {
            return View();
        }

        public IActionResult About()
        {
            var model = new About()
            {
                Title = "Hotels application",
                Description = "This app is created to view list of Hotels that we recommend. To add Your own hotel You first have to get Owner permissions. Only owner can edit his own Hotel, Admin can edit everyone hotel.",
                Tags = new List<string>() { "hotels", "cheap", "luxury" }

            };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
