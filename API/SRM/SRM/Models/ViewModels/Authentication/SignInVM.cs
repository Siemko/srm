using System.ComponentModel.DataAnnotations;

namespace Azynmag.Models.ViewModels.Authentication
{
    public class SignInVM
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
