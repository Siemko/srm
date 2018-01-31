using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SRM.Common.Constants;
using SRM.Models.ViewModels.Chat;
using SRM.Models.ViewModels.Event;
using SRM.Services.Contracts.Accounts;
using SRM.Services.Interfaces;

namespace SRM.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet, Authorize(UserRole.Starosta)]
        public IActionResult Get()
        {
            return GetResult(() => _eventService.GetEvents(), r => r.Events);
        }

        [HttpGet, Route("categories")]
        public IActionResult GetCategories()
        {
            return GetResult(() => _eventService.GetEventCategories(), r => r.EventCategories);
        }

        [HttpPost, Authorize(UserRole.Starosta)]
        public IActionResult Create([FromBody]EventVM eventViewModel)
        {
            var model = new EventModel
            {
                Name = eventViewModel.Name,
                CategoryId = eventViewModel.CategoryId,
                Description = eventViewModel.Description,
                MaxNumberOfPerson = eventViewModel.MaxNumberOfPerson
            };
            return GetResult(() => _eventService.AddEvent(model), r => r);
        }

        [HttpPut, Route("{eventId}/activate"), Authorize(UserRole.Starosta)]
        public IActionResult ActivateEvent(int eventId)
        {
            return GetResult(() => _eventService.ActivateEvent(eventId), r => r);
        }

        [HttpPut, Route("{eventId}/disable"), Authorize(UserRole.Starosta)]
        public IActionResult DisableEvent(int eventId)
        {
            return GetResult(() => _eventService.DisableEvent(eventId), r => r);
        }

        [HttpGet, Route("activated")]
        public IActionResult GetActivatedEvents()
        {
            return GetResult(() => _eventService.GetActivatedEvents(), r => r.Events);
        }

        [HttpPut, Route("{eventId}/assign-user/{userId}")]
        public IActionResult AssignToEvent(int eventId, int userId)
        {
            return GetResult(() => _eventService.AssignToEvent(eventId, userId), r => r);
        }

        [HttpPut, Route("{eventId}/remove-user/{userId}"), Authorize(Roles = UserRole.Starosta)]
        public IActionResult RemoveUserFromEvent(int eventId, int userId)
        {
            return GetResult(() => _eventService.RemoveUserFromEvent(eventId, userId), r => r);
        }
    }
}
