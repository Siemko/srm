﻿using SRM.Common.Exceptions;
using SRM.Core;
using SRM.Core.Entities.Identity;
using SRM.Services.Contracts.Accounts;
using SRM.Services.Contracts.Users;
using SRM.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Linq;
using SRM.Common.Constants;
using System;
using SRM.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace SRM.Services
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly UserManager<User> _userManager;

        public AccountService(DefaultDbContext dbContext, 
            ILogger<AccountService> logger, 
            UserManager<User> userManager,
            IHttpContextAccessor httpContextAccessor) 
            : base(dbContext, logger, httpContextAccessor)
        {
            _userManager = userManager;
        }

        public SignInResponse SignIn(string userName, string password)
        {
            return ExecuteAction<SignInResponse>((response) =>
            {
                var user = _dbContext.Users
                                     .Include(u => u.Role)
                                     .FirstOrDefault(u => u.UserName == userName || u.Email == userName);
                var passwordIsCorrect = _userManager.CheckPasswordAsync(user, password);
                if (user == null || passwordIsCorrect.Result == false)
                    throw new CustomValidationException("Username or password is incorrect.");
                if (!user.EmailConfirmed)
                    throw new CustomValidationException("User email is not confirmed.");
                response.User = new UserModel
                {
                    Email = user.Email,
                    Id = user.Id,
                    RoleName = user.Role.Name
                };
            });
        }

        public SignUpResponse SignUp(AccountModel account)
        {
            _logger.LogInformation("User registration start.");
            return ExecuteAction<SignUpResponse>((response) =>
            {
                var studentRole = _dbContext.Roles.First(r => r.NormalizedName == UserRole.Student.ToUpper());
                if (studentRole == null)
                    throw new ResourceNotFoundException("Can't found student role.");
                var user = new User
                {
                    UserName = account.Email,
                    Email = account.Email,
                    RoleId = studentRole.Id,
                    Surname = account.Surname,
                    Name = account.Name,
                    EmailConfirmed = true
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

        public BaseContractResponse ResetPassword(ResetPasswordModel model)
        {
            _logger.LogInformation("User reset password start.");
            return ExecuteAction<BaseContractResponse>((response) =>
            {
                if(model.Guid == null)
                    throw new CustomValidationException("Reset password guid is incorrect.");
                var user = _dbContext.Users.FirstOrDefault(u => u.ResetPasswordGuid == model.Guid);
                if (user == null)
                    throw new ResourceNotFoundException("User not found.");
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
                user.ResetPasswordGuid = null;
                _dbContext.SaveChanges();
            });
        }
    }
}
