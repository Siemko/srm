using System.ComponentModel.DataAnnotations;

namespace SRM.Models.ViewModels.Authentication
{
    public class RemindPasswordVM
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}
