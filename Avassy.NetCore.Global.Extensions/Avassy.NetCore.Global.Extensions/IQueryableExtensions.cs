using System;
using System.Collections.Generic;
using System.Linq;

namespace Avassy.NetCore.Global.Extensions
{
    /// <summary>
    /// This class contains some IQueryable extension methods.
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// Orders an IQueryable by the property name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query, string propertyName)
        {
            var property = typeof(T).GetProperty(propertyName);

            return query.OrderBy(p => property.GetValue(p));
        }

        /// <summary>
        /// Orders (descending) an IQueryable the by the broperty name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> query, string propertyName)
        {
            var property = typeof(T).GetProperty(propertyName);

            return query.OrderByDescending(p => property.GetValue(p));
        }

        /// <summary>
        /// Order (then by) an IOrderedQueryable by the property name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> query, string propertyName)
        {
            var property = typeof(T).GetProperty(propertyName);

            return query.ThenBy(p => property.GetValue(p));
        }

        /// <summary>
        /// Orders (then by descending) an IOrderedQueryable by the property name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> query, string propertyName)
        {
            var property = typeof(T).GetProperty(propertyName);

            return query.ThenByDescending(p => property.GetValue(p));
        }
    }
}
