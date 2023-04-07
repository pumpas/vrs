using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
	/// Model for 'Marke' entity.
	/// </summary>
	public class DoctorsListVM
	{
		[DisplayName("DocId")]
		public int DocId { get; set; }

		[DisplayName("DocName")]
		[Required]
		public string DocName { get; set; }

		[DisplayName("DocQualification")]
		public int DocQualification { get; set; }

		[DisplayName("DocEmail")]
		[Required]
		public string DocEmail { get; set; }

		[DisplayName("DocPassword")]
		[Required]
		public string DocPassword { get; set; }

		[DisplayName("DocField")]
		[Required]
		public string DocField { get; set; }


	}
}