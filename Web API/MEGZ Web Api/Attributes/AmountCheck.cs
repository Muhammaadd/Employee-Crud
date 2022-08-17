using System.ComponentModel.DataAnnotations;
using MEGZ_Web_Api.Models;
namespace MEGZ_Web_Api.Attributes
{
    public class AmountCheck: ValidationAttribute
    {
            protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
            {
                int amount = Convert.ToInt32(value);
                if (amount>5||amount<1)
                    return new ValidationResult("Number of hours must be in [1-5]");
            return ValidationResult.Success;
        }
        
    }
}
