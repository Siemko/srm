using Azynmag.Services.Contracts.Users;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Azynmag.Authorization
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
