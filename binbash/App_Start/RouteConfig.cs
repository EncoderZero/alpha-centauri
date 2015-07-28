using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace binbash {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AddToCart",
                url: "cart/add",
                defaults: new { controller = "Cart", action = "AddToCart" }
            );

            routes.MapRoute(
               name: "Cart",
               url: "cart",
               defaults: new { controller = "Cart", action = "Cart" }
            );

            routes.MapRoute(
               name: "RemoveFromCart",
               url: "cart/remove",
               defaults: new { controller = "Cart", action = "RemoveFromCart" }
            );

            routes.MapRoute(
               name: "SetCartQuantity",
               url: "cart/setQuantity",
               defaults: new { controller = "Cart", action = "SetCartQuantity" }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
