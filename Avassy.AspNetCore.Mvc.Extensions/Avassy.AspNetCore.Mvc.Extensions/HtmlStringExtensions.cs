using Microsoft.AspNetCore.Html;

namespace Avassy.AspNetCore.Mvc.Extensions
{
    /// <summary>
    /// A class with HtmlString extensions.
    /// </summary>
    public static class HtmlStringExtensions
    {
        // ReSharper disable once InconsistentNaming
        /// <summary>
        /// Escapes a HTML string to a Javascript escaped HTML string.
        /// </summary>
        /// <param name="htmlString">The HTML string.</param>
        /// <returns></returns>
        public static HtmlString ToEscapedJSHtmlString(this HtmlString htmlString)
        {
            return new HtmlString($@"{htmlString.Value.Replace("/", "\\/")}");
        }
    }
}
