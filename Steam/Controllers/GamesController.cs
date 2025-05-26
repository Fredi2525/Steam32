using Microsoft.AspNetCore.Mvc;

namespace Steam.WebApp.Controllers
{
    public class GamesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
