﻿namespace David.SecondBook.OnlineStore.WebApp.HtmlHelpers
{
    using David.SecondBook.OnlineStore.WebApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;

    public static class PagingHelpers
    {
        // <a class="btn btn-default btn-primary selected" href="Category0/Page2">2</a>
        public static MvcHtmlString PageLinks(
            this HtmlHelper html,
            PagingInfo pagingInfo,
            Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)  // page 1 2 3....
            {
                TagBuilder tag = new TagBuilder("a");         //< a
                tag.MergeAttribute("href", pageUrl(i));       
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }

            return MvcHtmlString.Create(result.ToString());
        }
    }
}

