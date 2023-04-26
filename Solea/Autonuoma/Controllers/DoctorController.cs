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
	public class DoctorController : Controller
	{
			
		/// <summary>
		/// This is invoked when either 'Index' action is requested or no action is provided.
		/// </summary>
		/// <returns>Entity list view.</returns>
		public ActionResult Index()
		{
			var doctors = DoctorRepo.List();
			return View(doctors);
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

		//This function is invoked when a login form is submited (pressed login) on login page
		//It checks whether a user name and password is found in the data base
		//If found sends user's id to main page, so from there it can be used
		[HttpPost]
		public ActionResult Login(Doctor doctor)
		{
			var match = DoctorRepo.Find(doctor);
			if( match.Name != doctor.Name || match.Password != doctor.Password )
				ModelState.AddModelError("password", "Incorrect name or password");
			if(match.Name == doctor.Name && match.Password == doctor.Password && doctor.Name!=null && doctor.Password !=null){
				TempData["id"]=match.Id;

				//Loggedin.Login();
				return RedirectToAction("Index", "Question");
				//return View( "Index", nameof(Index));
			}
			return View(doctor);
		}




		/// <summary>
		/// This is invoked when creation form is first opened in browser.
		/// </summary>
		/// <returns>Creation form view.</returns>
		public ActionResult Create()
		{
			var doctor = new Doctor();
			return View(doctor);
		}

		/// <summary>
		/// This is invoked when buttons are pressed in the creation form.
		/// </summary>
		/// <param name="user">Entity model filled with latest data.</param>
		/// <returns>Returns creation from view or redirects back to Index if save is successfull.</returns>
		[HttpPost]
		public ActionResult Create(Doctor doctor)
		{
			var matchName = DoctorRepo.Find(doctor.Name, 1);
			var matchEmail = DoctorRepo.Find(doctor.Email);
			// if(matchName.Name == "testasAI"){
			// 		Debug.WriteLine("gerai");
			// 	}
			// else
			// 	Debug.WriteLine("blogai");

			if( matchName.Name == doctor.Name)
				ModelState.AddModelError("name", "This name is already taken");
			else if( doctor.Name==null || doctor.Name.Length < 5)
				ModelState.AddModelError("name", "Name must be atleast 5 characters long");
			if( matchEmail.Email == doctor.Email)
				ModelState.AddModelError("email", "This email is already taken");
			else if( doctor.Email == null || doctor.Email.Length < 5)
				ModelState.AddModelError("email", "Email must be atleast 5 characters long");
			if(doctor.Password == null || doctor.Password.Length < 5)
				ModelState.AddModelError("password", "Password must be atleast 5 characters long");
			
			
			

			//form field validation passed?
			if (ModelState.IsValid && matchName.Name != doctor.Name && matchEmail.Email != doctor.Email)
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

				int id = SendConfirm(doctor.Email);
				TempData["codeId"] = id;
				TempData["userN"] = doctor.Name;
				TempData["userE"] = doctor.Email;
				TempData["userP"] = doctor.Password;
				TempData["userFN"] = doctor.FirstName;
				TempData["userLN"] = doctor.LastName;
				TempData["userMN"] = doctor.MobileNumber;
				TempData["userR"] = doctor.Role;
				TempData["userS"] = doctor.Specialty;
				return RedirectToAction("Confirm");
				//return RedirectToAction("Index","Question");
			}

			//form field validation failed, go back to the form
			return View(doctor);
		}
		

		/// <summary>
		/// This is invoked when editing form is first opened in browser.
		/// </summary>
		/// <param name="id">ID of the entity to edit.</param>
		/// <returns>Editing form view.</returns>
		public ActionResult Edit()
		{
			var doctor = DoctorRepo.Find(Convert.ToInt32(TempData["id"]));
			return View(doctor);
		}

		/// <summary>
		/// This is invoked when buttons are pressed in the editing form.
		/// </summary>
		/// <param name="id">ID of the entity being edited</param>		
		/// <param name="marke">Entity model filled with latest data.</param>
		/// <returns>Returns editing from view or redirects back to Index if save is successfull.</returns>
		[HttpPost]
		public ActionResult Edit(Doctor doctor)
		{
			//form field validation passed?
			if(doctor.Password == null || doctor.Password.Length < 5)
				ModelState.AddModelError("password", "Password must be at least 5 characters");
			else {
				DoctorRepo.Update(doctor);
				return RedirectToAction("Index","Question");
			}

			//form field validation failed, go back to the form
			return View(doctor);
		}
	
		/// </summary>
		/// <param name="id">ID of the entity to delete.</param>
		/// <returns>Deletion form view.</returns>
		public ActionResult Delete(int id)
		{
			var doctor = DoctorRepo.Find(id);
			return View(doctor);
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
				DoctorRepo.Delete(id);

				//deletion success, redired to list form
				return RedirectToAction("Index");
			}
			//entity in use, deletion not permitted
			catch( MySql.Data.MySqlClient.MySqlException )
			{
				//enable explanatory message and show delete form
				ViewData["deletionNotPermitted"] = true;

				var doctor = DoctorRepo.Find(id);
				return View("Delete", doctor);
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
			Doctor doctor = new Doctor();
			doctor.Name = Convert.ToString(TempData["userN"]);
			doctor.Email = Convert.ToString(TempData["userE"]);
			doctor.Password = Convert.ToString(TempData["userP"]);
			doctor.FirstName = Convert.ToString(TempData["userFN"]);
			doctor.LastName = Convert.ToString(TempData["userLN"]);
			doctor.MobileNumber = Convert.ToString(TempData["userMN"]);
			doctor.Role = Convert.ToString(TempData["userR"]);
			doctor.Specialty = Convert.ToString(TempData["userS"]);
			//user.Currency = 100;
			DoctorRepo.Insert(doctor);
			TempData["id"]=DoctorRepo.Find(doctor.Name, 1).Id;
			return RedirectToAction("Index", "Question");
		}
	}
}
