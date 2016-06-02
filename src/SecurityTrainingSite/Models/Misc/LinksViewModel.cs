using System.ComponentModel.DataAnnotations;

namespace SecurityTrainingSite.Models.Misc
{
	public class LinksViewModel
	{
		[Required]
		[Display(Name = "Link")]
		public string Link { get; set; }
	}
}
