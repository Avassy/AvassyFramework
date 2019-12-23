using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avassy.AspNetCore.Mvc.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static bool ShouldDisableGA<dynamic>(this IHtmlHelper<dynamic> helper)
        {
            helper.ViewContext.RouteData.Values.TryGetValue("DisableGA", out var shouldDisableGA);

            return (bool?)shouldDisableGA ?? false;
        }
    }
}
