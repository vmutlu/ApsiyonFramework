using Microsoft.IdentityModel.Tokens;

namespace Apsiyon.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey) => new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
    }
}
