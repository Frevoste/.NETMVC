using CommonMark;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Hotels.Helpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("tolist")]
    public class ToListHelper : TagHelper
    {
        [HtmlAttributeName("asp-action")]
        public string Action { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            var link = new TagBuilder("a");
            link.Attributes.Add("asp-action", Action);
            link.AddCssClass("btn btn-secondary");
            link.InnerHtml.Append("Back to List");

            output.Content.SetHtmlContent(link);
        }
    }
}
