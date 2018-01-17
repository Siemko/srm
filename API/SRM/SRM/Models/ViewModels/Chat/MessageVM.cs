using SRM.Services.Contracts.Chats.Models;
using SRM.Services.Contracts.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRM.Models.ViewModels.Chat
{
    public class MessageVM
    {
        public int UserId { get; set; }
        public string Content { get; set; }
    }
}
