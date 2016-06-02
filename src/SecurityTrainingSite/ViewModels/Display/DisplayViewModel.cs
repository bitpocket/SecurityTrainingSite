using System.ComponentModel.DataAnnotations;

namespace SecurityTrainingSite.ViewModels.Display
{
	public class DisplayViewModel
	{
		[Required]
		[Display(Name = "Message")]
		public string Message { get; set; }
	}
}
