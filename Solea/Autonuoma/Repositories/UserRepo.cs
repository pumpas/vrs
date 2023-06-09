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
	public class UserRepo
	{
        

        public static List<User> List()
		{
			var users = new List<User>();

			string query = $@"SELECT * FROM `{Config.TblPrefix}users` ORDER BY id ASC";
			var dt = Sql.Query(query);

			foreach( DataRow item in dt )
			{
				users.Add(new User
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

			return users;
		}
		//This is used to find a user based on the id
		public static User Find(int id)
		{
			var User = new User();

			var query = $@"SELECT * FROM `{Config.TblPrefix}users` WHERE id=?id";
			var dt = 
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.Int32).Value = id;
				});

			foreach( DataRow item in dt )
			{
				User.Id = Convert.ToInt32(item["id"]);
				User.Name = Convert.ToString(item["name"]);
				//User.Currency = Convert.ToInt32(item["currency"]);
				User.Email = Convert.ToString(item["email"]);
				User.Password = Convert.ToString(item["password"]);
				User.LastName = Convert.ToString(item["lastname"]);
				User.MobileNumber = Convert.ToString(item["mobilenumber"]);
				User.Role = Convert.ToString(item["role"]);
				User.Specialty = Convert.ToString(item["specialty"]);
				User.FirstName = Convert.ToString(item["firstname"]);
			}

			return User;
		}
		//This is used to check when loggin in whether a user inputed a correct name and password
		public static User Find(User user)
		{
			var User = new User();

			var query = $@"SELECT * FROM `{Config.TblPrefix}users` WHERE name=?name AND password=?password";
			var dt = 
				Sql.Query(query, args => {
					args.Add("?password", MySqlDbType.VarChar).Value = user.Password;
					args.Add("?name", MySqlDbType.VarChar).Value = user.Name;
				});
			foreach( DataRow item in dt )
			{
				User.Id = Convert.ToInt32(item["id"]);
				User.Name = Convert.ToString(item["name"]);
				//User.Currency = Convert.ToInt32(item["currency"]);
				User.Email = Convert.ToString(item["email"]);
				User.Password = Convert.ToString(item["password"]);
				User.LastName = Convert.ToString(item["lastname"]);
				User.MobileNumber = Convert.ToString(item["mobilenumber"]);
				User.Role = Convert.ToString(item["role"]);
				User.Specialty = Convert.ToString(item["specialty"]);
				User.FirstName = Convert.ToString(item["firstname"]);
			}

			return User;
		}
		//This is used to check when registering whether an account with the same name or email already exist
		public static User Find(string user){
			var User = new User();
			var query = $@"SELECT * FROM `{Config.TblPrefix}users` WHERE email=?email";
			var dt = 
				Sql.Query(query, args => {
					args.Add("?email", MySqlDbType.VarChar).Value = user;
				});
			foreach( DataRow item in dt )
			{
				User.Id = Convert.ToInt32(item["id"]);
				User.Name = Convert.ToString(item["name"]);
				//User.Currency = Convert.ToInt32(item["currency"]);
				User.Email = Convert.ToString(item["email"]);
				User.Password = Convert.ToString(item["password"]);
				User.LastName = Convert.ToString(item["lastname"]);
				User.MobileNumber = Convert.ToString(item["mobilenumber"]);
				User.Role = Convert.ToString(item["role"]);
				User.Specialty = Convert.ToString(item["specialty"]);
				User.FirstName = Convert.ToString(item["firstname"]);
			}

			return User;
		}
		public static User Find(string user, int n){
			var User = new User();
			var query = $@"SELECT * FROM `{Config.TblPrefix}users` WHERE name=?name";
			var dt = 
				Sql.Query(query, args => {
					args.Add("?name", MySqlDbType.VarChar).Value = user;
				});
			foreach( DataRow item in dt )
			{
				User.Id = Convert.ToInt32(item["id"]);
				User.Name = Convert.ToString(item["name"]);
				//User.Currency = Convert.ToInt32(item["currency"]);
				User.Email = Convert.ToString(item["email"]);
				User.Password = Convert.ToString(item["password"]);
				User.LastName = Convert.ToString(item["lastname"]);
				User.MobileNumber = Convert.ToString(item["mobilenumber"]);
				User.Role = Convert.ToString(item["role"]);
				User.Specialty = Convert.ToString(item["specialty"]);
				User.FirstName = Convert.ToString(item["firstname"]);
			}

			return User;
		}

		public static void Update(User User)
		{			
			var query = 
				$@"UPDATE `{Config.TblPrefix}users` 
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
				args.Add("?name", MySqlDbType.VarChar).Value = User.Name;
				args.Add("?id", MySqlDbType.VarChar).Value = User.Id;
				//args.Add("?currency", MySqlDbType.VarChar).Value = User.Currency;
				args.Add("?email", MySqlDbType.VarChar).Value = User.Email;
				args.Add("?password", MySqlDbType.VarChar).Value = User.Password;
				args.Add("?lastname", MySqlDbType.VarChar).Value = User.LastName;
				args.Add("?mobilenumber", MySqlDbType.VarChar).Value = User.MobileNumber;
				args.Add("?role", MySqlDbType.VarChar).Value = User.Role;
				args.Add("?specialty", MySqlDbType.VarChar).Value = User.Specialty;
				args.Add("?firstname", MySqlDbType.VarChar).Value = User.FirstName;
			});							
		}

		public static void Insert(User User)
		{			
				var query =
				$@"INSERT INTO `{Config.TblPrefix}users`
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
				args.Add("?id", MySqlDbType.VarChar).Value = User.Id;
				args.Add("?name", MySqlDbType.VarChar).Value = User.Name;
				//args.Add("?currency", MySqlDbType.VarChar).Value = User.Currency;
				args.Add("?email", MySqlDbType.VarChar).Value = User.Email;
				args.Add("?password", MySqlDbType.VarChar).Value = User.Password;
				args.Add("?lastname", MySqlDbType.VarChar).Value = User.LastName;
				args.Add("?mobilenumber", MySqlDbType.VarChar).Value = User.MobileNumber;
				args.Add("?role", MySqlDbType.VarChar).Value = User.Role;
				args.Add("?specialty", MySqlDbType.VarChar).Value = User.Specialty;
				args.Add("?firstname", MySqlDbType.VarChar).Value = User.FirstName;
			});
		}

		public static void Delete(int id)
		{			
			var query = $@"DELETE FROM `{Config.TblPrefix}users` where id=?id";
			Sql.Delete(query, args => {
				args.Add("?id", MySqlDbType.Int32).Value = id;
			});			
		}
	}
}