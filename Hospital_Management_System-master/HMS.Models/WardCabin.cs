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
    public class WardCabin
    {
        [Key]
        public int WardID { get; set; }

        [Required(ErrorMessage = "Please enter medical ward name")]
        [StringLength(50, ErrorMessage = "Please do not enter values over 50 characters")]
        public string WardCabinName { get; set; } = default!;

        [EnumDataType(typeof(WardCabinType))]
        public WardCabinType WardCabinType { get; set; }

        [ForeignKey("Departments")]
        public int DepartmentID { get; set; }
        //nev
        [JsonIgnore]
        public  Department? Departments { get; set; } = default!;
        [JsonIgnore]
        public  ICollection<Bed> Beds { get; set; }=new List<Bed>();
    }
    public enum WardCabinType
    {
        Ward = 1, SingleCabin = 2, DoubleCabin = 3
    }
}
