using Newtonsoft.Json;

namespace Apsiyon.Extensions
{
    public class ErrorDetails
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
