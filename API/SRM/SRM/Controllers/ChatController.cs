using Microsoft.AspNetCore.Mvc;
using SRM.Models.ViewModels.Chat;
using SRM.Models.ViewModels.User;
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
        public ActionResult Get()
        {
            //TODO
            return Ok();
        }

        [HttpGet, Route("channel")]
        public ActionResult GetChannel(int chanelId)
        {
            //TODO
            return Ok();
        }

        [HttpPost, Route("channel")]
        public ActionResult CreateChannel([FromBody]ChatVM chatViewModel)
        {
            if (!ModelState.IsValid)
                return RequestModelIsIncorrect();
            //TODO
            return Ok();
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
