﻿using SRM.Common.Exceptions;
using SRM.Core;
using SRM.Services.Contracts;
using SRM.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using SRM.Services.Contracts.Users.Models;

namespace SRM.Services
{
    public class BaseService : IBaseService
    {
        protected readonly DefaultDbContext _dbContext;
        protected readonly ILogger _logger;
        private HttpContext _httpContext;

        public BaseService(DefaultDbContext dbContext, 
            ILogger logger,
            IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _logger = logger;
            _httpContext = httpContextAccessor.HttpContext;
        }

        protected UserClaimModel GetCurrentUserClaims()
        {
            var userEmail = _httpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var currentUser = _dbContext.Users
                                        .Include(u => u.Role)
                                        .FirstOrDefault(u => u.Email == userEmail);

            return new UserClaimModel(currentUser);
        }

        protected void AllowedOnlyForStarostaAndOwner(int ownerId)
        {
            var currentUserClaims = GetCurrentUserClaims();
            if (currentUserClaims.UserNotFound)
                throw new ResourceNotFoundException("Current user not found.");
            if (!currentUserClaims.IsStarosta && currentUserClaims.User.Id != ownerId)
                throw new CustomValidationException("User is not allowed to get resource.");
        }

        protected TResponse ExecuteAction<TResponse>(Action<TResponse> action) 
            where TResponse : BaseContractResponse, new()
        {
            var response = new TResponse();
            try
            {
                action(response);
            }
            catch (CustomValidationException ex)
            {
                _logger.LogInformation(ex.Message);
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}
