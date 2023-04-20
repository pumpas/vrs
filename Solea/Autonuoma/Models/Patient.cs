using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Models
{
	/// <summary>
	/// Model of 'Modelis' entity.
	/// </summary>
	public class Patient
{
    public int Id { get; set; }
    public int UserId { get; set; }
	public string Name { get; set; }
    public User User { get; set; }
}
}