using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Avassy.AspNetCore.Mvc.ActionFilters
{
    /// <inheritdoc />
    /// <summary>
    /// An ActionFilter attribute that lets you disable the GA scripts in your view.
    /// </summary>
    /// <seealso cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute" />
    public class DisableGoogleAnalyticsAttribute : ActionFilterAttribute
    {

        public DisableGoogleAnalyticsAttribute()
        {

        }

        /// <inheritdoc />
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.RouteData.Values.Add("DisableGA", true);
        }
    }
}
