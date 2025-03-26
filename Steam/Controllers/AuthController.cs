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
        public IActionResult Registration(AccountDto model)
        {
			var rsult = _accountService.Add(model);

			return Json(rsult);
        }
        [HttpGet]
		public IActionResult Registration()
		{
			return View();
		}

        [HttpGet]
        public IActionResult TestAdd()
        {
			AccountDto accountDto = new AccountDto()
			{
				FName = "Ruslan",
				LName = "Mihalik",
				UserName = "ruslanchik65@gmail.com",
				Password = "123456709",
				Gender = "Men",
				DoB = new DateTime(2009,08,29)
			};

			var result = _accountService.Add(accountDto);
            return Json("true");
        }
    }

}
