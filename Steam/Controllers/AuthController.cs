using Microsoft.AspNetCore.Mvc;
using Steam.Models;

namespace Steam.Controllers
{
	public class AuthController : Controller
	{
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}		
		[HttpPost]
		public IActionResult Login(LoginModel model)
		{
			return Json("true");
		}
	}
}
