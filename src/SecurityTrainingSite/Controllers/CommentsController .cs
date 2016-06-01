using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using SecurityTrainingSite.ViewModels;

namespace SecurityTrainingSite.Controllers
{
	[Authorize]
	public class CommentsController : Controller
	{
		[AllowAnonymous]
		[Route("/Display1")]
		public IActionResult Display1()
		{
			return View();
		}

		[AllowAnonymous]
		[Route("/Display2")]
		public IActionResult Display2()
		{
			return View();
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
