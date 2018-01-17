using Microsoft.AspNetCore.Mvc;
using SRM.Models.ViewModels.Chat;
using SRM.Models.ViewModels.User;
using SRM.Services.Contracts.Chats.Models;
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

        [HttpPost, Route("channel")]
        public IActionResult Create([FromBody]ChatVM chatViewModel)
        {
            if (!ModelState.IsValid)
                return RequestModelIsIncorrect();
            return GetResult(() => _chatService.CreateChat(chatViewModel.MapToChatModel()), r => r.Chat);
        }

        [HttpPut, Route("channel/disable")]
        public ActionResult DisableChannel(int chatId)
        {
            //TODO
            return Ok();
        }

        [HttpPut, Route("channel/enable")]
        public ActionResult EnableChannel(int chatId)
        {
            //TODO
            return Ok();
        }
    }
}
