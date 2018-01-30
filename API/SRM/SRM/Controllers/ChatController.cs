using Microsoft.AspNetCore.Mvc;
using SRM.Models.ViewModels.Chat;
using SRM.Models.ViewModels.User;
using SRM.Services.Contracts.Chats.Models;
using SRM.Services.Contracts.Users;
using SRM.Services.Interfaces;

namespace SRM.Controllers
{
    public class ChatController : BaseController
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return GetResult(() => _chatService.Get(), r => r.Chats);
        }

        [HttpGet, Route("{chatId}")]
        public IActionResult Get(int chatId)
        {
            return GetResult(() => _chatService.Get(chatId), r => r.Chat);
        }

        [HttpPost]
        public IActionResult Create([FromBody]ChatVM chatViewModel)
        {
            if (!ModelState.IsValid)
                return RequestModelIsIncorrect();
            return GetResult(() => _chatService.CreateChat(chatViewModel.MapToChatModel()), r => r);
        }

        [HttpPut, Route("{chatId}/left")]
        public IActionResult LeftChannel(int chatId)
        {
            return GetResult(() => _chatService.LeftChat(chatId), r => r);
        }

        [HttpPut, Route("{chatId}/assign")]
        public IActionResult AssignToChat(int chatId)
        {
            return GetResult(() => _chatService.AssignToChat(chatId), r => r);
        }

        [HttpPost, Route("{chatId}/message")]
        public IActionResult AddMessage([FromBody]MessageVM messageViewModel, int chatId)
        {
            if (!ModelState.IsValid)
                return RequestModelIsIncorrect();
            var model = new MessageModel
            {
                ChatId = chatId,
                Content = messageViewModel.Content
            };
            return GetResult(() => _chatService.AddMessage(model), r => r);
        }

        [HttpDelete, Route("{chatId}/message/{messageId}")]
        public IActionResult DeleteMessage(int chatId, int messageId)
        {
            return GetResult(() => _chatService.RemoveMessage(messageId), r => r);
        }
    }
}
