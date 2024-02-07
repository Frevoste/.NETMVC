using CommonMark;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Hotels.Helpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("markdown")]
    public class MarkdownHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;

            var childContent = await output.GetChildContentAsync();
            var lines = childContent.GetContent()
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(lines => lines.Trim());
            var content = string.Join(" ", lines);
            var transformedContent = CommonMarkConverter.Convert(content);

            output.Content.SetHtmlContent(transformedContent);
        }
    }
}
