using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class MedicineGeneric
    {
        [Key]
        public int MedicineGenericID { get; set; }
        public string MedicineGenericNames { get; set; } = default!;
    }
}
