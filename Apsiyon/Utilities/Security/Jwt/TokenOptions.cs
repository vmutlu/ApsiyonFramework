namespace Apsiyon.Utilities.Security.Jwt
{
    public class TokenOptions
    {
        public string Audience { get; set; } // tokenin kullanıcı kitlesi
        public string Issuer { get; set; } // imzalayan
        public int AccessTokenExpiration { get; set; } // token geçerlilik süresi. dk.
        public string SecurityKey { get; set; } 
    }
}
