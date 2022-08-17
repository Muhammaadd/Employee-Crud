using System.ComponentModel.DataAnnotations;
using MEGZ_Web_Api.ViewModels;
using MEGZ_Web_Api.Models;
namespace MEGZ_Web_Api.Attributes
{
    public class HireDateCheck:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            AddEmployeeFormViewModel employee = validationContext.ObjectInstance as AddEmployeeFormViewModel;
            DateTime hireDate = Convert.ToDateTime(value);
            int x = DateTime.Compare(hireDate,employee.Date);
            int y = DateTime.Compare(hireDate, DateTime.Now);
            int z = DateTime.Compare(hireDate,DateTime.Now.AddYears(-8));
            if (x==0||x < 0||y>0||z<0)
                return new ValidationResult("Invalid Date");
            return ValidationResult.Success;
        }
    }
}
