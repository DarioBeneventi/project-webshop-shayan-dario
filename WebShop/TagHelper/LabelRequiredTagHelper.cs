using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.TagHelpers
{
    [HtmlTargetElement("label", Attributes = ForAttributeName)]
    public class LabelRequiredTagHelper : LabelTagHelper
    {
        private const string ForAttributeName = "asp-for";

        public LabelRequiredTagHelper(IHtmlGenerator generator) : base(generator)
        {
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await base.ProcessAsync(context, output);

            var isRequired = For.Metadata.IsRequired;
            var isNullableType = For.Metadata.IsReferenceOrNullableType;
            var type = For.Metadata.ModelType;
            var isBool = type.FullName == "System.Boolean";

            if ((isRequired && !isBool) || (!isBool && !isNullableType))
            {
                var sup = new TagBuilder("sup");
                sup.InnerHtml.Append("*");
                output.Content.AppendHtml(sup);
            }
        }
    }
}
