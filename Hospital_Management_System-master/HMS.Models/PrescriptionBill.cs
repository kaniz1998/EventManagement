using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.Models
{
    public class PrescriptionBill    
    {
        [Key]
        public int PrescriptionBillID { get; set; }

        [ForeignKey("Prescription")]
        public int PrescriptionID { get; set; }

        [ForeignKey("PatientRegister")]
        public int PatientID { get; set; }

        public int ServiceID { get; set; }//FK

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PB_Subtotal { get; set; }

        // Navigation properties
        public  ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
        public  PatientRegister PatientRegisters { get; set; } // only need PatientID, then why ?
    }
}
