using Apsiyon.Extensions;
using Apsiyon.Services.Abstract;
using Apsiyon.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using System;

namespace Apsiyon.Services.Concrete
{
    public class PaginationUriService : IPaginationUriService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PaginationUriService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Uri GetPageUri(PaginationQuery paginationQuery)
        {
            var baseUri = _httpContextAccessor.GetRequestUri();
            var route = _httpContextAccessor.GetRoute();

            var endpoint = new Uri(string.Concat(baseUri, route));
            var queryUri = QueryHelpers.AddQueryString($"{endpoint}", "pageNumber", $"{paginationQuery.PageNumber}");

            queryUri = QueryHelpers.AddQueryString(queryUri, "pageSize", $"{paginationQuery.PageSize}");
            return new Uri(queryUri);
        }
    }
}
