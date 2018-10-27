using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Avassy.AspNetCore.Mvc.TagHelpers
{
    /// <inheritdoc />
    /// <summary>
    /// The class that holds a TagHelper to create a placeholder for a control based on the Display attribute..
    /// </summary>
    /// <seealso cref="T:Microsoft.AspNetCore.Razor.TagHelpers.TagHelper" />
    [HtmlTargetElement("input", Attributes = AspPlaceholderForAttributeName)]
    [HtmlTargetElement("textarea", Attributes = AspPlaceholderForAttributeName)]
    public class AspPlaceholderForTagHelper : TagHelper
    {
        private const string AspPlaceholderForAttributeName = "asp-placeholder-for";

        /// <summary>
        /// Gets or sets the For model expression.
        /// </summary>
        /// <value>
        /// For.
        /// </value>
        [HtmlAttributeName(AspPlaceholderForAttributeName)]
        public ModelExpression For { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Synchronously executes the <see cref="T:Microsoft.AspNetCore.Razor.TagHelpers.TagHelper" /> with the given <paramref name="context" /> and
        /// <paramref name="output" />.
        /// </summary>
        /// <param name="context">Contains information associated with the current HTML tag.</param>
        /// <param name="output">A stateful HTML element used to generate an HTML tag.</param>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("placeholder", this.For.Metadata.DisplayName);
        }
    }
}