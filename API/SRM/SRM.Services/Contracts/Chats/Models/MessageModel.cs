using SRM.Services.Contracts.Users;

namespace SRM.Services.Contracts.Chats.Models
{
    public class MessageModel
    {
        public UserModel Author { get; set; }
        public string Content { get; set; }
    }
}
