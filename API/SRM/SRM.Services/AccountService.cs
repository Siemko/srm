using Azynmag.Common.Exceptions;
using Azynmag.Core;
using Azynmag.Core.Entities.Identity;
using Azynmag.Services.Contracts.Accounts;
using Azynmag.Services.Contracts.Users;
using Azynmag.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Azynmag.Services
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly UserManager<User> _userManager;

        public AccountService(DefaultDbContext dbContext, 
            ILogger<AccountService> logger, 
            UserManager<User> userManager) 
            : base(dbContext, logger)
        {
            _userManager = userManager;
        }

        public SignInResponse SignIn(string userName, string password)
        {
            return ExecuteAction<SignInResponse>((response) =>
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.UserName == userName || u.Email == userName);
                var passwordIsCorrect = _userManager.CheckPasswordAsync(user, password);
                if (user == null || passwordIsCorrect.Result == false)
                    throw new CustomValidationException("Username or password is incorrect.");
                response.User = new UserModel { Email = user.Email };
            });
        }

        public SignUpResponse SignUp(AccountModel account)
        {
            _logger.LogInformation("User registration start.");
            return ExecuteAction<SignUpResponse>((response) =>
            {
                var user = new User
                {
                    UserName = account.Email,
                    Email = account.Email,
                };
                var result = _userManager.CreateAsync(user, account.Password);
                if (!result.Result.Succeeded)
                {
                    _logger.LogWarning($"User {account.Email} was not registered.", result.Result.Errors);
                }
                response.UserId = user.Id;
                response.Result = result.Result;
            });
        }
    }
}
