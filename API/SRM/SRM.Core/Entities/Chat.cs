using SRM.Core.Entities.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SRM.Core.Entities
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        public ICollection<Message> Messages { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
