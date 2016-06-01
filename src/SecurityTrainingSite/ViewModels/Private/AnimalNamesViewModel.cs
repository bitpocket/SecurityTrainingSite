using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityTrainingSite.ViewModels.Private
{
	public class AnimalNamesViewModel
	{
		[Required]
		[Display(Name = "Animal")]
		public string Animal { get; set; }
	}
}
