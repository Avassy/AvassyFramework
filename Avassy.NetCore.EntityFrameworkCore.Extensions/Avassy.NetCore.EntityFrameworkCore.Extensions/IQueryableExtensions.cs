using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;

namespace Avassy.NetCore.EntityFrameworkCore.Extensions
{
    /// <summary>
    /// This class contains some IQueryable extension methods.
    /// </summary>
    public static class QueryableExtensions
    {
        public static IIncludableQueryable<TPreviousProperty, IEnumerable<TProperty>> ToIncludableQueryable<TPreviousProperty, TProperty>(this IQueryable<TProperty> query)
        {
            return query as IIncludableQueryable<TPreviousProperty, IEnumerable<TProperty>> ??
                   throw new InvalidOperationException(
                       "Cannot convert this IQueryable<T> ta an IIncludableQueryable<TPreviousProperty, IEnumerable<TProperty>>.");
        }
    }
}
