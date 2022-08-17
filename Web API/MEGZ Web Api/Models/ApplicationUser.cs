using Microsoft.AspNetCore.Identity;
namespace MEGZ_Web_Api.Models
{
    public class ApplicationUser:IdentityUser
    {
        public ApplicationUser()
        {
            EmployeeExceptions = new List<EmployeeException>();
        }
        public string Name { get; set; }
        public virtual List<EmployeeException> EmployeeExceptions { get; set; }
    }
}
