using SRM.Services.Contracts;

namespace SRM.Services.Interfaces
{
    public interface IEmailService
    {
        BaseContractResponse SendResetToken(string email);
    }
}
