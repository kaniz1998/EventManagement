using HMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{

    public enum DosageForms
    {
        Liquid = 1, Tablet, Capsules, Cream, Suppositories, Drops, Inhalers, Injection
    }
    public enum MedicineType
    {
        Allopathy = 1, Homeopathy
    }

    public class Medicine
    {
        [Key]
        public int MedicineID { get; set; }
        public string MedicineName { get; set; } = default!;
        public string Weight { get; set; }

        [EnumDataType(typeof(MedicineType))]
        public MedicineType MedicineType { get; set; }
        [EnumDataType(typeof(DosageForms))]
        public DosageForms DosageForms { get; set; }

        public DateTime ExpireDate { get; set; }
        public int Quantity { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SellPrice { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; }
        [ForeignKey("MedicineGeneric")]
        public int MedicineGenericID { get; set; } // Foreign key
        [NotMapped]
        public List<MedicineGeneric?> MedicineGeneric { get; set; } = new List<MedicineGeneric?>();
        [ForeignKey("Manufacturer")]
        public int ManufacturerID { get; set; } // Foreign key
        [NotMapped]
        public List<Manufacturer?> Manufacturer { get; set; } = new List<Manufacturer?>();
        [NotMapped]
       
        public  ICollection<MasterMedicineEntry> MasterMedicineEntries { get; set; } = new List<MasterMedicineEntry>();
    }
}
