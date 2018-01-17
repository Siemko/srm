using SRM.Core.Entities.Identity;

namespace SRM.Services.Contracts.Users
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }

        public UserModel() { }

        public UserModel(User user)
        {
            Email = user.Email;
        }
    }
}
