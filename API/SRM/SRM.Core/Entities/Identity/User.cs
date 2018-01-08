using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRM.Core.Entities.Identity
{
    [Table("Users")]
    public class User : IdentityUser<int>
    {
        [Required, ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
