using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.Models
{
	public class Appointment
	{
		[Key]
		public int AppointmentID { get; set; }

		[ForeignKey("PatientRegister")]
		[Required]
		public int PatientID { get; set; } // For necessary info of patient

		[ForeignKey("Doctor")]
		[Required]
		public int DoctorID { get; set; }

		[Required]
		public AppointmentType AppointmentType { get; set; } // Indoor or Outdoor

		[Required]
		[DataType(DataType.Date)]
		public DateTime AppointmentDate { get; set; } // Pending/Cancelled/Completed

		[Required]
		[EnumDataType(typeof(AppointmentStatus))]
		public AppointmentStatus AppointmentStatus { get; set; }
	}

	public enum AppointmentStatus
	{
		Pending,
		Cancelled,
		Completed
	}

	public enum AppointmentType
	{
		Indoor,
		Outdoor
	}
}
