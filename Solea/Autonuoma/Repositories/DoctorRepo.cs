using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
	public class DoctorRepo
	{
        

        public static List<Doctor> List()
		{
			var doctors = new List<Doctor>();

			string query = $@"SELECT * FROM `{Config.TblPrefix}doctors` ORDER BY id ASC";
			var dt = Sql.Query(query);

			foreach( DataRow item in dt )
			{
				doctors.Add(new Doctor
				{
					Id = Convert.ToInt32(item["id"]),
					Name = Convert.ToString(item["name"]),
					//Currency = Convert.ToInt32(item["currency"]),
					Email = Convert.ToString(item["email"]),
					Password = Convert.ToString(item["password"]),
					LastName = Convert.ToString(item["lastname"]),
					MobileNumber = Convert.ToString(item["mobilenumber"]),
					Role = Convert.ToString(item["role"]),
					Specialty = Convert.ToString(item["specialty"]),
					FirstName = Convert.ToString(item["firstname"])
				});
			}

			return doctors;
		}
		//This is used to find a user based on the id
		public static Doctor Find(int id)
		{
			var Doctor = new Doctor();

			var query = $@"SELECT * FROM `{Config.TblPrefix}doctors` WHERE id=?id";
			var dt = 
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.Int32).Value = id;
				});

			foreach( DataRow item in dt )
			{
				Doctor.Id = Convert.ToInt32(item["id"]);
				Doctor.Name = Convert.ToString(item["name"]);
				//User.Currency = Convert.ToInt32(item["currency"]);
				Doctor.Email = Convert.ToString(item["email"]);
				Doctor.Password = Convert.ToString(item["password"]);
				Doctor.LastName = Convert.ToString(item["lastname"]);
				Doctor.MobileNumber = Convert.ToString(item["mobilenumber"]);
				Doctor.Role = Convert.ToString(item["role"]);
				Doctor.Specialty = Convert.ToString(item["specialty"]);
				Doctor.FirstName = Convert.ToString(item["firstname"]);
			}

			return Doctor;
		}
		//This is used to check when loggin in whether a user inputed a correct name and password
		public static Doctor Find(Doctor doctor)
		{
			var Doctor = new Doctor();

			var query = $@"SELECT * FROM `{Config.TblPrefix}doctors` WHERE name=?name AND password=?password";
			var dt = 
				Sql.Query(query, args => {
					args.Add("?password", MySqlDbType.VarChar).Value = doctor.Password;
					args.Add("?name", MySqlDbType.VarChar).Value = doctor.Name;
				});
			foreach( DataRow item in dt )
			{
				Doctor.Id = Convert.ToInt32(item["id"]);
				Doctor.Name = Convert.ToString(item["name"]);
				//User.Currency = Convert.ToInt32(item["currency"]);
				Doctor.Email = Convert.ToString(item["email"]);
				Doctor.Password = Convert.ToString(item["password"]);
				Doctor.LastName = Convert.ToString(item["lastname"]);
				Doctor.MobileNumber = Convert.ToString(item["mobilenumber"]);
				Doctor.Role = Convert.ToString(item["role"]);
				Doctor.Specialty = Convert.ToString(item["specialty"]);
				Doctor.FirstName = Convert.ToString(item["firstname"]);
			}

			return Doctor;
		}
		//This is used to check when registering whether an account with the same name or email already exist
		public static Doctor Find(string doctor){
			var Doctor = new Doctor();
			var query = $@"SELECT * FROM `{Config.TblPrefix}doctors` WHERE email=?email";
			var dt = 
				Sql.Query(query, args => {
					args.Add("?email", MySqlDbType.VarChar).Value = doctor;
				});
			foreach( DataRow item in dt )
			{
				Doctor.Id = Convert.ToInt32(item["id"]);
				Doctor.Name = Convert.ToString(item["name"]);
				//User.Currency = Convert.ToInt32(item["currency"]);
				Doctor.Email = Convert.ToString(item["email"]);
				Doctor.Password = Convert.ToString(item["password"]);
				Doctor.LastName = Convert.ToString(item["lastname"]);
				Doctor.MobileNumber = Convert.ToString(item["mobilenumber"]);
				Doctor.Role = Convert.ToString(item["role"]);
				Doctor.Specialty = Convert.ToString(item["specialty"]);
				Doctor.FirstName = Convert.ToString(item["firstname"]);
			}

			return Doctor;
		}
		public static Doctor Find(string doctor, int n){
			var Doctor = new Doctor();
			var query = $@"SELECT * FROM `{Config.TblPrefix}doctors` WHERE name=?name";
			var dt = 
				Sql.Query(query, args => {
					args.Add("?name", MySqlDbType.VarChar).Value = doctor;
				});
			foreach( DataRow item in dt )
			{
				Doctor.Id = Convert.ToInt32(item["id"]);
				Doctor.Name = Convert.ToString(item["name"]);
				//User.Currency = Convert.ToInt32(item["currency"]);
				Doctor.Email = Convert.ToString(item["email"]);
				Doctor.Password = Convert.ToString(item["password"]);
				Doctor.LastName = Convert.ToString(item["lastname"]);
				Doctor.MobileNumber = Convert.ToString(item["mobilenumber"]);
				Doctor.Role = Convert.ToString(item["role"]);
				Doctor.Specialty = Convert.ToString(item["specialty"]);
				Doctor.FirstName = Convert.ToString(item["firstname"]);
			}

			return Doctor;
		}

		public static void Update(Doctor Doctor)
		{			
			var query = 
				$@"UPDATE `{Config.TblPrefix}doctors` 
				SET 
					name=?name,
					email=?email,
					password=?password,
					lastname=?lastname,
					mobilenumber=?mobilenumber,
					role=?role,
					specialty=?specialty,
					firstname=?firstname
				WHERE 
					id=?id";

			Sql.Update(query, args => {
				args.Add("?name", MySqlDbType.VarChar).Value = Doctor.Name;
				args.Add("?id", MySqlDbType.VarChar).Value = Doctor.Id;
				//args.Add("?currency", MySqlDbType.VarChar).Value = User.Currency;
				args.Add("?email", MySqlDbType.VarChar).Value = Doctor.Email;
				args.Add("?password", MySqlDbType.VarChar).Value = Doctor.Password;
				args.Add("?lastname", MySqlDbType.VarChar).Value = Doctor.LastName;
				args.Add("?mobilenumber", MySqlDbType.VarChar).Value = Doctor.MobileNumber;
				args.Add("?role", MySqlDbType.VarChar).Value = Doctor.Role;
				args.Add("?specialty", MySqlDbType.VarChar).Value = Doctor.Specialty;
				args.Add("?firstname", MySqlDbType.VarChar).Value = Doctor.FirstName;
			});							
		}

		public static void Insert(Doctor Doctor)
		{			
				var query =
				$@"INSERT INTO `{Config.TblPrefix}doctors`
				(
					id,
                    name,
					email,
					password,
					lastname,
					mobilenumber,
					role,
					specialty,
					firstname
				)
				VALUES(
					?id,
					?name,
					?email,
					?password,
					?lastname,
					?mobilenumber,
					?role,
					?specialty,
					?firstname
				)";

			Sql.Insert(query, args => {
				args.Add("?id", MySqlDbType.VarChar).Value = Doctor.Id;
				args.Add("?name", MySqlDbType.VarChar).Value = Doctor.Name;
				//args.Add("?currency", MySqlDbType.VarChar).Value = User.Currency;
				args.Add("?email", MySqlDbType.VarChar).Value = Doctor.Email;
				args.Add("?password", MySqlDbType.VarChar).Value = Doctor.Password;
				args.Add("?lastname", MySqlDbType.VarChar).Value = Doctor.LastName;
				args.Add("?mobilenumber", MySqlDbType.VarChar).Value = Doctor.MobileNumber;
				args.Add("?role", MySqlDbType.VarChar).Value = Doctor.Role;
				args.Add("?specialty", MySqlDbType.VarChar).Value = Doctor.Specialty;
				args.Add("?firstname", MySqlDbType.VarChar).Value = Doctor.FirstName;
			});
		}

		public static void Delete(int id)
		{			
			var query = $@"DELETE FROM `{Config.TblPrefix}doctors` where id=?id";
			Sql.Delete(query, args => {
				args.Add("?id", MySqlDbType.Int32).Value = id;
			});			
		}
	}
}