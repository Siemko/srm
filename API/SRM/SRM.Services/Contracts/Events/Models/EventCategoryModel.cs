using SRM.Core.Entities;

namespace SRM.Services.Contracts.Events.Models
{
    public class EventCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public EventCategoryModel(EventCategory category)
        {
            Id = category.Id;
            Name = category.Name;
        }
    }
}
