using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HMS.Models
{
    public class UnidentifiedDeadBody
    {
        [Key]
        public int UnIdenfiedDeadBodyID { get; set; }

        [Display(Name = "Tag Number")]
        public int TagNumber { get; set; }

        [Display(Name = "Name of dead person")]
        public string? DeceasedName { get; set; } = default!;

        [Column(TypeName = "date")]
        [Display(Name = "Date of death")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DateOfDeath { get; set; }

        [StringLength(200, ErrorMessage = "Please do not enter values over 200 characters")]
        public string? CauseOfDeath { get; set; } = default!;
    }
}
