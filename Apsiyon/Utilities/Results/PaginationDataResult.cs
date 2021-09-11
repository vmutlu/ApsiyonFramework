using System;
using System.Linq;
using System.Net;

namespace Apsiyon.Utilities.Results
{
    public class PaginationDataResult<T> : Result, IPaginationResult<T>
    {
        public PaginationDataResult(IQueryable<T> data, HttpStatusCode statusCode, int pageNumber, int pageSize) : base(statusCode)
        {
            Data = data;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public PaginationDataResult(IQueryable<T> data, HttpStatusCode statusCode, int pageNumber, int pageSize, string message) : base(statusCode, message)
        {
            Data = data;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Uri FirstPage { get; set; }
        public Uri LastPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public Uri NextPage { get; set; }
        public Uri PreviousPage { get; set; }
        public IQueryable<T> Data { get; }
    }
}
