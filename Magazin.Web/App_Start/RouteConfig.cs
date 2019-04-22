﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Magazin.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                "",
                new
                {
                    controller = "Goods",
                    action = "List",
                    category = (string)null,
                    page = 1
                });

            routes.MapRoute(
                    name: null,
                    url: "Page{page}",
                    defaults: new { controller = "Goods", action = "List", category = (string)null },
                    constraints: new { page = @"\d+" }
                );

            routes.MapRoute(null,
                "{category}",
                new { controller = "Goods", action = "List", page = 1 }
                );

            routes.MapRoute(null,
                "{category}/Page{page}",
                new { controller = "Goods", action = "List" },
                new { page = @"\d+" }
                );
            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
