using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Http.Internal;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity.Design.Internal;
using SecurityTrainingSite.ViewModels;
using SecurityTrainingSite.ViewModels.Display;

namespace SecurityTrainingSite.Controllers
{
	[Authorize]
	public class DisplayController : Controller
	{
		[AllowAnonymous]
		[Route("/Display1")]
		public IActionResult Display1()
		{
			ViewBag.messageFromQuery = Request.Query["message"];
			return View();
		}
		[AllowAnonymous]
		[HttpPost]
		[Route("/Display1")]
		public IActionResult Display1(DisplayViewModel model, string submit)
		{
			if (ModelState.IsValid)
			{
				if (submit == "Post")
				{
					ViewBag.Message = model.Message;
					ViewBag.messageFromQuery = Request.Query["message"];

					ModelState.Clear();
					model.Message = "";

					return View();
				}

				if (submit == "Get")
				{
					return RedirectToAction("Display1", "Display", new { message = model.Message });
				}
			}

			return View(model);
		}

		[AllowAnonymous]
		[Route("/Display2")]
		public IActionResult Display2()
		{
			ViewBag.messageFromQuery = Request.Query["message"];
			return View();
		}
		[AllowAnonymous]
		[HttpPost]
		[Route("/Display2")]
		public IActionResult Display2(DisplayViewModel model, string submit)
		{
			if (ModelState.IsValid)
			{
				if (submit == "Post")
				{
					ViewBag.Message = model.Message;
					ViewBag.messageFromQuery = Request.Query["message"];

					ModelState.Clear();
					model.Message = "";

					return View();
				}

				if (submit == "Get")
				{
					return RedirectToAction("Display2", "Display", new { message = model.Message });
				}
			}

			return View(model);
		}

		[AllowAnonymous]
		[Route("/SCRF1")]
		public IActionResult SCRF1()
		{
			return View();
		}

		[AllowAnonymous]
		[Route("/SCRF2")]
		public IActionResult SCRF2()
		{
			return View();
		}
	}
}
