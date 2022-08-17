using MEGZ_Web_Api.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MEGZ_Web_Api.ViewModels
{
    public class AddEmployeeFormViewModel
    {
        public int? Id { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Minimum length is 10")]
        [RegularExpression("^((?!^Name$)[a-zA-Z '])+$", ErrorMessage = "Name must be properly formatted.")]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^[A-Za-z0-9._%+-]*@[A-Za-z0-9.-]*\\.[A-Za-z0-9-]{2,}$",
        ErrorMessage = "Email must be properly formatted.")]
        [UniqueEmail]
        public string Email { get; set; }
        [Required]
        [MinLength(14, ErrorMessage = "Invalid National ID")]
        [MaxLength(14, ErrorMessage = "Invalid National ID")]
        [RegularExpression("[0-9]{14}", ErrorMessage = "Invalid National ID")]
        [UniqueSSN]
        public string SSN { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Minimum length is 10")]
        public string Address { get; set; }
        [BirthDateCheck]
        public DateTime Date { get; set; }
        public double Salary { get; set; }
        public string Nationality { get; set; }
        [RegularExpression("01[0125]{1}[0-9]{8}", ErrorMessage = "Invalid Contact Number")]
        [UniquePhoneNumber]
        public string Phone { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [AmountCheck]
        public float Bonus { get; set; }
        [Required]
        [AmountCheck]
        public float Discount { get; set; }
        [Required]
        public string CheckIn { get; set; }
        [Required]
        public string CheckOut { get; set; }
        [Required]
        [HireDateCheck]
        public DateTime HireDate { get; set; }
        public string? Profile { get; set; }
        [Required]      
        [ForeignKey("department")]
        public int Department_Id { get; set; }
    }

    
}
