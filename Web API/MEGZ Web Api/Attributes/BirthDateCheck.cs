using System.ComponentModel.DataAnnotations;
using MEGZ_Web_Api.Models;
using MEGZ_Web_Api.ViewModels;
namespace MEGZ_Web_Api.Attributes
{
    public class BirthDateCheck: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            AddEmployeeFormViewModel employee = validationContext.ObjectInstance as AddEmployeeFormViewModel;
            DateTime BirthDate = Convert.ToDateTime(value);
            int x = DateTime.Compare(BirthDate, employee.HireDate);
            if (x == 0 || x > 0 )
                return new ValidationResult("Invalid Date");
            return ValidationResult.Success;
        }
    }
}
