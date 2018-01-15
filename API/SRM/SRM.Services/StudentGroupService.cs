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

namespace SRM.Services
{
    public class StudentGroupService : BaseService, IStudentGroupService
    {
        public StudentGroupService(DefaultDbContext dbContext, 
            ILogger<AccountService> logger) 
            : base(dbContext, logger)
        { }

        public BaseContractResponse Add(StudentGroupModel model)
        {
            return ExecuteAction<BaseContractResponse>((response) =>
            {
                var studentGroup = new StudentGroup
                {
                    Name = model.Name
                };
                _dbContext.StudentGroups.Add(studentGroup);
                _dbContext.SaveChanges();
            });
        }
    }
}
