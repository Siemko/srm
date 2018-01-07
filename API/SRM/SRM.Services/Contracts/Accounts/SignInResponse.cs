using SRM.Services.Contracts.Users;

namespace SRM.Services.Contracts.Accounts
{
    public class SignInResponse : BaseContractResponse
    {
        public UserModel User { get; set; }
    }
}
