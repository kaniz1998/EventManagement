using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Models;

namespace HMS.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }

        [Required(ErrorMessage = "Enter Doctor Name")]
        [StringLength(100, ErrorMessage = "Please do not enter values over 100 characters")]
        public string DoctorName { get; set; } = default!;

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        [StringLength(20, ErrorMessage = "Enter Doctor Speciality Only (Ex: Heart, Kidney)")]
        public string Specialization { get; set; } = default!;

        [EnumDataType(typeof(doctortype))]
        public doctortype Doctortype { get; set; } = default!;

        [Column(TypeName = "date")]
        [Display(Name = "Join Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime JoinDate { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Resign Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ResignDate { get; set; }

        [EnumDataType(typeof(EmployeeStatus))]
        public EmployeeStatus employeeStatus { get; set; }

        [StringLength(200)]
        public string Education_Info { get; set; } = default!;

        [Required, RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must be 11 digits.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = default!;

        public string Image { get; set; } = default!;

        [NotMapped]
        public  Department? Department { get; set; } = default!;

        [NotMapped]
        public  ICollection<Prescription?> Prescriptions { get; set; } = new List<Prescription?>();

        [NotMapped]
        public  ICollection<Appointment?> Appointments { get; set; } = new List<Appointment?>();

        //[NotMapped]
        //public  ICollection<Surgery?> Surgeries { get; set; } = new List<Surgery?>();
    }
    public enum doctortype
    {
        [Display(Name = "Outdoor Doctor")] //MBBS Doctor/Intern
        generalpractitioner = 1,

        [Display(Name = "Surgeon")]
        surgeon,

        [Display(Name = "Anesthesiologist")]
        anesthesiologist,

        [Display(Name = "Dentist")]
        dentist,

        [Display(Name = "Pathologist")]
        Pathologist,

        [Display(Name = "Radiologist")]
        Radiologists,

        [Display(Name = "Specialist")] //Pediatrician, Cardiologist
        specialist,
    }

}
