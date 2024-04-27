using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class MasterSymptomsEntry
    {
        public int MasterSymptomsEntryID { get; set; }

        [ForeignKey("Prescription")]
        public int PrescriptionID { get; set; }
        [ForeignKey("Symptom")]
        public int SymptomId { get; set; }

        public  Prescription Prescription { get; set; }
        public  Symptom Symptom { get; set; }
    }
}
