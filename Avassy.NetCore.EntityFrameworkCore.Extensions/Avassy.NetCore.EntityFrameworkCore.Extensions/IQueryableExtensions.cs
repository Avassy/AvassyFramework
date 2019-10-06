using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Query;

namespace Avassy.NetCore.EntityFrameworkCore.Extensions
{
    /// <summary>
    /// This class contains some IQueryable extension methods.
    /// </summary>
    public static class QueryableExtensions
    {
        public static IIncludableQueryable<TPreviousProperty, IEnumerable<TProperty>> AsIncludableQueryable<TPreviousProperty, TProperty>(this IQueryable<TPreviousProperty> query)
        {

            if (query is IIncludableQueryable<TPreviousProperty, IEnumerable<TProperty>> includableQuery)
            {
                return includableQuery;
            }

            return query as IIncludableQueryable<TPreviousProperty, IEnumerable<TProperty>> ??
                   throw new InvalidOperationException(
                       "Cannot convert this IQueryable<T> ta an IIncludableQueryable<TPreviousProperty, IEnumerable<TProperty>>.");
        }
    }
}
