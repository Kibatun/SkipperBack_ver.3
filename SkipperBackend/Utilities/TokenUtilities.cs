using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SkipperBack3.DBImport;
using SkipperBack3.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SkipperBack3.TokenUtils
{
    public class TokenUtilities
    {
        public static string GenerateAccessToken(User user)
        {
            var secretKey = AuthOptions.KEY;
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
                Id = Guid.NewGuid(),
                Token = GenerateRefreshToken(),
                ExpiresAt = DateTime.Now.AddDays(180),
                CreatedAt = DateTime.Now,
                UserId = uid
            };

            return refreshToken;

            static string GenerateRefreshToken()
            {
                var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
                return token;
            }
        }

        public static bool isTokenValid(string accessToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(AuthOptions.KEY);

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            try
            {
                SecurityToken validatedToken;
                tokenHandler.ValidateToken(accessToken, validationParameters, out validatedToken);
                return true;
            }
            catch
            {
                // Валидация токена не удалась
                return false;
            }
        }
    }
}