using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using SecurityTrainingSite.ViewModels;
using SecurityTrainingSite.ViewModels.Private;

namespace SecurityTrainingSite.Controllers
{
	[Authorize]
	public class PrivateController : Controller
	{
		[AllowAnonymous]
		[Route("/Private1")]
		public IActionResult Private1()
		{
			return View();
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("/Private1")]
		public IActionResult Private1(AnimalNamesViewModel model)
		{
			if (ModelState.IsValid)
			{
				ViewBag.AnimalNames = DataAccessLayer.Unsecure.GetPetsNames(model.Animal);

			}

			return View(model);
		}
	}
}
