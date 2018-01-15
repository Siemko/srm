using System;

namespace SRM.Services.Contracts.Accounts
{
    public class ResetPasswordModel
    {
        public Guid Guid { get; set; }
        public string Password { get; set; }
    }
}
