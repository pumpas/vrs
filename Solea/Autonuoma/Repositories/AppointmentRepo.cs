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
	public class AppointmentRepo
	{
		public static List<AppointmentListVM> List()
		{
			var result = new List<AppointmentListVM>();

			var query =
				$@"SELECT
					md.id,
					md.appointment_date,
					md.appointment_duration,
					md.appointment_reason,
					md.appointment_status,
					mark.firstname AS patient,
					mm.firstname AS doctor
				FROM
					`{Config.TblPrefix}appointments` md
					LEFT JOIN `{Config.TblPrefix}users` mark ON mark.id=md.patient_id
				LEFT JOIN `{Config.TblPrefix}doctors` mm ON mm.id = md.doctor_id
				ORDER BY mark.firstname ASC, md.id ASC";

			var dt = Sql.Query(query);

			foreach( DataRow item in dt )
			{
				result.Add(new AppointmentListVM
				{
					Id = Convert.ToInt32(item["id"]),
					AppointmentDate = Convert.ToDateTime(item["appointment_date"]),
					AppointmentDuration = Convert.ToInt32(item["appointment_duration"]),
					AppointmentReason = Convert.ToString(item["appointment_reason"]),
					AppointmentStatus = Convert.ToString(item["appointment_status"]),
					PatientId = Convert.ToString(item["patient"]),
					DoctorId = Convert.ToString(item["doctor"])

				});
			}

			return result;
		}

		public static List<Appointment> ListForMarke(int markeId)
		{
			var result = new List<Appointment>();

			var query = $@"SELECT * FROM `{Config.TblPrefix}modeliai` WHERE fk_marke=?markeId ORDER BY id ASC";

			var dt =
				Sql.Query(query, args => {
					args.Add("?markeId", MySqlDbType.Int32).Value = markeId;
				});

			foreach( DataRow item in dt )
			{
				result.Add(new Appointment
				{
					Id = Convert.ToInt32(item["id"]),
					AppointmentReason = Convert.ToString(item["pavadinimas"]),
					AppointmentStatus = Convert.ToString(item["fk_marke"])
				});
			}

			return result;
		}

		public static AppointmentEditVM Find(int id)
		{
			var mevm = new AppointmentEditVM();

			var query = $@"SELECT * FROM `{Config.TblPrefix}modeliai` WHERE id=?id";

			var dt =
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.Int32).Value = id;
				});

			foreach( DataRow item in dt )
			{
				//mevm.Model.Id = Convert.ToInt32(item["id"]);
				//mevm.Model.Pavadinimas = Convert.ToString(item["pavadinimas"]);
				//mevm.Model.FkMarke = Convert.ToInt32(item["fk_marke"]);
			}

			return mevm;
		}

		public static AppointmentListVM FindForDeletion(int id)
		{
			var mlvm = new AppointmentListVM();

			var query =
				$@"SELECT
					md.id,
					
					mark.pavadinimas AS marke
				FROM
					`{Config.TblPrefix}modeliai` md
					LEFT JOIN `{Config.TblPrefix}markes` mark ON mark.id=md.fk_marke
				WHERE
					md.id = ?id";

			var dt =
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.Int32).Value = id;
				});

			foreach( DataRow item in dt )
			{
				mlvm.Id = Convert.ToInt32(item["id"]);
				mlvm.AppointmentReason = Convert.ToString(item["pavadinimas"]);
				mlvm.AppointmentStatus = Convert.ToString(item["marke"]);
			}

			return mlvm;
		}

		public static void Update(AppointmentEditVM modelisEvm)
		{
			var query =
				$@"UPDATE `{Config.TblPrefix}appointments`
				SET
					patient_id=?patient,
					doctor_id=?doctor,
					appointment_date=?date,
					appointment_duration=?dur,
					appointment_reason=?rea,
					appointment_status=?sta
				WHERE
					id=?id";

			Sql.Update(query, args => {
				args.Add("?patient", MySqlDbType.VarChar).Value = modelisEvm.Appointment.FKPatientId;
				args.Add("?doctor", MySqlDbType.VarChar).Value = modelisEvm.Appointment.FKDoctorId;
				args.Add("?date", MySqlDbType.DateTime).Value = modelisEvm.Appointment.AppointmentDate;
				args.Add("?dur", MySqlDbType.Int32).Value = modelisEvm.Appointment.AppointmentDuration;
				args.Add("?rea", MySqlDbType.VarChar).Value = modelisEvm.Appointment.AppointmentReason;
				args.Add("?sta", MySqlDbType.VarChar).Value = modelisEvm.Appointment.AppointmentStatus;
			});
		}

		public static void Insert(AppointmentEditVM modelisEvm)
		{
			var query =
				$@"INSERT INTO `{Config.TblPrefix}appointments`
				(
					patient_id,
					doctor_id,
					appointment_date,
					appointment_duration,
					appointment_reason,
					appointment_status
				)
				VALUES(
					?pacientas,
					?daktaras,
					?data,
					?ilgis,
					?tikslas,
					?statusas
				)";

			Sql.Insert(query, args => {
				args.Add("?pacientas", MySqlDbType.VarChar).Value = modelisEvm.Appointment.FKPatientId;
				args.Add("?daktaras", MySqlDbType.VarChar).Value = modelisEvm.Appointment.FKDoctorId;
				args.Add("?data", MySqlDbType.DateTime).Value = modelisEvm.Appointment.AppointmentDate;
				args.Add("?ilgis", MySqlDbType.Int32).Value = modelisEvm.Appointment.AppointmentDuration;
				args.Add("?tikslas", MySqlDbType.VarChar).Value = modelisEvm.Appointment.AppointmentReason;
				args.Add("?statusas", MySqlDbType.VarChar).Value = modelisEvm.Appointment.AppointmentStatus;
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