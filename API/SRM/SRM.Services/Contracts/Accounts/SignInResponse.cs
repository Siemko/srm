using Azynmag.Services.Contracts.Users;

namespace Azynmag.Services.Contracts.Accounts
{
    public class SignInResponse : BaseContractResponse
    {
        public UserModel User { get; set; }
    }
}
