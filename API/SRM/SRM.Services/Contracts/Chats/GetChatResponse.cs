using SRM.Services.Contracts.Chats.Models;
using System.Collections.Generic;

namespace SRM.Services.Contracts.Chats
{
    public class GetChatResponse : BaseContractResponse
    {
        public ChatModel Chat { get; set; }
    }
}
