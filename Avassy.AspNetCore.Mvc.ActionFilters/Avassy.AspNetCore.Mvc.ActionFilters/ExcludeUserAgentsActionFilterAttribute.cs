using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Avassy.AspNetCore.Mvc.ActionFilters
{
    public class ExcludeUserAgentsAttribute : ActionFilterAttribute
    {
        private readonly string _userAgent;
        private readonly string _redirectAction;
        private readonly string _redirectController;

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
