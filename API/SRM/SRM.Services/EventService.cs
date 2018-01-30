using SRM.Core;
using SRM.Services.Interfaces;
using Microsoft.Extensions.Logging;
using SRM.Services.Contracts.Accounts;
using System.Linq;
using SRM.Common.Exceptions;
using SRM.Core.Entities;
using SRM.Services.Contracts;
using Microsoft.AspNetCore.Http;
using SRM.Services.Contracts.Events.Models;
using Microsoft.EntityFrameworkCore;

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
                response.EventId = newEvent.Id;
            });
        }

        public BaseContractResponse AssignToEvent(int eventId, int userId)
        {
            return ExecuteAction<GetEventsResponse>((response) =>
            {
                var userClaim = GetCurrentUserClaims();
                if (userClaim.UserNotFound)
                    throw new ResourceNotFoundException("User not found.");
                if (!userClaim.IsStarosta && userId != userClaim.User.Id)
                    throw new CustomValidationException("This action is not allowed.");
                var ev = _dbContext.Events
                                    .Include(e => e.Users)
                                    .FirstOrDefault(e => e.Id == eventId);
                if (ev == null)
                    throw new ResourceNotFoundException("Event not found.");
                var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
                if (user == null)
                    throw new ResourceNotFoundException("User not found.");
                if (ev.Users.Any(u => u.Id == user.Id))
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

        public GetEventCategoriesResponse GetEventCategories()
        {
            return ExecuteAction<GetEventCategoriesResponse>((response) =>
            {
                response.EventCategories = _dbContext.EventCategories.Select(c => new EventCategoryModel(c)).ToList();
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
                var userClaim = GetCurrentUserClaims();
                if (userClaim.UserNotFound)
                    throw new ResourceNotFoundException("User not found.");
                if (!userClaim.IsStarosta && userId != userClaim.User.Id)
                    throw new CustomValidationException("This action is not allowed.");
                var ev = _dbContext.Events
                                    .Include(e => e.Users)
                                    .FirstOrDefault(e => e.Id == eventId);
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
