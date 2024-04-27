using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class OtherEmployee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Enter Employee Name")]
        [StringLength(100, ErrorMessage = "Please do not enter values over 100 characters")]
        public string OtherEmployeeName { get; set; } = default!;

        public OtherEmployeeType OtherEmployeeType { get; set; } = default!;

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

        public string Image { get; set; } = default!;

        [StringLength(200)]
        [Display(Name = "Education Info")]
        public string Education_Info { get; set; } = default!;

        [Required, RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must be 11 digits.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = default!;
    }
    public enum EmployeeStatus
    {
        [Display(Name = "Active Duty")]
        active = 1,

        [Display(Name = "Not Approved")]
        pending,

        [Display(Name = "Not Available")]
        abroad,

        [Display(Name = "On leave")]
        leave
    }

    public enum OtherEmployeeType
    {
        [Display(Name = "Janitor")]
        Janitor = 1,

        [Display(Name = "Word Boy")]
        Wordboy,

        [Display(Name = "Cashier")]
        Cashier,

        [Display(Name = "IT Support")]
        ITSupport,

        [Display(Name = "Maintenance")]
        Maintenance,

        [Display(Name = "Ambulance Driver")]
        Driver,

        others
    }
}
