using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class MasterMedicineEntry
    {
        public int MasterMedicineEntryID { get; set; }

        [ForeignKey("Prescription")]
        public int PrescriptionID { get; set; }
        [ForeignKey("Medicine")]
        public int MedicineID { get; set; }
        public bool IsPrescribed { get; set; }

        public  Prescription Prescription { get; set; }
        public  Medicine Medicine { get; set; }  
    }
}
