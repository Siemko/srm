using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SRM.Models.ViewModels.Authentication
{
    public class RemindPasswordVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
