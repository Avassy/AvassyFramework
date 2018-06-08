using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Avassy.AspNetCore.Mvc.TagHelpers
{
    [HtmlTargetElement("input", Attributes = AspPlaceholderForAttributeName)]
    [HtmlTargetElement("textarea", Attributes = AspPlaceholderForAttributeName)]
    public class AspPlaceholderForTagHelper : TagHelper
    {
        private const string AspPlaceholderForAttributeName = "asp-placeholder-for";

        [HtmlAttributeName(AspPlaceholderForAttributeName)]
        public ModelExpression For { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("placeholder", this.For.Metadata.DisplayName);
        }
    }
}