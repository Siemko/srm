using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Azynmag.Core.Entities.Identity
{
    [Table("Roles")]
    public class Role : IdentityRole<int>
    {
    }
}
