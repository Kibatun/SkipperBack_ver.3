using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SkipperBack3.Model
{
    public static class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; // издатель токена
        public const string AUDIENCE = "MyAuthClient"; // потребитель токена
        private const string KEY = "_da_ya_sosu_bibu1488";   // ключ для шифрации

        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}