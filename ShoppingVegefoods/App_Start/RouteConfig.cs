using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShoppingVegefoods
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region Route Product
            routes.MapRoute(
                "ProductList",
                "san-pham/{action}/{id}",
                new { controller = "Product", action = "Index", id = UrlParameter.Optional },
                new[] { "ShoppingVegefoods.Controllers" }
            );
            #endregion

            #region Route About
            routes.MapRoute(
                "About",
                "lien-he/{action}/{id}",
                new { controller = "About", action = "Index", id = UrlParameter.Optional },
                new[] { "ShoppingVegefoods.Controllers" }
            );
            #endregion

            #region Route Blog
            routes.MapRoute(
                "Blog",
                "blog-tin-tuc/{action}/{id}",
                new { controller = "Blog", action = "Index", id = UrlParameter.Optional },
                new[] { "ShoppingVegefoods.Controllers" }
            );
            #endregion

            #region Route User
            routes.MapRoute(
                "User",
                "tai-khoan/{action}/{id}",
                new { controller = "User", action = "Index", id = UrlParameter.Optional },
                new[] { "ShoppingVegefoods.Controllers" }
            );
            #endregion

            #region Route Default
            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "ShoppingVegefoods.Controllers" }
            );
            #endregion
        }
    }
}
