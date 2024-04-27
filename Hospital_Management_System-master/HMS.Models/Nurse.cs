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
    public class Nurse
    {
        [Key]
        public int NurseID { get; set; }

        [Required(ErrorMessage = "Enter Nurse Name")]
        [StringLength(100, ErrorMessage = "Please do not enter values over 100 characters")]
        public string NurseName { get; set; } = default!;

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        public NurseLevel NurseLevel { get; set; } = default!;

        public NurseType NurseType { get; set; } = default!;

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

        public string Image { get; set; } = default!;

        [Required, RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must be 11 digits.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = default!;

        [NotMapped]
        public  Department? Department { get; set; } = default!;

        //public  ICollection<Prescription?> Prescriptions { get; set; } = new List<Prescription?>();
        //public  ICollection<Appointment?> Appointments { get; set; } = new List<Appointment?>();
        //public  ICollection<Surgery?> Surgeries { get; set; } = new List<Surgery?>();
    }
    public enum NurseType
    {
        [Display(Name = "General Nurse")]
        General=1,

        [Display(Name = "Ward Duty Nurse")]
        WordDuty,

        [Display(Name = "Certified Midwife")]
        Midwife,

        [Display(Name = "Pediatric Nurse")]
        Pediatric,

        [Display(Name = "OT Nurse")]
        OT,

        [Display(Name = "High Dependency Unit")]
        HDU
    }

    public enum NurseLevel
    {
        Junior=1,
        Intermediate,
        Senior,
        [Display(Name = "Head Nurse")]
        HeadNurse,
        Intern,
        Other
    }

}
