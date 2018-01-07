﻿using SRM.Common.Exceptions;
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
    public class ChatService : BaseService, IChatService
    { 
        public ChatService(DefaultDbContext dbContext, 
            ILogger<ChatService> logger) 
            : base(dbContext, logger)
        {
        }
    }
}
