using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace OptimoWork.Authentication
{
    public class TokenProviderOptions
    {
        public static string Audience { get; } = "OptimoWorkAudience";
        public static string Issuer { get; } = "OptimoWork";
        public static SymmetricSecurityKey Key { get; } = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("OptimoWorkSecretSecurityKeyOptimoWork"));
        public static TimeSpan Expiration { get; } = TimeSpan.FromMinutes(20000);
        public static SigningCredentials SigningCredentials { get; } = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
    }
}
