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
        public IActionResult RegistationStep2()
        {
            return View();
        }
		[HttpPost]
		public IActionResult RegistationStep2(AccountAddressDto model)
        {
			return View(model);
		}


        [HttpGet]
		public IActionResult Login()
		{
			return View();
		}
        [HttpPost]
        public IActionResult Registration(AccountDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
		    					
				
            var result = _accountService.Add(model);
			if(!result.Success)
			{
				ViewBag.Error = !string.IsNullOrEmpty(result.Message) ? result.Message : "Реєстрація пройшла не успішно,спробуйте ще разок";
				return View("RegistrationError");
			}

			return RedirectToAction("RegistationStep2");
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
				DoB = new DateTime(2008,08,29)
			};

			var result = _accountService.Add(accountDto);
            return Json("true");
        }
    }

}
