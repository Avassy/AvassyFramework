using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Avassy.AspNetCore.Mvc.ActionFilters
{
    /// <inheritdoc />
    /// <summary>
    /// An ActionFilter attribute that lets you redirect when a certain UA is specified.
    /// </summary>
    /// <seealso cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute" />
    public class ExcludeUserAgentsAttribute : ActionFilterAttribute
    {
        private readonly string _userAgent;
        private readonly string _redirectAction;
        private readonly string _redirectController;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcludeUserAgentsAttribute"/> class.
        /// </summary>
        /// <param name="userAgent">The user agent.</param>
        /// <param name="redirectAction">The redirect action you want to redirect to when the UA is excluded.</param>
        /// <param name="redirectController">The redirect controller you want to redirect to when the UA is excluded.</param>
        /// <exception cref="ArgumentException">The 'userAgent', 'redirectAction' and 'redirectController' parameters cannot be null or empty.</exception>
        public ExcludeUserAgentsAttribute(string userAgent, string redirectAction, string redirectController)
        {
            if (string.IsNullOrEmpty(userAgent) || string.IsNullOrEmpty(redirectAction) || string.IsNullOrEmpty(redirectController))
            {
                throw new ArgumentException($"The 'userAgent', 'redirectAction' and 'redirectController' parameters cannot be null or empty.");
            }

            this._userAgent = userAgent;
            this._redirectAction = redirectAction;
            this._redirectController = redirectController;
        }
        
        /// <inheritdoc />
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userAgent = context.HttpContext.Request.Headers["User-Agent"].ToString();

            if (userAgent == this._userAgent)
            {
                context.Result = new RedirectToActionResult(this._redirectAction, this._redirectController, null);
            }
        }
    }
}
