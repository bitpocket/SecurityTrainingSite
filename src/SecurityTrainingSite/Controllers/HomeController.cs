using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using SecurityTrainingSite.ViewModels;

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
