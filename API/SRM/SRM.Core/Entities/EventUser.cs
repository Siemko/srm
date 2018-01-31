using SRM.Core.Entities.Identity;

namespace SRM.Core.Entities
{
    public class EventUser
    {
        public int EventId { get; set; }
        public Event Event { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
