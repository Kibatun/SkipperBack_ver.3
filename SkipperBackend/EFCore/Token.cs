using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkipperBack3.EFCore
{
    public class Tokens
    {
        public string Access_Token { get; set; }
        public string Refresh_Token { get; set; }
    }
}
