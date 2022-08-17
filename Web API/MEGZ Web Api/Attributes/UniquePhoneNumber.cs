using System.ComponentModel.DataAnnotations;
using MEGZ_Web_Api.Models;
using MEGZ_Web_Api.ViewModels;
namespace MEGZ_Web_Api.Attributes
{
    public class UniquePhoneNumber:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DBContext dBContext = new DBContext();
            Employee employee = dBContext.Employee.Where(n => n.Phone == (string)value).FirstOrDefault();
            AddEmployeeFormViewModel currentEmployee = validationContext.ObjectInstance as AddEmployeeFormViewModel;
            if (employee != null && employee.Id != currentEmployee.Id)
            {
                return new ValidationResult("This Phone number already used");
            }
            return ValidationResult.Success;
        }
    }
}
