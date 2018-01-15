using SRM.Services.Contracts;
using SRM.Services.Contracts.Accounts;

namespace SRM.Services.Interfaces
{
    public interface IAccountService
    {
        SignUpResponse SignUp(AccountModel account);
        SignInResponse SignIn(string username, string password);
        BaseContractResponse ResetPassword(ResetPasswordModel model);
    }
}
