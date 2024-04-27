using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Symptom
    {
        public int SymptomId { get; set; }
        public string SymptomName { get; set; } = default!;
        public ICollection<MasterSymptomsEntry> masterSymptomsEntries { get; set; } = new List<MasterSymptomsEntry>();
        //nev
        //public  ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }
}
