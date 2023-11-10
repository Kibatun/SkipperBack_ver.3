using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SkipperBack3.Model
{
    public static class AuthOptions
    {
        public const string ISSUER = "MyAuthServer";
        public const string AUDIENCE = "MyAuthClient"; 
        public const string KEY = "ya_sosu_bibu1488";

        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}