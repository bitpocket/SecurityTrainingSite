using System.ComponentModel.DataAnnotations;

namespace SecurityTrainingSite.ViewModels.Home
{
	public class LinksViewModel
	{
		[Required]
		[Display(Name = "Link")]
		public string UserName { get; set; }
	}
}
