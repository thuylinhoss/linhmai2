﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FashionShop2._0
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Product Category",
                url: "san-pham/{metatitle}-{id}",
                defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
                namespaces: new[] { "FashionShop2._0.Controllers" }
            );

            routes.MapRoute(
                name: "Product Detail",
                url: "chi-tiet/{metatitle}-{id}",
                defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "FashionShop2._0.Controllers" }
            );

            routes.MapRoute(
               name: "Nu",
               url: "do-nu",
               defaults: new { controller = "Nu", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "FashionShop2._0.Controllers" }
           );

            routes.MapRoute(
               name: "Nam",
               url: "do-nam",
               defaults: new { controller = "Nam", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "FashionShop2._0.Controllers" }
           );

            routes.MapRoute(
               name: "Ship",
               url: "deliver",
               defaults: new { controller = "Shiping", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "FashionShop2._0.Controllers" }
           );

            routes.MapRoute(
               name: "Dieu khoan",
               url: "dieu-khoan",
               defaults: new { controller = "DieuKhoan", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "FashionShop2._0.Controllers" }
           );

            routes.MapRoute(
               name: "About",
               url: "about",
               defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "FashionShop2._0.Controllers" }
           );

            routes.MapRoute(
               name: "Feed back",
               url: "feed-back",
               defaults: new { controller = "FeedBack", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "FashionShop2._0.Controllers" }
           );

            routes.MapRoute(
               name: "Cart",
               url: "gio-hang",
               defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "FashionShop2._0.Controllers" }
           );
            routes.MapRoute(
               name: "Payment",
               url: "thanh-toan",
               defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
               namespaces: new[] { "FashionShop2._0.Controllers" }
           );
            routes.MapRoute(
               name: "Payment Success",
               url: "hoan-thanh",
               defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
               namespaces: new[] { "FashionShop2._0.Controllers" }
           );

            routes.MapRoute(
               name: "Add cart",
               url: "them-gio-hang",
               defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
               namespaces: new[] { "FashionShop2._0.Controllers" }
           );
            routes.MapRoute(
               name: "Register",
               url: "dang-ky",
               defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
               namespaces: new[] { "FashionShop2._0.Controllers" }
           );
            routes.MapRoute(
               name: "Login",
               url: "dang-nhap",
               defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional },
               namespaces: new[] { "FashionShop2._0.Controllers" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "FashionShop2._0.Controllers" }
            );
        }
    }
}
