using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AdmissionDateMustBeOnOrAfterBirthDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var admissionDate = (DateTime?)value;
            var birthDateProperty = validationContext.ObjectType.GetProperty("DateOfBirth");
            var birthDate = (DateTime?)birthDateProperty.GetValue(validationContext.ObjectInstance, null);

            if (admissionDate.HasValue && birthDate.HasValue && admissionDate.Value < birthDate.Value)
            {
                return new ValidationResult("Admission date cannot be earlier than the birth date.");
            }

            return ValidationResult.Success;
        }
    }

}
