using System.Net;

namespace Apsiyon.Models
{
    public class RateLimitResponse
    {
        public string Message { get; set; }

        public int Code { get; set; }

        public string Status => ((HttpStatusCode)Code).ToString();
    }
}
