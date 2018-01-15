using System.Collections.Generic;

namespace SRM.Services.Contracts.Users
{
    public class GetUsersResponse : BaseContractResponse
    {
        public ICollection<UserModel> Users;
    }
}
