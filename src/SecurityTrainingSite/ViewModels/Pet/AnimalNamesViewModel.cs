using System.ComponentModel.DataAnnotations;

namespace SecurityTrainingSite.ViewModels.Pet
{
	public class AnimalNamesViewModel
	{
		[Required]
		[Display(Name = "Animal")]
		public string Animal { get; set; }
	}
}
