using System.Net;

namespace Apsiyon.Utilities.Results
{
    public class Result : IResult
    {
        public Result(HttpStatusCode statusCode)
        {
            StatusCode = (int)statusCode;
        }

        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }

        public Result(bool success, string message, HttpStatusCode statusCode) : this(success, statusCode)
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }

        public Result(bool success, HttpStatusCode statusCode) : this(success)
        {
            StatusCode = (int)statusCode;
        }

        public Result(HttpStatusCode statusCode, string message) : this(statusCode)
        { Message = message; }

        public bool Success { get; }

        public string Message { get; }

        public int StatusCode { get; }
    }
}
