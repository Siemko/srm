using SRM.Services.Contracts;
using SRM.Services.Contracts.Chats;
using SRM.Services.Contracts.Chats.Models;

namespace SRM.Services.Interfaces
{
    public interface IChatService
    {
        GetChatsResponse Get();
        GetChatResponse Get(int chatId);
        CreateChatResponse CreateChat(ChatModel model);
        BaseContractResponse AssignToChat(int chatId);
        BaseContractResponse LeftChat(int chatId);
        BaseContractResponse AddMessage(MessageModel model);
        BaseContractResponse RemoveMessage(int messageId);
    }
}
