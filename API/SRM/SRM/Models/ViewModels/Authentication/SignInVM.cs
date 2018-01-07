using System.ComponentModel.DataAnnotations;

namespace SRM.Models.ViewModels.Authentication
{
    public class SignInVM
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
