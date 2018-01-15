using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRM.Core.Entities.Identity
{
    [Table("Users")]
    public class User : IdentityUser<int>
    {
        public Guid? ResetPasswordGuid { get; set; }

        [Required, ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        [Required, ForeignKey("StudentGroup")]
        public int StudentGroupId { get; set; }
        public StudentGroup StudentGroup { get; set; }
    }
}
