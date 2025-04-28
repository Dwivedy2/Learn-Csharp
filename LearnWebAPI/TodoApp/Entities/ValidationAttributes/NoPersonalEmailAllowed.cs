using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Entities.ValidationAttributes
{
    public class NoPersonalEmailAllowed : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            string val = value.ToString();
            if (Regex.IsMatch(val, @"^[\w.+\-]+@gmail\.com$"))
            {
                return new ValidationResult("gmails are not allowed");
            }

            return ValidationResult.Success;
        }
    }
}
