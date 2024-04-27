using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class PaidAmountValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var bill = (Bill)validationContext.ObjectInstance;
            if (bill.PaidAmount > bill.NetAmount)
            {
                return new ValidationResult("Paid Amount cannot be greater than Bill Amount");
            }

            return ValidationResult.Success;
        }
    }

}
