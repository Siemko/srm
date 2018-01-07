using SRM.Common.Exceptions;
using SRM.Core;
using SRM.Services.Contracts;
using SRM.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace SRM.Services
{
    public class BaseService : IBaseService
    {
        protected readonly DefaultDbContext _dbContext;
        protected readonly ILogger _logger;

        public BaseService(DefaultDbContext dbContext, ILogger logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        protected int GetCurrentUserId()
        {
            var user = _dbContext.Users.First();
            return user.Id;
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
