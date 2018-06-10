using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using Avassy.AspNetCore.Mvc.ActionFilters.Services;

namespace Avassy.AspNetCore.Mvc.ActionFilters
{
    public class ValidateReCaptchaAttribute : ActionFilterAttribute
    {
        private readonly string _recaptchaResponseKey = "g-recaptcha-response";

        private readonly string _secretKey;
        private readonly string _reCaptchaResponseNotPresentValidationMessage;
        private readonly string _reCaptchaResponseInvalidValidationMessage;

        public ValidateReCaptchaAttribute(string secretKey, string reCaptchaResponseNotPresentValidationMessage = "The ReCaptcha response was not present.", string reCaptchaResponseInvalidValidationMessage = "The ReCaptcha response was not valid.")
        {
            this._secretKey = secretKey;
            this._reCaptchaResponseNotPresentValidationMessage = reCaptchaResponseNotPresentValidationMessage;
            this._reCaptchaResponseInvalidValidationMessage = reCaptchaResponseInvalidValidationMessage;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var captchaResponse =
                context.HttpContext.Request.HasFormContentType && context.HttpContext.Request.Form[this._recaptchaResponseKey].Any() ?
                context.HttpContext.Request.Form[this._recaptchaResponseKey].First() :
                context.HttpContext.Request.Headers[this._recaptchaResponseKey].Any() ?
                context.HttpContext.Request.Headers[this._recaptchaResponseKey].ToString() :
                context.HttpContext.Request.Cookies[this._recaptchaResponseKey] != null && context.HttpContext.Request.Cookies[this._recaptchaResponseKey].Any() ?
                context.HttpContext.Request.Cookies[this._recaptchaResponseKey] :
                string.Empty;

            if (string.IsNullOrEmpty(captchaResponse))
            {
                context.ModelState.AddModelError("ReCaptchaResponseNotPresent", this._reCaptchaResponseNotPresentValidationMessage);
                return;
            }

            var validationService = new ReCaptchaValidationService(this._secretKey);

            var validationResult = validationService.Validate(captchaResponse).Result;

            if (validationResult?.Success != true)
            {
                context.ModelState.AddModelError("ReCaptchaResponseInvalid", this._reCaptchaResponseInvalidValidationMessage);
            }
        }
    }
}
