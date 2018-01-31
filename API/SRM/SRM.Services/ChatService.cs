using SRM.Common.Exceptions;
using SRM.Core;
using SRM.Core.Entities.Identity;
using SRM.Services.Contracts.Accounts;
using SRM.Services.Contracts.Users;
using SRM.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.AspNetCore.Http;
using SRM.Services.Contracts;
using SRM.Services.Contracts.Chats;
using SRM.Services.Contracts.Chats.Models;
using SRM.Core.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;

namespace SRM.Services
{
    public class ChatService : BaseService, IChatService
    { 
        public ChatService(DefaultDbContext dbContext, 
            ILogger<ChatService> logger,
            IHttpContextAccessor httpContextAccessor) 
            : base(dbContext, logger, httpContextAccessor)
        {
        }

        public BaseContractResponse AddMessage(MessageModel model)
        {
            return ExecuteAction<BaseContractResponse>(response =>
            {
                var chat = _dbContext.Chats
                                    .Include(c => c.Messages)
                                    .FirstOrDefault(c => c.Id == model.ChatId);
                if (chat == null)
                    throw new ResourceNotFoundException("Chat not found.");
                var userClaims = GetCurrentUserClaims();
                if (userClaims.UserNotFound)
                    throw new ResourceNotFoundException("User not found");
                var message = new Message
                {
                    ChatId = chat.Id,
                    Content = model.Content,
                    UserId = userClaims.User.Id,
                    CreatedAt = DateTime.Now
                };
                chat.Messages.Add(message);
                _dbContext.SaveChanges();
            });
        }

        public BaseContractResponse AssignToChat(int chatId)
        {
            return ExecuteAction<BaseContractResponse>(response =>
            {
                var chat = _dbContext.Chats
                                    .Include(c => c.ChatUsers)
                                    .FirstOrDefault(c => c.Id == chatId);
                if (chat == null)
                    throw new ResourceNotFoundException("Chat not found.");
                var user = GetCurrentUserClaims().User;
                if (user == null)
                    throw new ResourceNotFoundException("User not found.");
                if(chat.ChatUsers.Any(u => u.UserId == user.Id))
                    throw new DuplicateResourceException("User is already assigned to chat.");
                chat.ChatUsers.Add(new ChatUser { ChatId = chatId, UserId = user.Id });
                _dbContext.SaveChanges();
            });
        }

        public CreateChatResponse CreateChat(ChatModel model)
        {
            return ExecuteAction<CreateChatResponse>(response =>
            {
                if (_dbContext.Chats.Any(c => c.Name.ToUpper() == model.Name.ToUpper()))
                    throw new DuplicateResourceException($"Chat with name {model.Name} already exist.");
                var users = _dbContext.Users.Where(u => model.Users.Any(us => us.Id == u.Id));
                var chat = new Chat
                {
                    Name = model.Name,
                };
                _dbContext.Chats.Add(chat);
                _dbContext.SaveChanges();
                response.ChatId = chat.Id;
            });
        }

        public GetChatsResponse Get()
        {
            return ExecuteAction<GetChatsResponse>(response =>
            {
                response.Chats = _dbContext.Chats
                                    .Include(c => c.ChatUsers)
                                    .ThenInclude(c => c.User)
                                    .Select(c => new ChatModel(c)).ToList();
            });
        }

        public GetChatResponse Get(int chatId)
        {
            return ExecuteAction<GetChatResponse>(response =>
            {
                var user = GetCurrentUserClaims().User;
                if (user == null)
                    throw new ResourceNotFoundException("User not found.");
                var chat = _dbContext.Chats
                                .Include(c => c.Messages)
                                .FirstOrDefault(c => c.Id == chatId && c.ChatUsers.Any(u => u.UserId == user.Id));
                if (chat == null)
                    throw new ResourceNotFoundException("Chat not found.");
                response.Chat = new ChatModel(chat, chat.Messages);
            });
        }

        public BaseContractResponse LeftChat(int chatId)
        {
            return ExecuteAction<BaseContractResponse>(response =>
            {
                var user = GetCurrentUserClaims().User;
                if (user == null)
                    throw new ResourceNotFoundException("User not found.");
                var chat = _dbContext.Chats
                                    .Include(c => c.ChatUsers)
                                    .FirstOrDefault(c => c.Id == chatId);
                if (chat == null)
                    throw new ResourceNotFoundException("Chat not found.");
                var chatUser = chat.ChatUsers.FirstOrDefault(cu => cu.UserId == user.Id);
                if (chatUser == null)
                    chat.ChatUsers.Remove(chatUser);
                _dbContext.SaveChanges();
            });
        }

        public BaseContractResponse RemoveMessage(int messageId)
        {
            return ExecuteAction<BaseContractResponse>(response =>
            {
                var userClaim = GetCurrentUserClaims();
                if (userClaim.UserNotFound)
                    throw new ResourceNotFoundException("User not found.");
                var message = _dbContext.Messages.FirstOrDefault(m => m.Id == messageId);
                if (message == null)
                    throw new ResourceNotFoundException("Message not found.");
                if (!userClaim.IsStarosta)
                {
                    if(message.UserId != userClaim.User.Id)
                        throw new ResourceNotFoundException("Remove this message is not allowed.");
                }
                _dbContext.Messages.Remove(message);
                _dbContext.SaveChanges();
            });
        }
    }
}
