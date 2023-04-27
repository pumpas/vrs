using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;

namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
	/// Model of 'Modelis' entity used in lists.
	/// </summary>
	public class Appointments
    {
        public List<AppointmentListVM> appointment { get; set; }
        public User user {get; set;}
        public Doctor doctor {get; set;}
        public AppointmentListVM answer { get; set; }
    }
}