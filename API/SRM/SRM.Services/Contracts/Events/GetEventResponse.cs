using System.Collections.Generic;

namespace SRM.Services.Contracts.Accounts
{
    public class GetEventResponse : BaseContractResponse
    {
        public EventModel Event { get; set; }
    }
}
