using SRM.Services.Contracts.Users;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SRM.Authorization
{
    public class AuthorizationHelper
    {
        static public TokenModel GenerateTokenForUser(UserModel user)
        {
            var now = DateTime.UtcNow;

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, ((DateTimeOffset)now).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            };

            // Create the JWT and write it to a string
            var expiryDate = now.Add(GetAccessTokenExpirationTime());
            var accessJWT = new JwtSecurityToken(
                issuer: GetIssuer(),
                audience: GetAudience(),
                claims: claims,
                notBefore: now,
                expires: expiryDate,
                signingCredentials: new SigningCredentials(GetSignInKey(), SecurityAlgorithms.HmacSha256));

            var encodedAccessJWT = new JwtSecurityTokenHandler().WriteToken(accessJWT);

            var refreshJWT = new JwtSecurityToken(
               issuer: GetIssuer(),
               audience: GetAudience(),
               claims: claims,
               notBefore: now,
               expires: now.Add(GetRefreshTokenExpirationTime()),
               signingCredentials: new SigningCredentials(GetSignInKey(), SecurityAlgorithms.HmacSha256));

            var encodedRefreshJWT = new JwtSecurityTokenHandler().WriteToken(refreshJWT);

            return new TokenModel(encodedAccessJWT, user);
        }

        static public TokenValidationParameters GetJwtBearerOptions()
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = GetSignInKey(),
                ValidateIssuer = true,
                ValidIssuer = GetIssuer(),
                ValidateAudience = true,
                ValidAudience = GetAudience(),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
            };
            return tokenValidationParameters;
        }

        static private SymmetricSecurityKey GetSignInKey()
        {
            const string secretKey = "GdZeYzxFg22Eel1Ag8nBo2Z8PnJHPmqjhbgsvWSeaBWJY3vror0YmH5EVfDSydMd";
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            return signingKey;
        }

        static private string GetIssuer()
        {
            return "issuer";
        }

        static private string GetAudience()
        {
            return "audience";
        }

        static private TimeSpan GetAccessTokenExpirationTime()
        {
            return TimeSpan.FromHours(6);
        }

        static private TimeSpan GetRefreshTokenExpirationTime()
        {
            return TimeSpan.FromHours(24);
        }

        static public JwtSecurityToken ReadToken(string refreshToken)
        {
            var jwt = new JwtSecurityTokenHandler().ReadToken(refreshToken) as JwtSecurityToken;
            return jwt;
        }
    }
}
