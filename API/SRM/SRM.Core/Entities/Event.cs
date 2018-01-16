using SRM.Core.Entities.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRM.Core.Entities
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int? MaxNumberOfPerson { get; set; }

        public string Description { get; set; }

        public bool Activated { get; set; }

        [Required, ForeignKey("Category")]
        public int CategoryId { get; set; }
        public EventCategory Category { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
