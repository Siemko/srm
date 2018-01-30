using SRM.Common.Constants;
using SRM.Core.Entities.Identity;

namespace SRM.Services.Contracts.Users.Models
{
    public class UserClaimModel
    {
        public User User { get; set; }

        public bool UserNotFound { get; private set; }

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
            UserNotFound = user == null;
        }

        private bool RoleExist()
        {
            return !UserNotFound && User.Role != null;
        }
    }
}
