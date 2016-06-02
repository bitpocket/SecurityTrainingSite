using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecurityTrainingSite.Models.Comment;
using Microsoft.AspNetCore.Identity;
using SecurityTrainingSite.Models;

namespace SecurityTrainingSite.Controllers
{
	public class CommentController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public CommentController(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}

		[Authorize]
		[Route("/CSRF1")]
		public IActionResult CSRF1()
		{
			return View();
		}

		[Authorize]
		[HttpPost]
		[Route("/CSRF1")]
		public IActionResult CSRF1(CommentViewModel model)
		{
			if (ModelState.IsValid)
			{
				var userId = _userManager.GetUserId(User);

				DataAccessLayer.Unsecure.AddComment(model.Comment, userId);
				ModelState.Clear();
				model.Comment = "";
				return View(model);
			}

			return View(model);
		}

		[Authorize]
		[Route("/CSRF2")]
		public IActionResult CSRF2()
		{
			return View();
		}

		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("/CSRF2")]
		public IActionResult CSRF2(CommentViewModel model)
		{
			if (ModelState.IsValid)
			{
				var userId = _userManager.GetUserId(User);

				DataAccessLayer.Unsecure.AddComment(model.Comment, userId);
				ModelState.Clear();
				model.Comment = "";
				return View(model);
			}

			return View(model);
		}

		[Authorize]
		[Route("/ShowComments")]
		public IActionResult ShowComments()
		{
			var userId = _userManager.GetUserId(User);

			ViewBag.Comments = DataAccessLayer.Unsecure.GetComments(userId);
			
			return View();
		}
	}
}
