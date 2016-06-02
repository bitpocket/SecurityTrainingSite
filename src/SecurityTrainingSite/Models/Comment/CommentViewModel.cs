using System.ComponentModel.DataAnnotations;

namespace SecurityTrainingSite.Models.Comment
{
	public class CommentViewModel
	{
		[Required]
		[Display(Name = "Comment")]
		public string Comment { get; set; }
	}
}
