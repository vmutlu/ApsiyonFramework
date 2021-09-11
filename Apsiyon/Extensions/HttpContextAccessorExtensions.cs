using Microsoft.AspNetCore.Http;
using System;

namespace Apsiyon.Extensions
{
    public static class HttpContextAccessorExtensions
    {
        public static string GetRequestUri(this IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor is null)
                throw new ArgumentNullException(nameof(httpContextAccessor));

            var request = httpContextAccessor.HttpContext.Request;
            return string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
        }

        public static string GetRoute(this IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor is null)
                throw new ArgumentNullException(nameof(httpContextAccessor));

            return httpContextAccessor.HttpContext.Request.Path.Value;
        }
    }
}
