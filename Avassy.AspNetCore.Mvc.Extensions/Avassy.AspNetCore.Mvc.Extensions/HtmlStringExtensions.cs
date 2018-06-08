using Microsoft.AspNetCore.Html;

namespace Avassy.AspNetCore.Mvc.Extensions
{
    public static class HtmlStringExtensions
    {
        // ReSharper disable once InconsistentNaming
        public static HtmlString ToEscapedJSHtmlString(this HtmlString htmlString)
        {
            return new HtmlString($@"{htmlString.Value.Replace("/", "\\/")}");
        }
    }
}
