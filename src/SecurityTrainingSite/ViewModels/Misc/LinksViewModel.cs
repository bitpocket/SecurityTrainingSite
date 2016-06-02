using System.ComponentModel.DataAnnotations;

namespace SecurityTrainingSite.ViewModels.Misc
{
	public class LinksViewModel
	{
		[Required]
		[Display(Name = "Link")]
		public string Link { get; set; }
	}
}
