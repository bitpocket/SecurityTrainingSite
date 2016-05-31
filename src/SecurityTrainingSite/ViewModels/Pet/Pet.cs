using System.ComponentModel.DataAnnotations;

namespace SecurityTrainingSite.ViewModels
{
	public class AddPetViewModel
	{
		[Required]
		[Display(Name = "Kind")]
		public string Kind { get; set; }

		[Required]
		[Display(Name = "Name")]
		public string Name { get; set; }
	}
}
