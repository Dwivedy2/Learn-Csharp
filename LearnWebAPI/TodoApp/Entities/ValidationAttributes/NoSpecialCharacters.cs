using Constants;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Entities.ValidationAttributes
{
    public class NoSpecialCharacters : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext context)
        {
            if (value == null)
                return ValidationResult.Success;

            string val = value.ToString();
            if (Regex.IsMatch(val, Expressions.SpecialCharacters))
            {
                return new ValidationResult("No special characters are allowed");
            }

            return ValidationResult.Success;
        }
    }
}
