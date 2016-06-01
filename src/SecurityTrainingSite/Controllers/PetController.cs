using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Authorization;
using SecurityTrainingSite.ViewModels;
using System.Collections.Generic;

namespace SecurityTrainingSite.Controllers
{
	[Authorize]
	public class PetController : Controller
	{
		private readonly List<string> _animals = new[] { "Dog", "Cat", "Frog" }.ToList();

		[AllowAnonymous]
		[Route("/Add1")]
		public IActionResult Add1()
		{
			var model = new AddPetViewModel()
			{
				Name = "",
				Animals = new SelectList(_animals)
			};

			return View(model);
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("/Add1")]
		public IActionResult Add1(AddPetViewModel model)
		{
			if (ModelState.IsValid)
			{
				DataAccessLayer.Unsecure.AddPet(model.Animal, model.Name);
				ViewBag.ConfirmationOfAdd = $"You've added \"{model.Animal}\" named \"{model.Name}\"";

				ModelState.Clear();
				model.Name = "";
				model.Animals = new SelectList(_animals);

				return View(model);
			}

			return View(model);
		}

		[AllowAnonymous]
		[Route("/Add2")]
		public IActionResult Add2()
		{
			var model = new AddPetViewModel()
			{
				Name = "",
				Animals = new SelectList(_animals)
			};

			return View(model);
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("/Add2")]
		public IActionResult Add2(AddPetViewModel model)
		{
			if (ModelState.IsValid)
			{
				DataAccessLayer.Unsecure.AddPet(model.Animal, model.Name);
				ViewBag.ConfirmationOfAdd = $"You've added \"{model.Animal}\" named \"{model.Name}\"";

				ModelState.Clear();
				model.Name = "";
				model.Animals = new SelectList(_animals);

				return View(model);
			}

			return View(model);
		}

		[AllowAnonymous]
		[Route("/Count1")]
		public IActionResult Count1()
		{
			ViewBag.PetCounters = DataAccessLayer.Unsecure.GetPetCounters();
			return View();
		}

		[AllowAnonymous]
		[Route("/Count2")]
		public IActionResult Count2()
		{
			ViewBag.PetCounters = DataAccessLayer.Unsecure.GetPetCounters();
			return View();
		}
	}
}
