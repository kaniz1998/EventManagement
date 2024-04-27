using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.Models
{
	public class TakenService
	{
		public int TakenServiceId { get; set; }
		public string TakenServiceName { get; set; } = default!;

		public DateTime Date { get; set; }
		public int PatientID { get; set; }

		[Required, Range(0, Double.MaxValue, ErrorMessage = "Price Amount must be greater than 0")]
		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(18,2)")]
		public decimal? Price { get; set; }

		public bool IsComplete { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public decimal? PaidAmount { get; set; }

		[NotMapped]
		public DueCalculator DueCalculator { get; } = new DueCalculator();

		[Column(TypeName = "decimal(18, 2)")]
		public decimal? Due => DueCalculator.CalculateDue(Price, PaidAmount);
	}
}