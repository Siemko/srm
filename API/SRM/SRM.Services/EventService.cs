using SRM.Core;
using SRM.Services.Interfaces;
using Microsoft.Extensions.Logging;
using SRM.Services.Contracts.Accounts;
using System.Linq;
using SRM.Common.Exceptions;
using SRM.Core.Entities;
using SRM.Services.Contracts;
using Microsoft.AspNetCore.Http;

namespace SRM.Services
{
    public class EventService : BaseService, IEventService
    { 
        public EventService(DefaultDbContext dbContext, 
            ILogger<EventService> logger,
            IHttpContextAccessor httpContextAccessor)
            : base(dbContext, logger, httpContextAccessor)
        {
        }

        public BaseContractResponse ActivateEvent(int eventId)
        {
            return ExecuteAction<BaseContractResponse>((response) =>
            {
                var ev = _dbContext.Events.FirstOrDefault(e => e.Id == eventId);
                if (ev == null)
                    throw new ResourceNotFoundException("Event not found.");
                ev.Activated = true;
                _dbContext.SaveChanges();
            });
        }

        public AddEventResponse AddEvent(EventModel model)
        {
            return ExecuteAction<AddEventResponse>((response) =>
            {
                if (_dbContext.Events.Any(e => e.Name.ToUpper() == model.Name.ToUpper()))
                    throw new DuplicateResourceException("Event exist.");

                if (_dbContext.EventCategories.FirstOrDefault(ec => ec.Id == model.CategoryId) == null)
                    throw new ResourceNotFoundException("Event category not exist.");

                var newEvent = new Event
                {
                    Name = model.Name,
                    CategoryId = model.CategoryId,
                    MaxNumberOfPerson = model.MaxNumberOfPerson,
                    Description = model.Description
                };

                _dbContext.Events.Add(newEvent);
                _dbContext.SaveChanges();
            });
        }

        public BaseContractResponse AssignToEvent(int eventId)
        {
            return ExecuteAction<GetEventsResponse>((response) =>
            {
                var user = GetCurrentUser();
                if (user == null)
                    throw new ResourceNotFoundException("User not found.");
                var ev = _dbContext.Events.FirstOrDefault(e => e.Id == eventId);
                if (ev == null)
                    throw new ResourceNotFoundException("Event not found.");
                if(ev.Users.Any(u => u.Id == user.Id))
                    throw new DuplicateResourceException("User is currently assigned to event.");
                ev.Users.Add(user);
                _dbContext.SaveChanges();
            });
        }

        public BaseContractResponse DisableEvent(int eventId)
        {
            return ExecuteAction<BaseContractResponse>((response) =>
            {
                var ev = _dbContext.Events.FirstOrDefault(e => e.Id == eventId);
                if (ev == null)
                    throw new ResourceNotFoundException("Event not found.");
                ev.Activated = false;
                _dbContext.SaveChanges();
            });
        }

        public GetEventsResponse GetActivatedEvents()
        {
            return ExecuteAction<GetEventsResponse>((response) =>
            {
                response.Events = _dbContext.Events.Where(e => e.Activated).Select(e => new EventModel(e)).ToList();
            });
        }

        public GetEventsResponse GetEvents()
        {
            return ExecuteAction<GetEventsResponse>((response) =>
            {
                response.Events = _dbContext.Events.Select(e => new EventModel(e)).ToList();
            });
        }

        public BaseContractResponse RemoveUserFromEvent(int eventId, int userId)
        {
            return ExecuteAction<GetEventsResponse>((response) =>
            {
                var ev = _dbContext.Events.FirstOrDefault(e => e.Id == eventId);
                if (ev == null)
                    throw new ResourceNotFoundException("Event not found.");
                var user = ev.Users.FirstOrDefault(u => u.Id == userId);
                if (user == null)
                    throw new ResourceNotFoundException("User not found.");
                ev.Users.Remove(user);
                _dbContext.SaveChanges();
            });
        }
    }
}
