using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;


namespace SkipperBack3.Model
{
    public static class Utilities
    {
        public static string GetHashString(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            MD5CryptoServiceProvider CSP = new();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = string.Empty;
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);
            return hash;
        }


        public static string GenerateToken(string login, string secretKey)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, login),
            };

            var token = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.AddMonths(1),
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}

/*System.ArgumentOutOfRangeException: 'IDX10653: The encryption algorithm 'System.String' requires a key size of at least 'System.Int32' bits. Key 'Microsoft.IdentityModel.Tokens.SymmetricSecurityKey', is of size: 'System.Int32'. Arg_ParamName_Name'*/