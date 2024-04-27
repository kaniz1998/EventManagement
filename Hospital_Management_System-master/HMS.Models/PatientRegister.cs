using HMS.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{

    public class PatientRegister
    {
        public PatientRegister()
        {
            //For Emergency patient
            PatientName = "Unknown";
            PhoneNumber = "Unknown";
        }
        [Key]
        public int PatientID { get; set; }

        public string? PatientIdentityNumber { get; set; } //auto populate by Number generator helper

        //patient info
        [Required(ErrorMessage = "Enter Patient Name")]
        [StringLength(100, ErrorMessage = "Please do not enter values over 100 characters")]
        public string PatientName { get; set; } = default!;

        [Required, EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
        
        [StringLength(500)]
        public string? Address { get; set; }

        [Required, RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must be 11 digits.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email format is not valid.")]
        public string? Email { get; set; } = string.Empty;

        [NotMapped]
        public  ICollection<Prescription?> Prescriptions { get; set; } = new List<Prescription?>();
        [NotMapped]
        public ICollection<IndoorPatient?> IndoorPatients { get; set; } = new List<IndoorPatient?>();

        //List<Report Info>        //add this table first
    }


    public enum Gender
    {
        [Description("Male")]
        Male = 1,

        [Description("Female")]
        Female,

        [Description("Other")]
        Other,

        [Description("Prefer Not to Say")]
        PreferNotToSay
    }
}
