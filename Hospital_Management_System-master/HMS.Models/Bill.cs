using HMS.Models.Attributes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HMS.Models
{
	public class Bill
	{
		public int BillId { get; set; }
		//[ForeignKey("PatientRegisters")]
		public int? PatientIdentityNumber { get; set; }
		public int? PrescriptionNumber { get; set; }

		[Required, Range(0, Double.MaxValue, ErrorMessage = "Bill Amount must be greater than 0")]
		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(18,2)")]
		public decimal BillAmount { get; set; }

		[Range(0, 50, ErrorMessage = "Discount cannot be over 50%")]
		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(18,2)")]
		public decimal? Discount { get; set; }

		public decimal? NetAmount => Discount.HasValue ? BillAmount - (BillAmount * (Discount.Value / 100)) : BillAmount;

		[PaidAmountValidation]
		[Required, Range(0, Double.MaxValue, ErrorMessage = "Paid Amount must be greater than 0")]
		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(18,2)")]
		public decimal PaidAmount { get; set; }

		[DueAmountValidation]
		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(18,2)")]
		public decimal? Due => (NetAmount ?? 0) - PaidAmount;

		[Required]
		[EnumDataType(typeof(PaymentMethod))]
		public PaymentMethod PaymentMethod { get; set; }

		[Required]
		[EnumDataType(typeof(PaymentStatus))]
		public PaymentStatus PaymentStatus { get; set; } = default!;

		[Required, Column(TypeName = "date")]
		[Display(Name = "Treatment Date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime BillDate { get; set; }

		public bool isInsurance { get; set; }

		[StringLength(500)]
		public string? InsuranceInfo { get; set; }

		[StringLength(200)]
		public string? BillingAddress { get; set; } = default!;

		[StringLength(500)]
		public string? BillingNotes { get; set; } = default!;

		[Required, StringLength(100)]
		public string PreparedBy { get; set; } = default!;

		public string? MedicineBill { get; set; } = default!;
		public string? TestBill { get; set; } = default!;
		public string? TakenServiceBill { get; set; } = default!;

		// Navigation properties
		[NotMapped]
		public PatientRegister? PatientRegisters { get; set; } = default!;

		//public ICollection<Outdoor?> Outdoors { get; set; } = new List<Outdoor?>();

		//public ICollection<MedicineBill> MedicineBill { get; set; } = new List<MedicineBill>();

	}
	public enum PaymentMethod
	{
		[Display(Name = "Processing")]
		Processing = 0,

		[Display(Name = "Cash")]
		Cash,

		[Display(Name = "Bank Card")]
		BankCard,

		[Display(Name = "Bank Check")]
		BankCheck,

		[Display(Name = "BKash")]
		BKash,

		[Display(Name = "Rocket")]
		Rocket,

		[Display(Name = "Nagad")]
		Nagad,

		[Display(Name = "Foreign Currency")]
		ForeignCurrency
	}

	public enum PaymentStatus
	{
		[Display(Name = "Due")]
		Due = 0,

		[Display(Name = "Paid")]
		Paid,

		[Display(Name = "Waived")]
		Waived
	}
}


//public decimal CalculateDiscountedPrice()
//{
//	if (Discount.HasValue)
//	{
//		// If Discount has a value, apply the discount
//		return BillAmount * (1 - Discount.Value);
//	}
//	else
//	{
//		// If Discount is null, no discount is applied
//		return BillAmount;
//	}
//}

//[NetAmountValidation]
//public decimal? NetAmount => BillAmount - (Discount ?? 0);
