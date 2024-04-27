using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models.ViewModels
{
    public class AppointmentVM
    {
        public int AppointmentID { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string PatientIdentityNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int Gender { get; set; }

        public int PatientID { get; set; } // For necessary info of patient

        //[ForeignKey("Doctor")]
        //[Required]
        public int DoctorID { get; set; }

        //[Required]
        public AppointmentType AppointmentType { get; set; } // Indoor or Outdoor

        //[Required]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; } // Pending/Cancelled/Completed

        //[Required]
        [EnumDataType(typeof(AppointmentStatus))]
        public AppointmentStatus AppointmentStatus { get; set; }
    }

    public enum AppointmentStatus
    {
        Pending = 1,
        Completed,
        Cancelled,
    }

    public enum AppointmentType
    {
        Indoor,
        Outdoor
    }
}