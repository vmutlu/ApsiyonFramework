using System.Net;

namespace Apsiyon.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, HttpStatusCode statusCode) : base(statusCode)
        {
            Data = data;
        }

        public DataResult(T data, HttpStatusCode statusCode, int totalRecords) : this(data, statusCode)
        {
            TotalRecords = totalRecords;
        }

        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }

        public DataResult(T data, bool success, string message, HttpStatusCode statusCode) : base(success, message, statusCode)
        {
            Data = data;
        }

        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }

        public DataResult(T data, bool success, HttpStatusCode statusCode) : base(success, statusCode)
        {
            Data = data;
        }

        public DataResult(T data, HttpStatusCode statusCode, int totalRecords, string message) : base(statusCode, message)
        {
            Data = data;
            TotalRecords = totalRecords;
        }

        public DataResult(T data, HttpStatusCode statusCode, string message) : base(statusCode, message)
        {
            Data = data;
        }

        public T Data { get; }

        public int TotalRecords { get; }
    }
}
