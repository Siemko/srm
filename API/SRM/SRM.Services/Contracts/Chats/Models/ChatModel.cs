using SRM.Core.Entities;
using SRM.Services.Contracts.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SRM.Services.Contracts.Chats.Models
{
    public class ChatModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MessageModel> Messages { get; set; }
        public ICollection<UserModel> Users { get; set; }

        public ChatModel(Chat chat)
        {
            Id = chat.Id;
            Name = chat.Name;
        }

        public ChatModel(Chat chat, ICollection<Message> messages)
        {
            Id = chat.Id;
            Name = chat.Name;
            messages = messages.Select(m => { return new MessageModel()
            {
                ChatId = m.ChatId,
                Content = m.Content,
                Author = new UserModel
                {
                    Id = m.User.Id
                }
            }}).ToList();
        }
    }
}
