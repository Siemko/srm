using SRM.Common.Exceptions;
using SRM.Core;
using SRM.Core.Entities.Identity;
using SRM.Services.Contracts.Accounts;
using SRM.Services.Contracts.Users;
using SRM.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Linq;
using SRM.Services.Contracts;
using Microsoft.AspNetCore.Http;

namespace SRM.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(DefaultDbContext dbContext, 
            ILogger<UserService> logger, 
            UserManager<User> userManager,
            IHttpContextAccessor httpContextAccessor)
            : base(dbContext, logger, httpContextAccessor)
        {
            _userManager = userManager;
        }

        public GetUsersResponse GetUsers()
        {
            return ExecuteAction<GetUsersResponse>((response) =>
            {
                response.Users = _dbContext.Users.Select(u => new UserModel(u)).ToList();
            });
        }

        public BaseContractResponse Activate(int userId)
        {
            return ExecuteAction<BaseContractResponse>((response) =>
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
                if (user == null)
                    throw new ResourceNotFoundException("User not found.");
                user.Active = true;
                _dbContext.SaveChanges();
            });
        }

        public BaseContractResponse Deactivate(int userId)
        {
            return ExecuteAction<BaseContractResponse>((response) =>
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
                if (user == null)
                    throw new ResourceNotFoundException("User not found.");
                user.Active = false;
                _dbContext.SaveChanges();
            });
        }

        public GetUserResponse GetUser(int userId)
        {
            return ExecuteAction<GetUserResponse>(response =>
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
                if (user == null)
                    throw new ResourceNotFoundException("User not found.");
                response.User = new UserModel(user);
            });
        }

        public BaseContractResponse UpdateUser(UserModel model)
        {
            return ExecuteAction<BaseContractResponse>(response =>
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.Id == model.Id);
                if (user == null)
                    throw new ResourceNotFoundException("User not found.");
                user.Description = model.Description;
                user.StudentGroupId = model.StudentGroupId;
                user.StudentNumber = model.StudentNumber;
                _dbContext.SaveChanges();
            });
        }
    }
}
