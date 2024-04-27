using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Advice
    {
        public int AdviceId { get; set; }

        public string AdviceName { get; set; } = default!;
        [JsonIgnore]
        public  ICollection<MasterAdviceEntry> MasterAdviceEntries { get; set; } = new List<MasterAdviceEntry>();


        //nev
        //public  ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }
}   
