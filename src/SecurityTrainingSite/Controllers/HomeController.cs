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
	}
}
