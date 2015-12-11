using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace SportsStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(null, "list/{category}/{page}", "~/Pages/Listings.aspx");
            routes.MapPageRoute(null, "list/{page}", "~/Pages/Listings.aspx");
            routes.MapPageRoute(null, "", "~/Pages/Listings.aspx");
            routes.MapPageRoute(null, "list", "~/Pages/Listings.aspx");
            routes.MapPageRoute("cart", "cart", "~/Pages/CartView.aspx");
            routes.MapPageRoute("checkout", "checkout", "~/Pages/Checkout.aspx");
        }
    }
}