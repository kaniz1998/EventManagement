using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class MasterDosageEntry
    {
        public int MasterDosageEntryID { get; set; }
        [ForeignKey("Prescription")]
        public int PrescriptionID { get; set; }
        [ForeignKey("Dosage")]
        public int DosageID { get; set; }
        public  Prescription Prescription { get; set; }
        public  Dosage Dosage { get; set; }  
    }
}
