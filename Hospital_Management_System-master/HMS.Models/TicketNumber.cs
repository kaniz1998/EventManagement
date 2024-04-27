using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HMS.Models
{
    public class Ticket
    {

        [Key]
        public int TicketID { get; set; }

        [Display(Name = "Outdoor Ticket Number")]
        public string? TicketNumber { get; set; } = default!;

        public DateTime? TicketDate { get; set; }
    }
}
