using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
	/// Model for 'Marke' entity.
	/// </summary>
	public class Appointments
	{
		[DisplayName("Id")]
		public int Id { get; set; }

		[DisplayName("PatientId")]
		[Required]
		public string PatientId { get; set; }


		[DisplayName("DoctorId")]
		[Required]
		public string DoctorId { get; set; }

		[DisplayName("AppointmentDate")]
		[Required]
		public string AppointmentDate { get; set; }

		[DisplayName("AppointmentDuration")]
		[Required]
		public string AppointmentDuration { get; set; }

		[DisplayName("AppointmentReason")]
		[Required]
		public string AppointmentReason { get; set; }

		[DisplayName("AppointmentStatus")]
		[Required]
		public string AppointmentStatus { get; set; }
		


	}
}