using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecurityTrainingSite.Models.Pet
{
	public class AddPetViewModel
	{
		[Required]
		[Display(Name = "Animal")]
		public string Animal { get; set; }

		public SelectList Animals { get; set; }

		[Required]
		[Display(Name = "Name")]
		public string Name { get; set; }
	}
}
