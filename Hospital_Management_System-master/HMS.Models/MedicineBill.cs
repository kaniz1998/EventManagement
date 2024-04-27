using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace HMS.Models
{
	public class MedicineBill
	{
		public int MedicineBillId { get; set; }

		[Required(ErrorMessage = "Enter Medicine Name")]
		[StringLength(100, ErrorMessage = "Please do not enter values over 100 characters")]
		public string MedicineName { get; set; }

		public int? PrescriptionID { get; set; }

		public int MedicineCount { get; set; }

		[Required, Range(0, Double.MaxValue, ErrorMessage = "Price Amount must be greater than 0")]
		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(18,2)")]
		public decimal? Price { get; set; }

		[Required, Range(0, Double.MaxValue, ErrorMessage = "Net Price Amount must be greater than 0")]
		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(18,2)")]
		[NotMapped]
		public decimal NetPrice { get; set; }

		public bool IsComplete { get; set; }
		[Column(TypeName = "decimal(18, 2)")]
		public decimal? PaidAmount { get; set; }

		// Include a reference to the DueCalculator
		[NotMapped]
		public DueCalculator DueCalculator { get; } = new DueCalculator();

		[Column(TypeName = "decimal(18, 2)")]
		// Use the DueCalculator to calculate the Due property
		public decimal? Due => DueCalculator.CalculateDue(NetPrice, PaidAmount);
	}

	public class DueCalculator
	{
		public decimal? CalculateDue(decimal? NetPrice, decimal? paidAmount)
		{
			return NetPrice.HasValue && paidAmount.HasValue ? NetPrice.Value - paidAmount.Value : 0;
		}
	}

}
