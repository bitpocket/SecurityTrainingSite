using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Authorization;
using SecurityTrainingSite.ViewModels;
using System.Collections.Generic;
using SecurityTrainingSite.ViewModels.Misc;
using SecurityTrainingSite.ViewModels.Pet;

namespace SecurityTrainingSite.Controllers
{
	[Authorize]
	public class MiscController : Controller
	{
		[AllowAnonymous]
		[Route("/Links")]
		public IActionResult Links()
		{
			ViewBag.Links = DataAccessLayer.Secure.GetLinks();
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("/Links")]
		public IActionResult Links(LinksViewModel model)
		{
			if (ModelState.IsValid)
			{
				DataAccessLayer.Unsecure.InsertLink(model.Link);
				ViewBag.Links = DataAccessLayer.Secure.GetLinks();
				ModelState.Clear();
				return View();
			}

			ViewBag.Links = DataAccessLayer.Secure.GetLinks();
			return View(model);
		}
	}
}
