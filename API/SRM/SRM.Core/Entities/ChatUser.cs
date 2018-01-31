using SRM.Core.Entities.Identity;

namespace SRM.Core.Entities
{
    public class ChatUser
    {
        public int ChatId { get; set; }
        public Chat Chat { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
