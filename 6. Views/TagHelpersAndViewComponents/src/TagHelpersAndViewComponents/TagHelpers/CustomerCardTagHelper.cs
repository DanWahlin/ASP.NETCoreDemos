using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpersAndViewComponents.TagHelpers
{
    [HtmlTargetElement("customerCard")]
    public class CustomerCardTagHelper : TagHelper
    {
        [HtmlAttributeName("firstName")]
        public string FirstName { get; set; }

        [HtmlAttributeName("lastName")]
        public string LastName { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Content.AppendHtml($"<h4>CustomerCard Tag Helper</h4><div>{FirstName} {LastName}</div>");
        }
    }
}
