﻿using SRM.Services.Contracts;
using SRM.Services.Contracts.Accounts;

namespace SRM.Services.Interfaces
{
    public interface IEventService
    {
        GetEventsResponse GetEvents();
        AddEventResponse AddEvent(EventModel model);
        BaseContractResponse ActivateEvent(int eventId);
        BaseContractResponse DisableEvent(int eventId);
        GetEventsResponse GetActivatedEvents();
        BaseContractResponse AssignToEvent(int eventId, int userId);
        BaseContractResponse RemoveUserFromEvent(int eventId, int userId);
        GetEventCategoriesResponse GetEventCategories();
        GetEventResponse GetEvent(int eventId);
    }
}
