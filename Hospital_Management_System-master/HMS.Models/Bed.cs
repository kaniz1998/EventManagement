using HMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Bed
    {
        public int BedID { get; set; }

        public string BedNumber { get; set; } = default!;


        public bool IsOccupied { get; set; }

        [ForeignKey(nameof(WardCabin))]
        public int? WardCabinID { get; set; }
        //nev
        public WardCabin? WardCabin { get; set; } = default!;
        [JsonIgnore]
        public ICollection<IndoorPatient> IndoorPatients { get; set; } = new List<IndoorPatient>();
    }
}
