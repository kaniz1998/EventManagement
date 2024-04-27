using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class DrawerInfo
    {
        public int DrawerInfoID { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Received Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ReceivedDate { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ReleaseDate { get; set; }
        // Deadbody info
        public bool IsPatient { get; set; }

        [ForeignKey("Drawer")]
        public int DrawerID { get; set; }
        public  Drawer Drawer { get; set; }

        [ForeignKey("PatientRegister")]
        public int? PatientID { get; set; }
        public  PatientRegister? PatientRegister { get; set; }

        [ForeignKey("UnidentifiedDeadBody")]
        public int? UnidentifiedDeadBodyID { get; set; }
        public  UnidentifiedDeadBody? UnidentifiedDeadBody { get; set; }
    }
}
