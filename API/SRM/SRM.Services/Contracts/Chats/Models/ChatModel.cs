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

        public ChatModel()
        { }

        public ChatModel(Chat chat)
        {
            Id = chat.Id;
            Name = chat.Name;
            Users = chat.Users.Select(u => 
            {
                return new UserModel
                {
                    Name = u.Name,
                    Surname = u.Surname
                };
            }).ToList();
        }

        public ChatModel(Chat chat, ICollection<Message> messages)
        {
            Id = chat.Id;
            Name = chat.Name;
            Messages = messages.OrderByDescending(m => m.CreatedAt).Select(m => 
            {
                return new MessageModel()
                {
                    Content = m.Content,
                    CreatedAt = m.CreatedAt,
                    Author = new UserModel
                    {
                        Id = m.User.Id
                    }
                };
            }).ToList();
        }
    }
}
