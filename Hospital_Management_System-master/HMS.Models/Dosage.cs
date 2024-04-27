using HMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Dosage
    {
        [Key]
        public int DosageID { get; set; }

        [Required(ErrorMessage = "Enter Dose")]
        [StringLength(50, ErrorMessage = "Please do not enter values over 50 characters")]
        public string DosageName { get; set; } = default!;
        public  ICollection<MasterDosageEntry> MasterDosageEntries { get; set; } = new List<MasterDosageEntry>();

        //public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }
}
