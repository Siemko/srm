using SRM.Core.Entities;
using SRM.Services.Contracts.Users;
using System.Collections.Generic;
using System.Linq;

namespace SRM.Services.Contracts.Accounts
{
    public class EventModel
    {
        public EventModel()
        { }

        public EventModel(Event e, bool details = false)
        {
            Id = e.Id;
            Name = e.Name;
            CategoryId = e.CategoryId;
            MaxNumberOfPerson = e.MaxNumberOfPerson;
            Description = e.Description;
            Activated = e.Activated;
            CategoryName = e.Category?.Name;

            if (details)
                Users = e.EventUsers.Select(eu => { return new UserModel(eu.User); }).ToList();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? MaxNumberOfPerson { get; set; }
        public string Description { get; set; }
        public bool Activated { get; set; }
        public int Id { get; set; }
        public ICollection<UserModel> Users { get; set; }
    }
}
