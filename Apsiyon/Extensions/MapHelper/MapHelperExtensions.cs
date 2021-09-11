using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Apsiyon.Extensions.MapHelper
{
    public static class MapHelperExtensions
    {
        public static dynamic GetListMapped<T>(this IEnumerable<T> mapped, Expression<Func<T, dynamic>> columnName)
        {
            dynamic propertyName = default;
            if (mapped.IsNullOrEmpty()) return "";
            var columnNames = columnName.GetPropertyName();
            propertyName = mapped.Any()
                            ? mapped.FirstOrDefault().GetType().GetProperty(columnNames).GetValue(mapped.FirstOrDefault()) : default;
            return propertyName;
        }

        public static string GetPropertyName<T>(this Expression<Func<T, dynamic>> expression)
        {
            if (expression.Body is MemberExpression)
                return ((MemberExpression)expression.Body).Member.Name;

            else
            {
                var op = ((UnaryExpression)expression.Body).Operand;
                return ((MemberExpression)op).Member.Name;
            }
        }

        public static bool IsNullOrEmpty(this IEnumerable @this) => @this == null || @this.GetEnumerator().MoveNext() == false;
    }
}
