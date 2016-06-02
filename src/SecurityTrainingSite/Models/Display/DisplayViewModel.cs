using System.ComponentModel.DataAnnotations;

namespace SecurityTrainingSite.Models.Display
{
	public class DisplayViewModel
	{
		[Required]
		[Display(Name = "Message")]
		public string Message { get; set; }
	}
}
