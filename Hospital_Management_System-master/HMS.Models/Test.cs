
using HMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Test
    {
        [Key]
        public int TestID { get; set; }

        public string TestName { get; set; } = default!;

        public string TestType { get; set; } = default!;

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        //nav
        //public  ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
        public  ICollection<MedicalRecords> MedicalRecords { get; set; } = new List<MedicalRecords>();
        public  ICollection<Surgery> Surgeries { get; set; } = new List<Surgery>();
        public ICollection<ReportDetail> ReportDetails { get; set; } = new List<ReportDetail>();
        public  ICollection<MasterTestEntry> masterTestEntries { get; set; } = new List<MasterTestEntry>();
    }
}
