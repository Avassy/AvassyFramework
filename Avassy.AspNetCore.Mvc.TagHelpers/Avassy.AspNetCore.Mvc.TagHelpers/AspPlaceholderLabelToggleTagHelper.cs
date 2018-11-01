using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Avassy.AspNetCore.Mvc.TagHelpers
{
    /// <summary>
    /// The class that holds a TagHelper to create a toggle gfot a placeholder and label.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Razor.TagHelpers.TagHelper" />
    [HtmlTargetElement("input", Attributes = AspPlaceholderLabelToggleAttributeName)]
    [HtmlTargetElement("textarea", Attributes = AspPlaceholderLabelToggleAttributeName)]
    public class AspPlaceholderLabelToggleTagHelper : TagHelper
    {
        /// <summary>
        /// The asp-placeholder-label-toggle tagname
        /// </summary>
        private const string AspPlaceholderLabelToggleAttributeName = "asp-placeholder-label-toggle";

        /// <summary>
        /// Synchronously executes the <see cref="T:Microsoft.AspNetCore.Razor.TagHelpers.TagHelper" /> with the given <paramref name="context" /> and
        /// <paramref name="output" />.
        /// </summary>
        /// <param name="context">Contains information associated with the current HTML tag.</param>
        /// <param name="output">A stateful HTML element used to generate an HTML tag.</param>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var id = Guid.NewGuid().ToString("N");

            output.Attributes.SetAttribute("onfocus", $"show_{id}(event);");
            output.Attributes.SetAttribute("onblur", $"hide_{id}(event);");

            context.AllAttributes.TryGetAttribute("placeholder", out var placeholder);
            context.AllAttributes.TryGetAttribute("data-label-css-class", out var labelCssClass);

            var labelHtml = $"<label id=\"{id}\" {(labelCssClass != null ? $"class=\"{labelCssClass.Value}\"" : string.Empty)}>{(placeholder != null ? placeholder.Value : string.Empty)}</label>";

            output.PreElement.AppendHtml(labelHtml);

            var scriptHtml =
                $"<script type=\"text/javascript\">" +
               
                $"document.getElementById(\"{id}\").style.visibility = \"hidden\";" +

                $"function show_{id}(e) {{" +
                $"e.target.placeholder = \"\";" +
                $"document.getElementById(\"{id}\").style.visibility = \"visible\";" +
                $"}};" +

                $"function hide_{id}(e) {{" +
                $"var labelElement = document.getElementById(\"{id}\");" +
                $"var element = e.target;" +

                $"if(!element.value) {{" +
                $"labelElement.style.visibility = \"hidden\";" +
                $"element.placeholder = labelElement.innerText || labelElement.textContent;" +
                $"}}" +

                $"}};" +

                $"</script>";

            output.PostElement.AppendHtml(scriptHtml);
        }
    }
}
