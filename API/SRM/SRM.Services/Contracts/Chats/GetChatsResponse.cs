using SRM.Services.Contracts.Chats.Models;
using System.Collections.Generic;

namespace SRM.Services.Contracts.Chats
{
    public class GetChatsResponse : BaseContractResponse
    {
        public ICollection<ChatModel> Chats { get; set; }
    }
}
