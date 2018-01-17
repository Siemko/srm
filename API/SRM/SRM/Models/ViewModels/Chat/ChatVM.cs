using SRM.Services.Contracts.Chats.Models;
using SRM.Services.Contracts.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRM.Models.ViewModels.Chat
{
    public class ChatVM
    {
        public string Name { get; set; }
        public ICollection<int> UsersIds { get; set; }

        public ChatModel MapToChatModel()
        {
            var result = new ChatModel
            {
                Name = this.Name,
                Users = new List<UserModel>()
            };
            foreach (var id in this.UsersIds)
                result.Users.Add(new UserModel { Id = id });
            return result;
        }
    }
}
