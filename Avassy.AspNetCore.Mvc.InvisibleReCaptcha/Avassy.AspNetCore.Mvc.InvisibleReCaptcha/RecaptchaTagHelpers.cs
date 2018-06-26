using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Avassy.AspNetCore.Mvc.InvisibleReCaptcha
{
    [HtmlTargetElement(Attributes = AspInvisibleRecaptchaAttributeName)]
    public class RecaptchaTagHelpers : TagHelper
    {
        private const string AspInvisibleRecaptchaAttributeName = "asp-invisible-recaptcha";
        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagHelperAttribute id, publicKey, @event, before, useCookie;

            if (!context.AllAttributes.TryGetAttribute("id", out id))
            {
                // ReSharper disable once NotResolvedInText
                throw new ArgumentNullException("id", "You must specify an identifier on the element for the reCaptcha to work.");
            }

            if (!context.AllAttributes.TryGetAttribute("data-recaptcha-key", out publicKey))
            {
                // ReSharper disable once NotResolvedInText
                throw new ArgumentNullException("data-recaptcha-key", "You must specify a data-recaptcha-key attribute on the element for the reCaptcha to work.");
            }

            context.AllAttributes.TryGetAttribute("data-recaptcha-event", out @event);
            context.AllAttributes.TryGetAttribute("data-recaptcha-before", out before);
            context.AllAttributes.TryGetAttribute("data-recaptcha-cookie", out useCookie);

            var useCookieBool = false;

            if (useCookie?.Value != null && !bool.TryParse(useCookie.Value.ToString(), out useCookieBool))
            {
                // ReSharper disable once NotResolvedInText
                throw new ArgumentNullException("data-recaptcha-cookie", "You must specify a valid boolean (true, false) for the data-recaptcha-cookie attribute on the element.");
            }

            var reCaptchaBuilder = new ReCaptchaBuilder(publicKey.Value.ToString(), id.Value.ToString(), @event?.Value?.ToString(), before?.Value?.ToString(), useCookieBool);

            output.PostElement.AppendHtml(reCaptchaBuilder.BuildReCaptchaContainerHtml());
            output.PostElement.AppendHtml(reCaptchaBuilder.BuildReCaptchaScript());
        }
    }
}
