using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRM.Core.Entities.Identity
{
    [Table("Users")]
    public class User : IdentityUser<int>
    {
    }
}
