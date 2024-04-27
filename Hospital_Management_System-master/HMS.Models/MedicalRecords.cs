using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class MedicalRecords
    {
        [Key]
        public int MedicalRecordsID { get; set; }
        public bool PatientType { get; set; } //indore/outdoor -- enum?
        public DateTime RecordDate { get; set; }
        public string MedicalHistory { get; set; } = default!; //prescription history + other history
        //[ForeignKey("Patient")]
        public int? PatientID { get; set; }//for patient basic info
        [NotMapped]
        public PatientRegister? Patient { get; set; } = default!;

        //add prescription id fk

        //controller not done

    }
}
