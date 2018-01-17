using System;
using System.Collections.Generic;
using System.Text;

namespace SRM.Services.Contracts.Chats.Models
{
    public class ChatModel
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public ICollection<MessageModel> Messages { get; set; }
    }
}
