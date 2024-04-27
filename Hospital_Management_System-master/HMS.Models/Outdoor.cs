using HMS.Models;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Outdoor
    {
        public Outdoor()
        {
            TreatmentType = TreatmentType.Consultation;
        }
        [Key]
        public int OutdoorID { get; set; }

        [ForeignKey("PatientRegister")]
        public int? PatientID { get; set; }

        [EnumDataType(typeof(TreatmentType))]
        public TreatmentType TreatmentType { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Treatment Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime TreatmentDate { get; set; }

        public string? Remarks { get; set; } = default!;

        public bool IsAdmissionRequired { get; set; }


        public  PatientRegister? PatientRegister { get; set; }

        public void InitializeTreatmentType()
        {
            if (string.Equals(PatientRegister.PatientName, "Unknown", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(PatientRegister.PhoneNumber, "Unknown", StringComparison.OrdinalIgnoreCase))
            {
                TreatmentType = TreatmentType.Emergency;

                //Surgery surgery = new Surgery
                //{
                //    PatientID = this.PatientID
                      //need to initialize not null surgery property
                //};
            }
        }

    }
    public enum TreatmentType
    {
        [Display(Name = "Consultation")]
        Consultation = 1,

        [Display(Name = "Emergency")]
        Emergency,

        [Display(Name = "Minor Treatment")] // Ex: faint patient recovered after getting oxygen
        MinorTreatment,

        [Display(Name = "Vaccination")] //age prescription generate hobe, then medicine add, then PrescriptionBill
        Vaccination,

        [Display(Name = "Follow-up")] //follow-up report
        FollowUp,

        [Display(Name = "Dental Checkup")]
        DentalCheckup,

        other
    }

}
