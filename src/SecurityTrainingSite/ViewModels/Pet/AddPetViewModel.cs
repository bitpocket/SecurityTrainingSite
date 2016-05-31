using Microsoft.AspNet.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SecurityTrainingSite.ViewModels
{
	public class AddPetViewModel
	{
		[Required]
		[Display(Name = "Animal")]
		public string Animal { get; set; }

		//[Required]
		//[Display(Name = "Animal")]
		public SelectList Animals { get; set; }

		[Required]
		[Display(Name = "Name")]
		public string Name { get; set; }
	}
}
