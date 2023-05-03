using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
	/// Model for 'Marke' entity.
	/// </summary>
	public class AppointmentListVM
	{
		[DisplayName("Id")]
		public int Id { get; set; }

		[DisplayName("PatientID")]
		public string PatientId { get; set; }		

		[DisplayName("DoctorID")]
		public string DoctorId { get; set; }
        
        [DisplayName("AppointmentDate")]
		public DateTime AppointmentDate { get; set; }
       
        [DisplayName("AppointmentDuration")]
		public int AppointmentDuration { get; set; }
        
        [DisplayName("AppointmentReason")]
		public string AppointmentReason { get; set; }
        
        [DisplayName("AppointmentStatus")]
		public string AppointmentStatus { get; set; }
	}
       
   


}