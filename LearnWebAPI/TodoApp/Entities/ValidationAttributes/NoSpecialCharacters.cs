using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Entities.ValidationAttributes
{
    public class NoSpecialCharacters : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext context)
        {
            var validationResult = new ValidationResult("");

            if (value != null)
            {
                string val = value.ToString();
                if (Regex.IsMatch(val, @"[^a-zA-Z0-9\s]"))
                {
                    validationResult.ErrorMessage = "No Special Characters are allowed";
                }
            }

            return validationResult;
        }
    }
}
