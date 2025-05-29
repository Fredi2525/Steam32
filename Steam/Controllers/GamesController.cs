using Microsoft.AspNetCore.Mvc;
using Models.Accounts;
using Services;
using Services.Interfaces;

namespace Steam.WebApp.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGameService _gameService;
        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GameAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GameAdd(GameDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _gameService.Add(model);
            if (!result.Success)
            {
                ViewBag.Error = !string.IsNullOrEmpty(result.Message) ? result.Message : "Реєстрація пройшла не успішно,спробуйте ще разок";
                return View("RegistrationError");
            }
            return RedirectToAction("Home");

        }
    }
}
