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
        public static IIncludableQueryable<TPreviousProperty, ICollection<TProperty>> AsIncludableQueryable<TPreviousProperty, TProperty>(this IQueryable<TPreviousProperty> query)
        {
            return query as IIncludableQueryable<TPreviousProperty, ICollection<TProperty>> ?? throw new InvalidOperationException("Cannot convert this to an IIncludableQueryable<TPreviousProperty, ICollection<TProperty>>.");
        }
    }
}
