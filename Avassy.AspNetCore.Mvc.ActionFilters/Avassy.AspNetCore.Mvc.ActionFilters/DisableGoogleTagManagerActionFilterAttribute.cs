using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Avassy.AspNetCore.Mvc.ActionFilters
{
    /// <inheritdoc />
    /// <summary>
    /// An ActionFilter attribute that lets you disable the GTM scripts in your view.
    /// </summary>
    /// <seealso cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute" />
    public class DisableGoogleTagManagerActionFilterAttribute : ActionFilterAttribute
    {

        public DisableGoogleTagManagerActionFilterAttribute()
        {

        }

        /// <inheritdoc />
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.RouteData.Values.Add("DisableGTM", true);
        }
    }
}
