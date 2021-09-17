using System.Collections.Generic;

namespace Apsiyon.Utilities.Results
{
    public class PagingResult<T> : Result, IPagingResult<T>
    {
        public PagingResult(List<T> data, int totalItemCount, bool success, string message) : base(success, message)
        {
            Data = data;
            TotalItemCount = totalItemCount;
        }

        public List<T> Data { get; }
        public int TotalItemCount { get; }
    }
}
