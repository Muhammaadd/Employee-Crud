using System.ComponentModel.DataAnnotations;

namespace MEGZ_Web_Api.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(10,ErrorMessage ="minimum length is 10")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$",ErrorMessage ="invalid email")]
        public string Email { get; set; }
        [Required]
        //[RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[*.!@$%^&(){}[]:;<>,.?/~_+-=|\]).{8,32}$",ErrorMessage ="week password")]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        //[RegularExpression(@"/01210949994/gi", ErrorMessage ="invalid phone number")]
        public string PhoneNumber { get; set; }
    }
}
