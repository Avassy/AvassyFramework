using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Text;

namespace Avassy.AspNetCore.Mvc.InvisibleReCaptcha
{
    public static class ReCaptchaHelperExtensions
    {
        public static HtmlString InvisibleReCaptchaFor(this IHtmlHelper htmlHelper, string publicKey, string elementId,
            string @event = "click", string beforeReCaptcha = null, bool useCookie = false)
        {
            @event = @event ?? "click";

            return new HtmlString(
                BuildReCaptchaForElementHtml(publicKey, elementId, @event, beforeReCaptcha, useCookie));
        }

        private static string BuildReCaptchaForElementHtml(string publicKey, string elementId, string @event,
            string beforeReCaptcha, bool useCookie)
        {
            var reCaptchaBuilder = new ReCaptchaBuilder(publicKey, elementId, @event, beforeReCaptcha, useCookie);

            var builder = new StringBuilder();
            
            builder.Append(reCaptchaBuilder.BuildReCaptchaContainerHtml());
            builder.Append("");
            builder.Append(reCaptchaBuilder.BuildReCaptchaScript());
            builder.Append("");

            return builder.ToString();
        }
    }
}
