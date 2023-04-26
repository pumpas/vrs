using Microsoft.AspNetCore.Mvc;
using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers
{
	/// <summary>
	/// Controller for working with 'Marke' entity.
	/// </summary>
	public class AppointmentController : Controller
	{
			
		/// <summary>
		/// This is invoked when either 'Index' action is requested or no action is provided.
		/// </summary>
		/// <returns>Entity list view.</returns>
		public ActionResult Index()
		{
			var appointments = AppointmentRepo.List();
			return View(appointments);
		}

		/*public ActionResult Login(string name, string password)
		{
			var match = UserRepo.Find(darb.ID);
			return View(users);
		}*/
		//This page is invoked when login button is pressed
		public ActionResult Login()
		{
			return View();
		}

		


		/// <summary>
		/// This is invoked when creation form is first opened in browser.
		/// </summary>
		/// <returns>Creation form view.</returns>
		public ActionResult Create()
		{
			var appointment = new Appointment();
			return View(appointment);
		}

		
		
/// <summary>
		/// This is invoked when buttons are pressed in the creation form.
		/// </summary>
		/// <param name="user">Entity model filled with latest data.</param>
		/// <returns>Returns creation from view or redirects back to Index if save is successfull.</returns>
		[HttpPost]
		public ActionResult Create(Appointment appointment)
		{
			
			/*var matchName = UserRepo.Find(user.Name, 1);
			var matchEmail = UserRepo.Find(user.Email);
			// if(matchName.Name == "testasAI"){
			// 		Debug.WriteLine("gerai");
			// 	}
			// else
			// 	Debug.WriteLine("blogai");

			if( matchName.Name == user.Name)
				ModelState.AddModelError("name", "This name is already taken");
			else if( user.Name==null || user.Name.Length < 5)
				ModelState.AddModelError("name", "Name must be atleast 5 characters long");
			if( matchEmail.Email == user.Email)
				ModelState.AddModelError("email", "This email is already taken");
			else if( user.Email == null || user.Email.Length < 5)
				ModelState.AddModelError("email", "Email must be atleast 5 characters long");
			if(user.Password == null || user.Password.Length < 5)
				ModelState.AddModelError("password", "Password must be atleast 5 characters long");
			
			*/
			

			//form field validation passed?
			//if (ModelState.IsValid && matchName.Name != user.Name && matchEmail.Email != user.Email)
			{
				// user.Currency=100;
				// UserRepo.Insert(user);
				// TempData["id"]=UserRepo.Find(user.Name, 1).Id;
				//matchName = UserRepo.Find(user.Name, 1);
				/*if(match.Name == "lab"){
					Debug.WriteLine("gerai");
				}
				else
					Debug.WriteLine("blogai");*/
				//save success, go back to the entity list

				//int id = SendConfirm(user.Email);
				//TempData["codeId"] = Id;
				TempData["userPID"] = appointment.PatientId;
				TempData["userDIP"] = appointment.DoctorId;
				TempData["userDAT"] = appointment.AppointmentDate;
				TempData["userDUR"] = appointment.AppointmentDuration;
				TempData["userREA"] = appointment.AppointmentReason;
				TempData["userSTA"] = appointment.AppointmentStatus;
				//return RedirectToAction("Confirm");
				return RedirectToAction("Index","Question");
			}

			//form field validation failed, go back to the form
			return View(appointment);
		}
		/// <summary>
		/// This is invoked when editing form is first opened in browser.
		/// </summary>
		/// <param name="id">ID of the entity to edit.</param>
		/// <returns>Editing form view.</returns>
		public ActionResult Edit()
		{
			var appointment = AppointmentRepo.Find(Convert.ToInt32(TempData["id"]));
			return View(appointment);
		}

		/// <summary>
		/// This is invoked when buttons are pressed in the editing form.
		/// </summary>
		/// <param name="id">ID of the entity being edited</param>		
		/// <param name="marke">Entity model filled with latest data.</param>
		/// <returns>Returns editing from view or redirects back to Index if save is successfull.</returns>
		[HttpPost]
		public ActionResult Edit(User user)
		{
			//form field validation passed?
			if(user.Password == null || user.Password.Length < 5)
				ModelState.AddModelError("password", "Password must be at least 5 characters");
			else {
				UserRepo.Update(user);
				return RedirectToAction("Index","Question");
			}

			//form field validation failed, go back to the form
			return View(user);
		}
	
		/// </summary>
		/// <param name="id">ID of the entity to delete.</param>
		/// <returns>Deletion form view.</returns>
		public ActionResult Delete(int id)
		{
			var user = UserRepo.Find(id);
			return View(user);
		}

		/// <summary>
		/// This is invoked when deletion is confirmed in deletion form
		/// </summary>
		/// <param name="id">ID of the entity to delete.</param>
		/// <returns>Deletion form view on error, redirects to Index on success.</returns>
		[HttpPost]
		public ActionResult DeleteConfirm(int id)
		{
			//try deleting, this will fail if foreign key constraint fails
			try 
			{
				UserRepo.Delete(id);

				//deletion success, redired to list form
				return RedirectToAction("Index");
			}
			//entity in use, deletion not permitted
			catch( MySql.Data.MySqlClient.MySqlException )
			{
				//enable explanatory message and show delete form
				ViewData["deletionNotPermitted"] = true;

				var user = UserRepo.Find(id);
				return View("Delete", user);
			}
		}
		 public int SendConfirm(string mail){
			using (MailMessage mm = new MailMessage("blokasthe@gmail.com", mail))
        {
			int id=0;
			Random random = new Random();
			id = random.Next();
            mm.Subject = "Account Activation";
            string body = "Hello " /*+ user.Name*/ + ",";
            body += "<br /><br />Please write the following code to activate your account: ";
			body += id;
            mm.Body = body;
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential("blokasthe@gmail.com", "qrfeziedrxiiezll");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
			return id;
        }
		
		}
		
		public ActionResult Confirm(){
			return View();
		}
		[HttpPost]
		public ActionResult Confirm(string code){
			string id = Convert.ToString(TempData["codeId"]);
			if(code == id){
				return RedirectToAction("Add");
			}
			TempData["codeId"] = id;
			return View();
		}
		public ActionResult Add(){
			Appointment appointment = new Appointment();
			appointment.PatientId = Convert.ToInt32(TempData["userPID"]);
			appointment.DoctorId = Convert.ToInt32(TempData["userDIP"]);
			appointment.AppointmentDate = Convert.ToDateTime(TempData["userDAT"]);
			appointment.AppointmentDuration = Convert.ToInt32(TempData["userDUR"]);
			appointment.AppointmentReason = Convert.ToString(TempData["userREA"]);
			appointment.AppointmentStatus = Convert.ToString(TempData["userSTA"]);
			
			//user.Currency = 100;
			AppointmentRepo.Insert(appointment);
			//TempData["id"]=AppointmentRepo.Find(appointment., 1).Id;
			return RedirectToAction("Index", "Question");
		}
	}
}
