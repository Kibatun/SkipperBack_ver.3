using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SkipperBack3.Model;


namespace SkipperBack3.TokenUtils
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


       

        public static void Logout()
        {
            JwtSecurityToken token = null;
            JwtSecurityToken expires = null;
        }
    }
}

/*System.ArgumentOutOfRangeException: 'IDX10653: The encryption algorithm 'System.String' requires a key size of at least 'System.Int32' bits. Key 'Microsoft.IdentityModel.Tokens.SymmetricSecurityKey', is of size: 'System.Int32'. Arg_ParamName_Name'*/