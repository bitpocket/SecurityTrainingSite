using System.ComponentModel.DataAnnotations;

namespace SecurityTrainingSite.Models.Pet
{
	public class AnimalNamesViewModel
	{
		[Required]
		[Display(Name = "Animal")]
		public string Animal { get; set; }
	}
}
