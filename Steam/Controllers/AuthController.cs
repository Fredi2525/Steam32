using System.Security.Claims;
using Entities.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        public IActionResult RegistationStep2(Guid accountId )
        {
            var model = new AccountAddressDto()
            {
                AccountId = accountId
            };

            return View(model);
        }
		[HttpPost]
		public IActionResult RegistationStep2(AccountAddressDto model)
        {
			if (!ModelState.IsValid)
			{
				return View(model);
			}
            var result = _accountService.Add(model);
            if (!result.Success)
            {
                ViewBag.Error = !string.IsNullOrEmpty(result.Message) ? result.Message : "Реєстрація пройшла не успішно,спробуйте ще разок";
                return View("RegistrationError");
            }
			return RedirectToAction("Login");
        }


        [HttpGet]
		public IActionResult Login()
		{
			return View();
		}
        [HttpPost]
		public IActionResult login(LoginModel model)
		{
			var result = _accountService.GetAccountByUserNameAndPassword(model.Email, model.Password);
			if (result.Success)
			{
				Authenticate(result.Data).Wait();
				return RedirectToAction("Index", "Home");
			}

			return View();

		}
		public IActionResult Logout()
		{
			HttpContext.SignOutAsync().Wait();
			return RedirectToAction("Login", "Auth");
		}
		private async Task Authenticate(AccountDto account)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, account.UserName ),
				new Claim("FullName", $"{account.FName} {account.LName}"),
				new Claim(ClaimTypes.Role, account.Role.ToString()),
				new Claim(ClaimTypes.NameIdentifier, account.Id.ToString())

			};
			ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie"
				, ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme
				, new ClaimsPrincipal(id)); 
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
			return RedirectToAction("Login");

			return RedirectToAction("RegistationStep2",new { accountId = result.Data.Id });
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
