
using System.ComponentModel.DataAnnotations;

namespace MEGZ_Web_Api.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        public bool rememberMe { get; set; }
    }
}
