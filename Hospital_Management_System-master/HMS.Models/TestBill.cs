using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.Models
{
	public class TestBill
	{

		public int TestBillId { get; set; }

		[Required(ErrorMessage = "Enter Patient Name")]
		[StringLength(100, ErrorMessage = "Please do not enter values over 100 characters")]
		public string TestBillName { get; set; }

		public int? PrescriptionID { get; set; }

		[Required, Range(0, Double.MaxValue, ErrorMessage = "Price Amount must be greater than 0")]
		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(18,2)")]
		public decimal? Price { get; set; }

		public bool IsComplete { get; set; }

		[Required, Range(0, Double.MaxValue, ErrorMessage = "Paid Amount must be greater than 0")]
		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(18,2)")]
		public decimal? PaidAmount { get; set; }

		[NotMapped]
		public DueCalculator DueCalculator { get; } = new DueCalculator();

		public decimal? Due => DueCalculator.CalculateDue(Price, PaidAmount);
	}


}