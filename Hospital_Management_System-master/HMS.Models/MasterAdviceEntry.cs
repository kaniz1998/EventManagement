using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class MasterAdviceEntry
    {
        public int MasterAdviceEntryID { get; set; }
        [ForeignKey("Prescription")]
        public int PrescriptionID { get; set; }
        [ForeignKey("Advice")]
        public int AdviceId { get; set; }

        public  Prescription Prescription { get; set; }
        public  Advice Advice { get; set; }  
    }
}
