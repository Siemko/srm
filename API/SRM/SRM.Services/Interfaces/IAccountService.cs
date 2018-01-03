using Azynmag.Services.Contracts.Accounts;

namespace Azynmag.Services.Interfaces
{
    public interface IAccountService
    {
        SignUpResponse SignUp(AccountModel account);
        SignInResponse SignIn(string username, string password);
    }
}
