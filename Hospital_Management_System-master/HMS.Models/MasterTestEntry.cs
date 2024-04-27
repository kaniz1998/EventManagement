using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class MasterTestEntry
    {
        public int MasterTestEntryID { get; set; }
        [ForeignKey("Prescription")]
        public int PrescriptionID { get; set; }
        [ForeignKey("Test")]
        public int TestID { get; set; }
        public bool IsDone { get; set; }

        public  Prescription Prescription { get; set; }
        public  Test Test { get; set; }

    }
}
