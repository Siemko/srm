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

        public bool Active { get; set; }

        public string Description { get; set; }

        [StringLength(10)]
        public string StudentNumber { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(30)]
        public string Surname { get; set; }

        [Required, ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        [ForeignKey("StudentGroup")]
        public int? StudentGroupId { get; set; }
        public StudentGroup StudentGroup { get; set; }

        public ICollection<EventUser> EventUsers { get; set; }
        public ICollection<ChatUser> ChatUsers { get; set; }
    }
}
