using System;
using System.ComponentModel.DataAnnotations;

namespace HMS.Models.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public sealed class NetAmountValidationAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var bill = (Bill)validationContext.ObjectInstance;

			if (bill.BillAmount - (bill.Discount ?? 0) < 0)
			{
				return new ValidationResult("Net Amount cannot be negative.");
			}

			return ValidationResult.Success;
		}
	}
}
