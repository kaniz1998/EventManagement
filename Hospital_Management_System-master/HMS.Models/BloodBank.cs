using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class BloodBank
    {
        [Key]
        public int BloodBankID { get; set; }
        public string BloodType { get; set; } = default!;
        public int StockQuantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string DonorName { get; set; } = default!;
    }
}
