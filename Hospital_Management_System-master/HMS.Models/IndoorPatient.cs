using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HMS.Models;
using HMS.Models.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Models
{
    public class IndoorPatient
    {

        public IndoorPatient()
        {
            IsDead = false;
        }
        [Key]
        public int IndoorPatientID { get; set; }

        //hospital info
        [StringLength(200)]
        [Display(Name = "Referred By")]
        public string ReferredBy { get; set; }

        [ForeignKey("Bed")]
        public int BedID { get; set; }

        [StringLength(500)]
        [Display(Name = "Insurance Information")]
        public string? InsuranceInfo { get; set; }

        [StringLength(500)]
        [Display(Name = "Admission Notes")]
        public string? AdmissionNotes { get; set; }

        public bool IsDead { get; set; }



        [ForeignKey("PatientRegister")]
        public int PatientID { get; set; }

        [ForeignKey("MedicalRecords")]
        public int? MedicalRecordsID { get; set; }

        // Navigation property for the patient
        [NotMapped]
        public  PatientRegister PatientRegisters { get; set; }

        // Navigation property for medical records
        [NotMapped]
        public  MedicalRecords MedicalRecords { get; set; }

        //AdmissionBill collection




        //patient info
        public string NIDnumber { get; set; }

        [Column(TypeName = "date"),
         Display(Name = "Admission Date"),
         DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
         ApplyFormatInEditMode = true)]
        public DateTime AdmissionDate { get; set; }



        [AdmissionDateMustBeOnOrAfterBirthDateAttribute] // custom validation
        [Column(TypeName = "date"),
         Display(Name = "Patient BirthDate"),
         DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
         ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required, RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must be 11 digits.")]
        [Display(Name = "Phone Number")]
        public string EmergencyContact { get; set; }

        [EnumDataType(typeof(BloodType))]
        public BloodType? BloodType { get; set; }

        public bool? IsTransferred { get; set; }

    }
    public enum BloodType
    {
        [Description("A+")]
        APositive = 1,

        [Description("A-")]
        ANegative,

        [Description("B+")]
        BPositive,

        [Description("B-")]
        BNegative,

        [Description("AB+")]
        ABPositive,

        [Description("AB-")]
        ABNegative,

        [Description("O+")]
        OPositive,

        [Description("O-")]
        ONegative
    }
}
