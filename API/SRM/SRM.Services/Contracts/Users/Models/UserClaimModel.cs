using SRM.Common.Constants;
using SRM.Core.Entities.Identity;

namespace SRM.Services.Contracts.Users.Models
{
    public class UserClaimModel
    {
        public User User { get; set; }

        public bool UserFound { get; private set; }

        public bool IsStarosta
        {
            get
            {
                return RoleExist() && User.Role.Name == UserRole.Starosta;
            }
            private set { }
        }

        public bool IsStudent
        {
            get
            {
                return RoleExist() && User.Role.Name == UserRole.Student;
            }
            private set { }
        }

        public UserClaimModel(User user)
        {
            User = user;
            UserFound = user != null;
        }

        private bool RoleExist()
        {
            return UserFound && User.Role != null;
        }
    }
}
