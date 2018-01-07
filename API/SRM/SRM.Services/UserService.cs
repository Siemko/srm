using SRM.Common.Exceptions;
using SRM.Core;
using SRM.Core.Entities.Identity;
using SRM.Services.Contracts.Accounts;
using SRM.Services.Contracts.Users;
using SRM.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace SRM.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(DefaultDbContext dbContext, 
            ILogger<UserService> logger, 
            UserManager<User> userManager) 
            : base(dbContext, logger)
        {
            _userManager = userManager;
        }
    }
}
