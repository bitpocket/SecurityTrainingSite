using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace SecurityTrainingSite.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}

		[AllowAnonymous]
		public IActionResult Links()
		{
			ViewData["Message"] = "Links page.";

			return View();
		}
	}
}
