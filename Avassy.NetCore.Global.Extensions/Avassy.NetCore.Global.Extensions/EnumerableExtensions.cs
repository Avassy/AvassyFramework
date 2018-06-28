using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Avassy.NetCore.Global.Extensions
{
    /// <summary>
    /// This class IEnumerable extension methods.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Converts an IEnumerable to a ICollection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceItems">The source items.</param>
        /// <returns>An ICollection of items.</returns>
        public static ICollection<T> ToCollection<T>(this IEnumerable<T> sourceItems)
        {
            if (sourceItems == null)
            {
                return null;
            }

            var arr = sourceItems.ToArray();

            return new Collection<T>(arr);
        }

        /// <summary>
        /// Adds a range of items to an IEnumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="soureceItems">The source items.</param>
        /// <param name="itemsToAdd">The items to add.</param>
        /// <returns>The original IEnumerable with the new items added.</returns>
        public static IEnumerable<T> AddRange<T>(this IEnumerable<T> soureceItems, IEnumerable<T> itemsToAdd)
        {
            if (itemsToAdd == null)
            {
                return soureceItems;
            }

            var enumerable = soureceItems as T[] ?? soureceItems.ToArray();

            var newList = enumerable.ToList();

            foreach (var obj in itemsToAdd)
            {
                newList.Add(obj);
            }

            return newList.AsEnumerable();
        }
    }
}
