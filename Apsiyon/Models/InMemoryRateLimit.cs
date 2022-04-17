using System;

namespace Apsiyon.Models
{
    public class InMemoryRateLimit
    {
        public DateTime Expiration { get; set; }

        public long Total { get; set; }
    }
}
