using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Avassy.AspNetCore.Mvc.TagHelpers
{
   

    /// <inheritdoc />
    /// <summary>
    /// The class that holds a TagHelper that minifies stylesheets.
    /// </summary>
    /// <seealso cref="T:Microsoft.AspNetCore.Razor.TagHelpers.TagHelper" />
    [HtmlTargetElement("style", Attributes = AspMinifiedStyleAttributeName)]
    public class AspMinifiedStyleTagHelper : TagHelper
    {
        /// <summary>
        /// The asp-minified-style tag name
        /// </summary>
        private const string AspMinifiedStyleAttributeName = "asp-minified-style";

        /// <inheritdoc />
        /// <summary>
        /// Synchronously executes the <see cref="T:Microsoft.AspNetCore.Razor.TagHelpers.TagHelper" /> with the given <paramref name="context" /> and
        /// <paramref name="output" />.
        /// </summary>
        /// <param name="context">Contains information associated with the current HTML tag.</param>
        /// <param name="output">A stateful HTML element used to generate an HTML tag.</param>
        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            var unMinifiedCss = (await output.GetChildContentAsync()).GetContent();
            
            var minifiedCss = new Minifier().MinifyStyleSheet(unMinifiedCss);

            output.Content.Clear();

            output.Content.AppendHtml(minifiedCss);
        }
    }
}
