using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
