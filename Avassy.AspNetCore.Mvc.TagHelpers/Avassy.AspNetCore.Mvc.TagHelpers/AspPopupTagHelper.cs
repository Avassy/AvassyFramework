using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Avassy.AspNetCore.Mvc.TagHelpers
{
    [HtmlTargetElement(AspPopupName, TagStructure = TagStructure.WithoutEndTag)]
    public class AspPopupTagHelper : TagHelper
    {
        private const string AspPopupName = "asp-popup";

        public string DisplayText { get; set; }

        public string DisplayIconCssClass { get; set; }

        public string DisplayIconPosition { get; set; }

        public string CssClass { get; set; }

        public string TemplateId { get; set; }

        public string HtmlContent { get; set; }

        public int Top { get; set; }

        public int Left { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Synchronously executes the <see cref="T:Microsoft.AspNetCore.Razor.TagHelpers.TagHelper" /> with the given <paramref name="context" /> and
        /// <paramref name="output" />.
        /// </summary>
        /// <param name="context">Contains information associated with the current HTML tag.</param>
        /// <param name="output">A stateful HTML element used to generate an HTML tag.</param>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!string.IsNullOrEmpty(this.DisplayIconPosition) && this.DisplayIconPosition != "before" && this.DisplayIconPosition != "after")
            {
                throw new ArgumentException("When specifying the \"display-icon-position\" attribute, it must either be \"before\" or \"after\". If not specified, it will default to \"before\".");
            }

            if (!string.IsNullOrEmpty(this.TemplateId) && !string.IsNullOrEmpty(this.HtmlContent))
            {
                throw new ArgumentException("You must either specify the \"template-id\" attribute or the \"html-content\" attribute, not both.");
            }

            if (this.Height == 0)
            {
                this.Height = 500;
            }

            if (this.Width == 0)
            {
                this.Width = 500;
            }

            if (string.IsNullOrEmpty(this.DisplayIconPosition))
            {
                this.DisplayIconPosition = "before";
            }

            var iconBefore = this.DisplayIconPosition == "before";
            
            var tagContentBuilder = new StringBuilder();

            if (!string.IsNullOrEmpty(this.DisplayIconCssClass) && iconBefore)
            {
                tagContentBuilder.Append($"<i class=\"{this.DisplayIconCssClass}\"></i>");
            }

            if (!string.IsNullOrEmpty(this.DisplayText))
            {
                tagContentBuilder.Append($"{(iconBefore ? "&nbsp;" : string.Empty)}{this.DisplayText}{(!iconBefore ? "&nbsp;" : string.Empty)}");
            }

            if (!string.IsNullOrEmpty(this.DisplayIconCssClass) && !iconBefore)
            {
                tagContentBuilder.Append($"<i class=\"{this.DisplayIconCssClass}\"></i>");
            }

            var onClickFunctionName = $"onInfoClick_{Guid.NewGuid():N}";

            var scriptHtml = string.Empty;

            if (!string.IsNullOrEmpty(this.TemplateId))
            {
                scriptHtml =
                    $"<script>" +
                    $"function {onClickFunctionName}() {{" +

                    $"var top = {(this.Top == 0 ? $"(screen.height / 2) - ({this.Height} / 2)" : this.Top.ToString())};" +
                    $"var left = {(this.Left == 0 ? $"(screen.width / 2) - ({this.Width} / 2)" : this.Left.ToString())};" +

                    $"var templateElement = document.getElementById(\"{this.TemplateId}\");" +

                    $"if(!templateElement) {{" +
                    $"alert(\"The specified template with id '{this.TemplateId}' doesn't exist! Check if the template-id attribute is correct.\");" +
                    $"return;" +
                    $"}}" +

                    $"var clone = templateElement.content.cloneNode(true);" +

                    $"var infoWindow = window.open(\"\", \"_blank\", \"toolbar=yes,scrollbars=yes,resizable=yes,width={this.Width},height={this.Height},top=\" + top + \",left=\" + left);" +

                    $"infoWindow.document.body.appendChild(clone);" +

                    $"if (window.focus) {{" +
                    $"infoWindow.focus();" +
                    $"}}" +

                    $"}}" +
                    $"</script>";
            }

            if (!string.IsNullOrEmpty(this.HtmlContent))
            {
                scriptHtml =
                    $"<script>" +
                    $"function {onClickFunctionName}() {{" +

                    $"var top = {(this.Top == 0 ? $"(screen.height / 2) - ({this.Height} / 2)" : this.Top.ToString())};" +
                    $"var left = {(this.Left == 0 ? $"(screen.width / 2) - ({this.Width} / 2)" : this.Left.ToString())};" +
                    
                    $"var infoWindow = window.open(\"\", \"_blank\", \"toolbar=yes,scrollbars=yes,resizable=yes,width={this.Width},height={this.Height},top=\" + top + \",left=\" + left);" +

                    $"infoWindow.document.body.innerHTML = '{this.HtmlContent}';" +

                    $"if (window.focus) {{" +
                    $"infoWindow.focus();" +
                    $"}}" +

                    $"}}" +
                    $"</script>";
            }
            
            tagContentBuilder.Append(scriptHtml);

            var tagContent = tagContentBuilder.ToString();

            output.TagName = "a";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Attributes.SetAttribute("href", "#");
            output.Attributes.SetAttribute("onclick", $"{onClickFunctionName}();");

            if (!string.IsNullOrEmpty(this.CssClass))
            {
                output.Attributes.SetAttribute("class", this.CssClass);
            }

            output.Content.SetHtmlContent(tagContent);
        }
    }
}
