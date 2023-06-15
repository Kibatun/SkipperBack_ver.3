using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SkipperBack3.Model
{
    public static class AuthOptions
    {
        public const string ISSUER = "MyAuthServer";
        public const string AUDIENCE = "MyAuthClient"; 
        private const string KEY = "_da_ya_sosu_bibu1488";

        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}