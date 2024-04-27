using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Service
    {
        [Key]
        public int ServiceID { get; set; }

        [StringLength(100)]
        public string ServiceName { get; set; } = default!;

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ServiceCharge { get; set; }
    }
}
