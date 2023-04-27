using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;

namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
	/// Model of 'Modelis' entity used in creation and editing forms.
	/// </summary>
	public class AppointmentEditVM
	{
		/// <summary>
		/// Entity data
		/// </summary>
		public class AppointmentM
		{
			[DisplayName("Id")]
			public int Id { get; set; }

			[DisplayName("PatientID")]
			[Required]
			public int FKPatientId { get; set; }

			[DisplayName("DoctorID")]
			[Required]
			public int FKDoctorId { get; set; }
			
			[DisplayName("AppointmentDate")]
			[Required]
			public DateTime? AppointmentDate { get; set; }
			
			[DisplayName("AppointmentDuration")]
			[Required]
			public int AppointmentDuration { get; set; }
			
			[DisplayName("AppointmentReason")]
			[Required]
			public string AppointmentReason { get; set; }
			
			[DisplayName("AppointmentStatus")]
			[Required]
			public string AppointmentStatus { get; set; }
		}

		/// <summary>
		/// Select lists for making drop downs for choosing values of entity fields.
		/// </summary>
		public class ListsM
		{
			public IList<SelectListItem> PatientId { get; set; }
			public IList<SelectListItem> DoctorId { get; set; }
			public IList<SelectListItem> Users { get; set; }
			public IList<SelectListItem> Doctors { get; set; }

			public int id {get;set;}
			
		}

		/// <summary>
		/// Entity view.
		/// </summary>
		public AppointmentM Appointment { get; set; } = new AppointmentM();
		public User user {get; set;}
		public Doctor doctor {get; set;}

		/// <summary>
		/// Lists for drop down controls.
		/// </summary>
		public ListsM Lists { get; set; } = new ListsM();
	}
}