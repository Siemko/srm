using SRM.Services.Contracts.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRM.Models.ViewModels.User
{
    public class UserVM
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public int StudentGroupId { get; set; }
        public string StudentNumber { get; set; }

        public UserModel MapToUserModel()
        {
            var result = new UserModel
            {
                Id = this.Id,
                StudentGroupId = this.StudentGroupId,
                Email = this.Email,
                StudentNumber = this.StudentNumber,
                Description = this.Description,
            };
            return result;
        }
    }
}
