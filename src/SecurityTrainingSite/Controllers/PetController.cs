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
				ViewBag.ConfirmationOfAdd = $"pet inserted {{animal: \"{model.Animal}\", name: \"{model.Name}\"}} ";

				var model2 = new AddPetViewModel()
				{
					Name = "",
					Animals = new SelectList(_animals)
				};

				return View(model2);
			}

			return View(model);
		}
	}
}