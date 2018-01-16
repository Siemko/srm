using System.Collections.Generic;

namespace SRM.Services.Contracts.Accounts
{
    public class GetEventsResponse : BaseContractResponse
    {
        public ICollection<EventModel> Events { get; set; }
    }
}
