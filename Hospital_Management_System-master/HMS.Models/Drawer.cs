using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Drawer
    {
        public int DrawerID { get; set; }

        [Display(Name = "Drawer Number")]
        public string DrawerNo { get; set; } = default!;

        [Display(Name = "Drawer Condition")]
        public DrawerCondition DrawerCondition { get; set; }

        public bool IsOccupied { get; set; }

        [ForeignKey("Morgue")]
        public int MorgueID { get; set; }

        public  Morgue? Morgue { get; set; }
    }

    public enum DrawerCondition
    {

        [Display(Name = "Clean")]
        Clean = 1,

        [Display(Name = "Dirty")]
        Dirty,

        [Display(Name = "Under Maintenance")]
        UnderMaintenance,

        [Display(Name = "Out of Service")]
        OutOfService
    }
}
