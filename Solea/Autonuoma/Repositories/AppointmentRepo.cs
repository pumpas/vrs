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
	public class AppointmentRepo
	{
        

        public static List<Appointment> List()
		{
			var appointments = new List<Appointment>();

			string query = $@"SELECT * FROM `{Config.TblPrefix}appointments` ORDER BY id ASC";
			var dt = Sql.Query(query);

			foreach( DataRow item in dt )
			{
				appointments.Add(new Appointment
				{
					Id = Convert.ToInt32(item["id"]),
					PatientId = Convert.ToInt32(item["patient_id"]),
					DoctorId = Convert.ToInt32(item["doctor_id"]),
					AppointmentDate = Convert.ToDateTime(item["appointment_date"]),
					AppointmentDuration = Convert.ToInt32(item["appointment_duration"]),
					AppointmentReason = Convert.ToString(item["appointment_reason"]),
					AppointmentStatus = Convert.ToString(item["appointment_status"])
				});
			}

			return appointments;
		}
		//This is used to find a user based on the id
		public static Appointment Find(int id)
		{
			var Appointment = new Appointment();

			var query = $@"SELECT * FROM `{Config.TblPrefix}appointments` WHERE id=?id";
			var dt = 
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.Int32).Value = id;
				});

			foreach( DataRow item in dt )
			{
				Appointment.Id = Convert.ToInt32(item["id"]);
				Appointment.PatientId = Convert.ToInt32(item["patient_id"]);
				Appointment.DoctorId = Convert.ToInt32(item["doctor_id"]);
				Appointment.AppointmentDate = Convert.ToDateTime(item["appointment_date"]);
				Appointment.AppointmentDuration = Convert.ToInt32(item["appointment_duration"]);
				Appointment.AppointmentReason = Convert.ToString(item["appointment_reason"]);
				Appointment.AppointmentStatus = Convert.ToString(item["appointment_status"]);
			}

			return Appointment;
		}
		

		public static void Update(Appointment appointment)
		{			
			var query = 
				$@"UPDATE `{Config.TblPrefix}appointments` 
				SET 
					patient_id=?patient_id,
					doctor_id=?doctor_id,
					appointment_date=?appointment_date,
					appointment_duration=?appointment_duration,
					appointment_reason=?appointment_reason,
					appointment_status=?appointment_status
				WHERE 
					id=?id";

			Sql.Update(query, args => {
				args.Add("?patient_id", MySqlDbType.VarChar).Value = appointment.PatientId;
				args.Add("?id", MySqlDbType.VarChar).Value = appointment.Id;
				//args.Add("?currency", MySqlDbType.VarChar).Value = User.Currency;
				args.Add("?doctor_id", MySqlDbType.VarChar).Value = appointment.DoctorId;
				args.Add("?appointment_date", MySqlDbType.VarChar).Value = appointment.AppointmentDate;
				args.Add("?appointment_duration", MySqlDbType.VarChar).Value = appointment.AppointmentDuration;
				args.Add("?appointment_reason", MySqlDbType.VarChar).Value = appointment.AppointmentReason;
				args.Add("?appointment_status", MySqlDbType.VarChar).Value = appointment.AppointmentStatus;
			
			});							
		}

		public static void Insert(Appointment appointment)
		{			
				var query =
				$@"INSERT INTO `{Config.TblPrefix}appointments`
				(
					id,
                    patient_id,
					doctor_id,
					appointment_date,
					appointment_duration,
					appointment_reason,
					appointment_status
				)
				VALUES(
					?id,
					?patient_id,
					?doctor_id,
					?appointment_date,
					?appointment_duration,
					?appointment_reason,
					?appointment_status
				)";

			Sql.Insert(query, args => {
				args.Add("?id", MySqlDbType.VarChar).Value = appointment.Id;
				args.Add("?patient_id", MySqlDbType.VarChar).Value = appointment.PatientId;
				args.Add("?doctor_id", MySqlDbType.VarChar).Value = appointment.DoctorId;
				args.Add("?appointment_date", MySqlDbType.VarChar).Value = appointment.AppointmentDate;
				args.Add("?appointment_duration", MySqlDbType.VarChar).Value = appointment.AppointmentDuration;
				args.Add("?appointment_reason", MySqlDbType.VarChar).Value = appointment.AppointmentReason;
				args.Add("?appointment_status", MySqlDbType.VarChar).Value = appointment.AppointmentStatus;
			});
		}

		public static void Delete(int id)
		{			
			var query = $@"DELETE FROM `{Config.TblPrefix}appointments` where id=?id";
			Sql.Delete(query, args => {
				args.Add("?id", MySqlDbType.Int32).Value = id;
			});			
		}
	}
}