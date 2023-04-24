using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Models
{
	/// <summary>
	/// Model for 'Marke' entity.
	/// </summary>
	public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MobileNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
	public string Name { get; set; }
    public string Specialty { get; set; }
	
}
}