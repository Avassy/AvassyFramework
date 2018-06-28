using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace Avassy.AspNetCore.Mvc.InvisibleReCaptcha
{
    /// <inheritdoc />
    /// <summary>
    /// The class that holds a TagHelper to create the reCaptcha markup.
    /// </summary>
    /// <seealso cref="T:Microsoft.AspNetCore.Razor.TagHelpers.TagHelper" />
    [HtmlTargetElement(Attributes = AspInvisibleRecaptchaAttributeName)]
    public class RecaptchaTagHelpers : TagHelper
    {
        private const string AspInvisibleRecaptchaAttributeName = "asp-invisible-recaptcha";

        /// <summary>
        /// Synchronously executes the <see cref="T:Microsoft.AspNetCore.Razor.TagHelpers.TagHelper" /> with the given <paramref name="context" /> and
        /// <paramref name="output" />.
        /// </summary>
        /// <param name="context">Contains information associated with the current HTML tag.</param>
        /// <param name="output">A stateful HTML element used to generate an HTML tag.</param>
        /// <exception cref="ArgumentNullException">
        /// id - You must specify an identifier on the element for the reCaptcha to work.
        /// or
        /// data-recaptcha-key - You must specify a data-recaptcha-key attribute on the element for the reCaptcha to work.
        /// or
        /// data-recaptcha-cookie - You must specify a valid boolean (true, false) for the data-recaptcha-cookie attribute on the element.
        /// </exception>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!context.AllAttributes.TryGetAttribute("id", out var id))
            {
                // ReSharper disable once NotResolvedInText
                throw new ArgumentNullException("id", "You must specify an identifier on the element for the reCaptcha to work.");
            }

            if (!context.AllAttributes.TryGetAttribute("data-recaptcha-key", out var publicKey))
            {
                // ReSharper disable once NotResolvedInText
                throw new ArgumentNullException("data-recaptcha-key", "You must specify a data-recaptcha-key attribute on the element for the reCaptcha to work.");
            }

            context.AllAttributes.TryGetAttribute("data-recaptcha-event", out var @event);
            context.AllAttributes.TryGetAttribute("data-recaptcha-before", out var before);
            context.AllAttributes.TryGetAttribute("data-recaptcha-cookie", out var useCookie);

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
