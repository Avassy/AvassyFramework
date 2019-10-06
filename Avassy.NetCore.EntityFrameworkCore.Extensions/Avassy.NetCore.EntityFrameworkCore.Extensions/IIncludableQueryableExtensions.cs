using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;

namespace Avassy.NetCore.EntityFrameworkCore.Extensions
{
    /// <summary>
    /// This class contains some IQueryable extension methods.
    /// </summary>
    public static class IncludableQueryableExtensions
    {
        public static IIncludableQueryable<TPreviousProperty, IEnumerable<TProperty>> AsIncludableQueryable<TPreviousProperty, TProperty>(this IIncludableQueryable<TPreviousProperty, IEnumerable<TProperty>> query)
        {
            return query;
        }
    }
}
