using System.Collections.Generic;

namespace Apsiyon.Models
{
    public class RateLimitOptions
    {
        public RateLimitOptions()
        {
            IpWhiteList = new List<string>();
        }
        
        public bool EnableRateLimit { get; set; } = true;

        public int HttpStatusCode { get; set; } = 429;

        public string ErrorMessage { get; set; } = "Rate limit Exceeded";

        public bool HasRedis => !string.IsNullOrEmpty(RedisConnection?.Trim());

        public string RedisConnection { get; set; }

        public List<string> IpWhiteList { get; set; }

        public string IpHeaderName { get; set; } = "X-Forwarded-For";

        public string ClientIdentifier { get; set; }

        public List<string> ClientIdentifierWhiteList { get; set; }
    }
}
