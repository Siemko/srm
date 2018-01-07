using Microsoft.AspNetCore.Identity;

namespace SRM.Services.Contracts.Accounts
{
    public class SignUpResponse : BaseContractResponse
    {
        public IdentityResult Result { get; set; }
        public int UserId { get; set; }
    }
}
