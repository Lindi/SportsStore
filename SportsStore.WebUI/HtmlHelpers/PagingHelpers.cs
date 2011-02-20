using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.WebUI.Models;
using System.Text;

namespace SportsStore.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
                                                PagingInfo pagingInfo,
                                                Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                //  Build an anchor tag
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                    tag.AddCssClass("selected");

                //  Append it to the string builder
                result.AppendLine(tag.ToString());
            }

            //  Feed the string builder to the MvcHtmlString static method
            //  to return an MvcHtmlString
            return MvcHtmlString.Create(result.ToString());
        }
    }
}