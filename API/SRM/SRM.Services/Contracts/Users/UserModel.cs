using SRM.Core.Entities.Identity;

namespace SRM.Services.Contracts.Users
{
    public class UserModel
    {
        public string Email { get; set; }
        public string RoleName { get; set; }

        public UserModel() { }

        public UserModel(User user)
        {
            Email = user.Email;
        }
    }
}
