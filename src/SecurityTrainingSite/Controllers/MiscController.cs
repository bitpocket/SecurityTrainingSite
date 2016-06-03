using System;
using System.IdentityModel.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SecurityTrainingSite.Models.Misc;
using DataAccessLayer.Models;

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

		[Authorize(Roles = "SuperAdmin")]
		[Route("/Options")]
		public IActionResult Options(string submit)
		{
			if (submit == "Clear Links")
			{
				DataAccessLayer.Secure.ClearLinks();
			}

			if (submit == "Clear Pets")
			{
				DataAccessLayer.Secure.ClearPets();
			}

			if (submit == "Clear Comments")
			{
				DataAccessLayer.Secure.ClearComments();
			}

			ViewBag.AppVersion = typeof(Startup).Assembly.GetName().Version.ToString();

			return View();
		}
	}
}
