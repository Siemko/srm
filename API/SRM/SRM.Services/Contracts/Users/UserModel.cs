using SRM.Core.Entities.Identity;

namespace SRM.Services.Contracts.Users
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public int? StudentGroupId { get; set; }
        public string StudentNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public UserModel() { }

        public UserModel(User user)
        {
            Id = user.Id;
            Email = user.Email;
            Description = user.Description;
            StudentNumber = user.StudentNumber;
            StudentGroupId = user.StudentGroupId;
            Name = user.Name;
            Surname = user.Surname;

            if (user.Role != null)
                RoleName = user.Role.Name;
        }
    }
}
