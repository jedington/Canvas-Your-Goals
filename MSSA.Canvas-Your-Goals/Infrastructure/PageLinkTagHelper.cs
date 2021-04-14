using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MSSA.Canvas_Your_Goals.Models;

namespace MSSA.Canvas_Your_Goals.Infrastructure
{
    [HtmlTargetElement("span", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        // fields and properties
        private IUrlHelperFactory _helpFactory;
        public string PageAction { get; set; }
        public string PageClass { get; set; }
        public bool PageClassEnabled { get; set; } = false;
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }
        public PagingInfo PageModel { get; set; }
        [ViewContext, HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        // constructors
        public PageLinkTagHelper (IUrlHelperFactory helpFactory)
        {
            _helpFactory = helpFactory;
        } // PageLinkTagHelper const ends
 
        // methods
        public override void Process (TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = _helpFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("span");
            for (int i = 1; i <= PageModel.TotalPages(); i++)
            {
                //- if (i != PageModel.CurrentPage)
                //- {
                TagBuilder tag = new TagBuilder("a");
                tag.Attributes["href"] = urlHelper.Action(PageAction, 
                    new { productPage = i });
                if (PageClassEnabled == true)
                {
                    tag.AddCssClass(PageClass);
                    if (i == PageModel.CurrentPage)
                    {
                        tag.AddCssClass(PageClassSelected);
                    }
                    else
                    {
                        tag.AddCssClass(PageClassNormal);
                    }
                }
                tag.InnerHtml.Append($"Page {i}");
                result.InnerHtml.AppendHtml(tag);
                //- result.InnerHtml.AppendHtml("\t|\t");
                //- }
                //- else
                //- {
                //-     result.InnerHtml.AppendHtml($"Page{i}\t|\t");
                //- }
            }
            output.Content.AppendHtml(result.InnerHtml);
        } // Process method ends
    } // class ends
} // namespace ends