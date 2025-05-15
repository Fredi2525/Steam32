using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Steam.WebApp.Models;

namespace Steam.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string id)
        {
            var currentUser = User;
	        var oihjk = $"This is ID: {id}";
            return View();
        }

        public IActionResult Privacy()
        {
            var currentUser = User;
            return View();
        }

        public IActionResult HelloPage()
        {
	        return View();
        }

        public IActionResult Hello()
        {
	        return View("HelloPage");
        }

        [Route("/truhaha/kdsghfjkdhkjf/2234723/route-path")]
        public IActionResult Route()
        {
	        return View("HelloPage");
        }


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
