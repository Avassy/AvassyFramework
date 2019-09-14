using System;
using System.Buffers.Text;
using System.Linq;
using System.Text;

namespace Avassy.NetCore.Global.Extensions
{
    /// <summary>
    /// This class holds string extension methods.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Removes the special characters and spaces in the specified string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="charToReplaceSpace">The character to replacethe  space.</param>
        /// <returns>A cleaned string.</returns>
        public static string RemoveSpecialCharactersAndSpaces(this string str, char charToReplaceSpace = '-')
        {
            if (str == null)
            {
                return null;
            }

            var sb = new StringBuilder();

            foreach (var c in str)
            {
                if ((c < '0' || c > '9') && (c < 'A' || c > 'Z') && (c < 'a' || c > 'z') && c != ' ')
                {
                    continue;
                }

                sb.Append(c == ' ' ? charToReplaceSpace : c);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Converts a simple string to a base64 encoded string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>A base64 encoded string.</returns>
        public static string ToBase64(this string str)
        {
            if (str == null)
            {
                return null;
            }

            var plainTextBytes = Encoding.UTF8.GetBytes(str);

            return Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Converts a base64 encode string to a simple string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>A simple string.</returns>
        public static string FromBase64(this string str)
        {
            if (str == null)
            {
                return null;
            }

            var base64Bytes = Convert.FromBase64String(str);

            return Encoding.ASCII.GetString(base64Bytes);
        }

        /// <summary>
        /// Converts a PascalCase string to a camelCase string.
        /// </summary>
        /// <param name="str">The PascalCase string.</param>
        /// <returns>A camelCase string.</returns>
        public static string ToCamelCase(this string str)
        {
            if (str == null)
            {
                return null;
            }

            if (!str.Any())
            {
                return string.Empty;
            }

            var firstLetter = str.FirstOrDefault();

            return str.Remove(0, 1).Insert(0, firstLetter.ToString());
        }
    }
}
