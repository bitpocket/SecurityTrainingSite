using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Http.Authentication;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using SecurityTrainingSite.ViewModels.Account;

namespace SecurityTrainingSite.Controllers
{
	[Authorize]
	public class AccountController : Controller
	{
		[AllowAnonymous]
		public IActionResult Login(string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			return View();
		}


		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			if (ModelState.IsValid)
			{
				DataAccessLayer.User u = DataAccessLayer.SQLHelper.LogIn(model.UserName, model.Password);
				if (u.CredentialsCorrect)
				{

					List<Claim> userClaims = new List<Claim>
						{
							new Claim(ClaimTypes.NameIdentifier, u.UserId.ToString()),
							new Claim(ClaimTypes.Name, u.Username),
						};

					ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity(userClaims, "local"));
					await HttpContext.Authentication.SignInAsync("CookieAuth", principal);
					return RedirectToLocal(returnUrl);
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Invalid login attempt.");
					return View(model);
				}
			}

			return View(model);
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> LogOff()
		{
			await HttpContext.Authentication.SignOutAsync("CookieAuth");
			return RedirectToAction(nameof(HomeController.Index), "Home");
		}

		private IActionResult RedirectToLocal(string returnUrl)
		{
			if (Url.IsLocalUrl(returnUrl))
			{
				return Redirect(returnUrl);
			}
			else
			{
				return RedirectToAction(nameof(HomeController.Index), "Home");
			}
		}
	}
}
