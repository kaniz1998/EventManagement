using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class DischargeTransfer
    {
        [Key]
        public int DT_ID { get; set; }
        //[ForeignKey("PatientRegister")]
        public int? PatientID { get; set; }
        public DateTime DischargeDate { get; set; }
        public string DischargeSummary { get; set; } = default!;
        [NotMapped]
        public PatientRegister? Patient { get; set; } = default!;
    }
}
