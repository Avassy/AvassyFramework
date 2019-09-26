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
    /// The class that holds a TagHelper that minifies Javascript.
    /// </summary>
    /// <seealso cref="T:Microsoft.AspNetCore.Razor.TagHelpers.TagHelper" />
    [HtmlTargetElement("script", Attributes = AspMinifiedScriptAttributeName)]
    public class AspMinifiedScriptTagHelper : TagHelper
    {

        /// <summary>
        /// The asp-minified-style tag name
        /// </summary>
        private const string AspMinifiedScriptAttributeName = "asp-minified-script";

        ///// <summary>
        ///// Gets or sets the For model expression.
        ///// </summary>
        ///// <value>
        ///// For.
        ///// </value>
        //[HtmlAttributeName(AspMinifiedScriptAttributeName)]
        //public ModelExpression For { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Synchronously executes the <see cref="T:Microsoft.AspNetCore.Razor.TagHelpers.TagHelper" /> with the given <paramref name="context" /> and
        /// <paramref name="output" />.
        /// </summary>
        /// <param name="context">Contains information associated with the current HTML tag.</param>
        /// <param name="output">A stateful HTML element used to generate an HTML tag.</param>
        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            var unMinifiedScript = (await output.GetChildContentAsync()).GetContent();

            var minifiedScript = new Minifier().MinifyJavaScript(unMinifiedScript);

            output.Content.Clear();

            output.Content.AppendHtml(minifiedScript);
        }
    }
}
