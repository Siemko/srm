using System;
using System.ComponentModel.DataAnnotations;

namespace SRM.Models.ViewModels.Authentication
{
    public class ResetPasswordVM
    {
        [Required]
        [StringLength(25, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        public Guid Guid { get; set; }
    }
}
