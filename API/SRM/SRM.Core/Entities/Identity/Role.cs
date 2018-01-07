using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRM.Core.Entities.Identity
{
    [Table("Roles")]
    public class Role : IdentityRole<int>
    {
    }
}
