using SRM.Common.Exceptions;
using SRM.Core;
using SRM.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Linq;
using System;
using SRM.Services.Contracts;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using SRM.Common.Configurations;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace SRM.Services
{
    public class EmailService : BaseService, IEmailService
    {
        private EmailConfiguration _emailSettings;

        public EmailService(DefaultDbContext dbContext, 
            ILogger<EmailService> logger,
            IOptions<EmailConfiguration> emailConfig,
            IHttpContextAccessor httpContextAccessor)
            : base(dbContext, logger, httpContextAccessor)
        {
            _emailSettings = emailConfig.Value;
        }

        public BaseContractResponse SendResetToken(string email)
        {
            return ExecuteAction<BaseContractResponse>((response) =>
            {
                if (string.IsNullOrEmpty(email))
                    throw new CustomValidationException("Email address is required.");
                var user = _dbContext.Users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
                if (user == null)
                    throw new ResourceNotFoundException("User not found");
                user.ResetPasswordGuid = Guid.NewGuid();
                _dbContext.SaveChanges();

                var mailMessage = new MailMessage();
                mailMessage.To.Add(email);
                mailMessage.Body = _emailSettings.ResetPasswordText;
                mailMessage.Subject = "SRM - Reset password";
                Send(mailMessage);
                _logger.LogInformation("Sent reset password mail.");
            });
        }

        private void Send(MailMessage message)
        {
            using (var client = new SmtpClient(_emailSettings.SmtpServer))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_emailSettings.UserName, _emailSettings.Password);

                message.From = new MailAddress(_emailSettings.FromEmail);
                client.Send(message);
            }
        }
    }
}
