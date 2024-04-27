using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class AdmissionBill
    {
        [Key]
        public int AdmissionBillID { get; set; }

        [ForeignKey("IndoorPatient")]
        public int IndoorPatientID { get; set; }

        //Admission Date (auto property)

        [Column(TypeName = "date"),
         Display(Name = "Release Date"),
         DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
         ApplyFormatInEditMode = true)]
        public DateTime? ReleaseDate { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal AB_Subtotal { get; set; }

        // Navigation properties
        public IndoorPatient IndoorPatient { get; set; } 


        //
    }
}
