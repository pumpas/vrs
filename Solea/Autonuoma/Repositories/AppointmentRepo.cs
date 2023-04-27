using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
	/// <summary>
	/// Database operations related to 'Automobilis' entity.
	/// </summary>
	public class AppointmentRepo
	{
		public static List<AppointmentListVM> List()
		{
			var autombiliai = new List<AppointmentListVM>();

			var query =
				$@"SELECT
					a.id,
					a.appointment_date,
					a.appointment_duration,
					a.appointment_reason,
					a.appointment_status,
					b.firstname AS pacient,
					m.firstname AS daktar
				FROM
					{Config.TblPrefix}appointments a
					LEFT JOIN `{Config.TblPrefix}users` b ON b.id = a.patient_id
					LEFT JOIN `{Config.TblPrefix}doctors` m ON m.id = a.doctor_id
				ORDER BY a.id ASC";

			var dt = Sql.Query(query);

			foreach( DataRow item in dt )
			{
				autombiliai.Add(new AppointmentListVM
				{
					Id = Convert.ToInt32(item["id"]),
					AppointmentDate = Convert.ToDateTime(item["appointment_date"]),
					AppointmentDuration = Convert.ToInt32(item["appointment_duration"]),
					AppointmentReason = Convert.ToString(item["appointment_reason"]),
					AppointmentStatus = Convert.ToString(item["appointment_status"]),
					PatientId = Convert.ToString(item["pacient"]),
					DoctorId = Convert.ToString(item["daktar"])
				});
			}

			return autombiliai;
		}

		public static AppointmentEditVM Find(int id)
		{
			var autoEvm = new AppointmentEditVM();

			var query =  $@"SELECT * FROM `{Config.TblPrefix}appointments` WHERE id=?id";

			var dt =
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.Int32).Value = id;
				});

			foreach( DataRow item in dt )
			{
				autoEvm.Appointment.Id = Convert.ToInt32(item["id"]);
				autoEvm.Appointment.AppointmentReason = Convert.ToString(item["appointment_reason"]);
				autoEvm.Appointment.AppointmentDate = Convert.ToDateTime(item["appointment_date"]);
				autoEvm.Appointment.AppointmentDuration = Convert.ToInt32(item["appointment_duration"]);
				autoEvm.Appointment.AppointmentStatus = Convert.ToString(item["appointment_status"]);
				autoEvm.Appointment.FKPatientId = Convert.ToInt32(item["patient_id"]);
				autoEvm.Appointment.FKDoctorId = Convert.ToInt32(item["doctor_id"]);
			}

			return autoEvm;
		}

		public static void Insert(AppointmentEditVM autoEvm)
		{
			var query = 
				$@"INSERT INTO `{Config.TblPrefix}appointments`
				(
					`patient_id`,
					`doctor_id`,
					`appointment_date`,
					`appointment_duration`,
					`appointment_reason`,
					`appointment_status`
				)
				VALUES (
					?ptnt_id,
					?doc_id,
					?app_dat,
					?app_dur,
					?app_rea,
					?app_sta
				)";

			Sql.Insert(query, args => {
				args.Add("?ptnt_id", MySqlDbType.Int32).Value = autoEvm.Appointment.FKPatientId;
				args.Add("?doc_id", MySqlDbType.Int32).Value = autoEvm.Appointment.FKDoctorId;
				args.Add("?app_dat", MySqlDbType.Date).Value = autoEvm.Appointment.AppointmentDate?.ToString("yyyy-MM-dd");
				args.Add("?app_dur", MySqlDbType.Int32).Value = autoEvm.Appointment.AppointmentDuration;
				args.Add("?app_rea", MySqlDbType.VarChar).Value = autoEvm.Appointment.AppointmentReason;
				args.Add("?app_sta", MySqlDbType.VarChar).Value = autoEvm.Appointment.AppointmentStatus;
			});
		}

		public static void Update(AppointmentEditVM autoEvm)
		{
			var query =
				$@"UPDATE `{Config.TblPrefix}appointments`
				SET
					`patient_id` = ?ptnt_id,
					`doctor_id` = ?doc_id,
					`appointment_date` = ?app_dat,
					`appointment_duration` = ?app_dur,
					`appointment_reason` = ?app_rea,
					`appointment_status` = ?app_sta
				WHERE
					id=?id";

			Sql.Update(query, args => {
				args.Add("?ptnt_id", MySqlDbType.Int32).Value = autoEvm.Appointment.FKPatientId;
				args.Add("?doc_id", MySqlDbType.Int32).Value = autoEvm.Appointment.FKDoctorId;
				args.Add("?app_dat", MySqlDbType.Date).Value = autoEvm.Appointment.AppointmentDate?.ToString("yyyy-MM-dd");
				args.Add("?app_dur", MySqlDbType.Int32).Value = autoEvm.Appointment.AppointmentDuration;
				args.Add("?app_rea", MySqlDbType.VarChar).Value = autoEvm.Appointment.AppointmentReason;
				args.Add("?app_sta", MySqlDbType.VarChar).Value = autoEvm.Appointment.AppointmentStatus;
			});
		}

		public static void Delete(int id)
		{
			var query = $@"DELETE FROM `{Config.TblPrefix}appointments` WHERE id=?id";
			Sql.Delete(query, args => {
				args.Add("?id", MySqlDbType.Int32).Value = id;
			});
		}
	}
}