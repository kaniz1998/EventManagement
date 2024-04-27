using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Morgue
    {
        [Key]
        public int MorgueID { get; set; }

        [Required(ErrorMessage = "Morgue Name")]
        [StringLength(100, ErrorMessage = "Please do not enter values over 100 characters")]
        public string MorgueName { get; set; } = default!;

        public int Capacity { get; set; } //drawer can't be exceed max capacity

        //if the morgue can handle infectious cases (Ex: corona dead body)
        public bool IsolationCapability { get; set; }

        public ICollection<Drawer> Drawers { get; set; } = new List<Drawer>();
    }

    ///concept
    //morgue id 1, Capacity = 50 Drawer
    //morgue id 2, Capacity = 100 Drawer
}
