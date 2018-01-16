using SRM.Common.Exceptions;
using SRM.Core;
using SRM.Services.Contracts;
using SRM.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using SRM.Core.Entities.Identity;

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
        }

        protected User GetCurrentUser()
        {
            var userEmail = _httpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var currentUser = _dbContext.Users.FirstOrDefault(u => u.Email == userEmail);
            return currentUser;
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
