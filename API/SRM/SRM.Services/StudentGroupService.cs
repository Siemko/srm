using SRM.Common.Exceptions;
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
using SRM.Services.Contracts.StudentGroups;
using SRM.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace SRM.Services
{
    public class StudentGroupService : BaseService, IStudentGroupService
    {
        public StudentGroupService(DefaultDbContext dbContext, 
            ILogger<AccountService> logger,
            IHttpContextAccessor httpContextAccessor)
            : base(dbContext, logger, httpContextAccessor)
        { }

        public GetStudentGroupsResponse Get()
        {
            return ExecuteAction<GetStudentGroupsResponse>((response) =>
            {
                response.StudentGroups = _dbContext.StudentGroups.Select(sg => new StudentGroupModel(sg)).ToList();
            });
        }
    }
}
