using Apsiyon.ActionFilters.Attributes;
using Apsiyon.Enums;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Apsiyon.ActionFilters
{
    [AttributeUsage(System.AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class RateLimit : Attribute, IFilterFactory
    {
        public int Order { get; set; }

        public int PeriodInSec { get; set; }

        public int Limit { get; set; }

        public string RouteParams { get; set; }

        public string QueryParams { get; set; }

        public RateLimitScope Scope { get; set; }

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            var filter = serviceProvider.GetRequiredService<RateLimitAttribute>();
            filter.Order = Order;
            filter.PeriodInSec = PeriodInSec;
            filter.Limit = Limit;
            filter.RouteParams = RouteParams;
            filter.QueryParams = QueryParams;
            filter.Scope = Scope;

            return filter;
        }

        public bool IsReusable => true;
    }
}
