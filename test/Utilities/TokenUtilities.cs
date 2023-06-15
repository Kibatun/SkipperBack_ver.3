using Microsoft.IdentityModel.Tokens;
using SkipperBack3.DBImport;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SkipperBack3.TokenUtils
{
    public class TokenUtilities
    {
        public static string GenerateAccessToken(User user, string secretKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var tokenDesctiptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("uuid", user.Uid.ToString()),
                new Claim("email", user.Email),
                new Claim("firstName", user.FirstName),
                new Claim("lastName", user.LastName)
                }),
                Expires = DateTime.UtcNow.AddMonths(1),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            };

            var accesToken = tokenHandler.CreateToken(tokenDesctiptor);
            return tokenHandler.WriteToken(accesToken);
        }

        public static RefreshToken GenerateRefreshToken(Guid uid)
        {
            var refreshToken = new RefreshToken
            {
                Token = GenerateRefreshToken(),
                ExpiresAt = DateTime.UtcNow.AddDays(180),
                CreatedAt = DateTime.UtcNow,
                UserId = uid
            };

            return refreshToken;

            static string GenerateRefreshToken()
            {
                var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
                return token;
            }
        }
    }
}