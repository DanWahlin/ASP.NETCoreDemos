using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using System.Text;

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
        output.Content.Append($"<h4>CustomerCard Tag Helper</h4><div>{FirstName} {LastName}</div>");
        base.Process(context, output);
    }
}
}
