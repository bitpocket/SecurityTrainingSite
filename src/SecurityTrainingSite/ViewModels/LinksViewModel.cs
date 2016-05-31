using System.ComponentModel.DataAnnotations;

namespace SecurityTrainingSite.ViewModels
{
	public class LinksViewModel
	{
		[Required]
		[Display(Name = "Link")]
		public string Link { get; set; }
	}
}
