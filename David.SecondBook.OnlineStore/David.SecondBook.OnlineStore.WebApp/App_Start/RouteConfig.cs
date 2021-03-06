﻿using System.Web.Mvc;
using System.Web.Routing;

namespace David.SecondBook.OnlineStore.WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
            null,
            "Page{page}",
            new { controller = "Product", action = "List", category = (string)null },
            new { page = @"\d+" }
            );
            routes.MapRoute(
            null,
            "Category{category}",
            new { controller = "Product", action = "List", page = 1 }
            );
            routes.MapRoute(
            null,
            "Category{category}/Page{page}",
            new { controller = "Product", action = "List" },
            new { page = @"\d+" }
            );
            routes.MapRoute(
            null,
            "",
            new
            {
                controller = "Product",
                action = "List",
                category = (string)null,
                page = 1
            }
            );

            routes.MapRoute(null, "{controller}/{action}");
        }

    }
}
