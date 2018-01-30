using SRM.Services.Contracts.Events.Models;
using System.Collections.Generic;

namespace SRM.Services.Contracts.Accounts
{
    public class GetEventCategoriesResponse : BaseContractResponse
    {
        public ICollection<EventCategoryModel> EventCategories { get; set; }
    }
}
