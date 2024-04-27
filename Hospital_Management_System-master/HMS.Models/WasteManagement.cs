using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class WasteManagement
    {
        [Key]
        public int WasteID { get; set; }

        public WasteType WasteType { get; set; }

        [Column(TypeName = "date"),
        Display(Name = "Disposal Date"),
        DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
        ApplyFormatInEditMode = true)]
        public DateTime DisposalDate { get; set; }

        public string DisposalMethod { get; set; } = default!;

        public int Quantity { get; set; }

        [Column(TypeName = "date"),
        Display(Name = "NextSchedule Date"),
        DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
        ApplyFormatInEditMode = true)]
        public DateTime NextScheduleDate { get; set; }

        [Display(Name = "Phone No")]
        public string ContactNumber { get; set; } = default!;
    }
    public enum WasteType
    {
        [Display(Name = "General Waste")]
        General = 1,

        [Display(Name = "Biological Waste")]
        Biological = 2,

        [Display(Name = "Hazardous Waste")]
        Hazardous = 3,

        [Display(Name = "Electronic Waste")]
        Electronic = 4,

        [Display(Name = "Pharmaceutical Waste")]
        Pharmaceutical = 5,

        [Display(Name = "Sharps Waste")]
        Sharps = 6,

        [Display(Name = "Chemical Waste")]
        Chemical = 7,

        [Display(Name = "Radiological Waste")]
        Radiological = 8,
    }
    
}
