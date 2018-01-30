using SRM.Services.Contracts.Users;
using System;

namespace SRM.Services.Contracts.Chats.Models
{
    public class MessageModel
    {
        public int ChatId { get; set; }
        public UserModel Author { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
