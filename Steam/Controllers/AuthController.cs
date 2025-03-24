using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Models.Accounts;
using Services.Interfaces;
using Steam.WebApp.Models;

namespace Steam.WebApp.Controllers
{
	public class AuthController : Controller
	{
		private readonly IAccountService _accountService;

		public AuthController(IAccountService accountService)
		{
			_accountService = accountService;
		}

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
        [HttpGet]
        public IActionResult TestAdd()
        {
			AccountDto accountDto = new AccountDto()
			{
				FName = "Ruslan",
				LName = "Mihalik",
				UserName = "mihalikr65@gmail.com",
				Password = "123456709",
				Gender = "Men",
				DoB = new DateTime(2009,08,29)
			};

			var result = _accountService.Add(accountDto);
            return Json("true");
        }
    }

}
