using SRM.Services.Contracts;
using SRM.Services.Contracts.Users;

namespace SRM.Services.Interfaces
{
    public interface IUserService
    {
        GetUsersResponse GetUsers();
        BaseContractResponse Activate(int userId);
        BaseContractResponse Deactivate(int userId);
        GetUserResponse GetUser(int userId);
        BaseContractResponse UpdateUser(UserModel model);
        GetUsersResponse GetActivatedUsers();
        GetUsersResponse GetDeactivatedUsers();
        GetUsersResponse GetUsersByStudentGroup(int studentGroupId);
    }
}
