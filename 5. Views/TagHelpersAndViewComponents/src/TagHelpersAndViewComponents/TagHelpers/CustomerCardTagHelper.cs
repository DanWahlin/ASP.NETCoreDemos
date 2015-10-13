using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using System.Text;

namespace TagHelpersAndViewComponents.TagHelpers
{
    [TargetElement("customerCard")]
    public class CustomerCardTagHelper : TagHelper
    {
        [HtmlAttributeName("firstName")]
        public string FirstName { get; set; }

        [HtmlAttributeName("lastName")]
        public string LastName { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            var sb = new StringBuilder();
            sb.Append(String.Format("<h4>CustomerCard Tag Helper</h4><div>{0} {1}</div>", FirstName, LastName));

            output.Content.Append(sb.ToString());
            base.Process(context, output);
        }
    }
}
