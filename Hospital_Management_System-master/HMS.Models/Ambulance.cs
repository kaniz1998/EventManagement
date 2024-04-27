using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HMS.Models
{
    public class Ambulance
    {
        [Key]
        public int AmbulanceID { get; set; }
        [Required(ErrorMessage = "Please enter Ambulance Number")]
        [Display(Name = "Ambulance Number")]
        public string AmbulanceNumber { get; set; } = default!;
        [Required(ErrorMessage = "Please enter Last Location")]
        [Display(Name = "Las tLocation")]
        public string LastLocation { get; set; } = default!;
        public bool Availability { get; set; }
        public  ICollection<OtherEmployee> OtherEmployees { get; set; } = new List<OtherEmployee>();
    }
}
