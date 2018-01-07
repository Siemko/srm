using SRM.Services.Contracts.Users;

namespace SRM.Authorization
{
    public class TokenModel
    {
        public string Token { get; set; }

        //Additional data
        public string UserName { get; set; }

        public TokenModel(string token, UserModel user = null)
        {
            Token = token;
            if(user != null)
            {
                //UserName = user.Email;
            }
        }
    }
}
