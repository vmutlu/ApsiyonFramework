using System.Net;

namespace Apsiyon.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }

        public ErrorDataResult(T data) : base(data, false)
        {

        }

        public ErrorDataResult(string message) : base(default, false, message)
        {

        }

        public ErrorDataResult(HttpStatusCode statusCode, string message) : base(default, false, message, statusCode)
        {

        }

        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
