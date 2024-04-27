using HMS.Models;
using System;

namespace Hospital_Management_System.Helpers
{
    public class OutdoorHelper
    {
        public int PatientID { get; set; }
        public TreatmentType TreatmentType { get; set; }
        public DateTime TreatmentDate { get; set; }
        public string? Remarks { get; set; }
        public bool IsAdmissionRequired { get; set; }

        public Outdoor GetOutdoor()
        {
            Outdoor outdoor = new Outdoor
            {
                PatientID = this.PatientID,
                TreatmentType = this.TreatmentType,
                TreatmentDate = this.TreatmentDate,
                Remarks = this.Remarks,
                IsAdmissionRequired = this.IsAdmissionRequired
            };

            return outdoor;
        }

        public void UpdateOutdoor(Outdoor existingOutdoor)
        {
            existingOutdoor.PatientID = this.PatientID;
            existingOutdoor.TreatmentType = this.TreatmentType;
            existingOutdoor.TreatmentDate = this.TreatmentDate;
            existingOutdoor.Remarks = this.Remarks;
            existingOutdoor.IsAdmissionRequired = this.IsAdmissionRequired;
        }
    }
}
