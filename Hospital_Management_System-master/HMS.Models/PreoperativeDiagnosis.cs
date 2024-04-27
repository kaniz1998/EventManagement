
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class PreoperativeDiagnosis
    {
        public int PreoperativeDiagnosisID { get; set; }
        public string PreoperativeDiagnosisName { get; set; } = default!;
        //nev
        [JsonIgnore]
        public ICollection<Surgery> Surgeries { get; set; } = new List<Surgery>();
    }
}
