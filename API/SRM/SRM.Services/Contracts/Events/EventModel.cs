using SRM.Core.Entities;

namespace SRM.Services.Contracts.Accounts
{
    public class EventModel
    {
        public EventModel()
        { }

        public EventModel(Event e)
        {
            Name = e.Name;
            CategoryId = e.CategoryId;
            MaxNumberOfPerson = e.MaxNumberOfPerson;
            Description = e.Description;
            Activated = e.Activated;
        }

        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int? MaxNumberOfPerson { get; set; }
        public string Description { get; set; }
        public bool Activated { get; set; }
    }
}
