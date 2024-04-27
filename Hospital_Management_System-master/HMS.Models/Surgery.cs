
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using HMS.Models;

namespace HMS.Models
{
    public enum SurgeryType
    {
        Appendectomy = 1, Cholecystectomy, Hysterectomy, Mastectomy, GeneralSurgery
    }
    public class Surgery
    {
        [Key]
        public int SurgeryID { get; set; }

        [EnumDataType(typeof(SurgeryType))]
        public SurgeryType SurgeryType { get; set; } = default!; //enum

        [Column(TypeName = "date"),
         Display(Name = "Date"),
         DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
         ApplyFormatInEditMode = true)]
        public DateTime SurgeryDate { get; set; }

        //[ForeignKey("Doctor")]
        //public int DoctorID { get; set; }

        [Required(ErrorMessage = "Please enter medical Observations")]
        [StringLength(150, ErrorMessage = "Please do not enter values over 150 characters")]
        public string Observations { get; set; } = default!;

        [Required(ErrorMessage = "Please enter medical Postoperative_Diagnosis")]
        [StringLength(150, ErrorMessage = "Please do not enter values over 150 characters")]
        public string Postoperative_Diagnosis { get; set; } = default!;

        [ForeignKey("Prescription")]
        public int PrescriptionID { get; set; }
        //nev
        [JsonIgnore]
        //public  Doctor? Doctor { get; set; } = default!;
        public  Prescription? Prescriptions { get; set; } = default!;
    }
}
