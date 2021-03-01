using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluralsightPieCourse.TagHelpers
{
    // the name will be pulled from the class name, everthing before "TagHelper", so in this case: Email
    public class EmailTagHelper : TagHelper
    {
        public string Address { get; set; }
        public string Content { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", "mailto:" + Address);
            output.Content.SetContent(Content);
        }
    }
}
