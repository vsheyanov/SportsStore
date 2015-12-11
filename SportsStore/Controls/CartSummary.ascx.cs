using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;

using SportsStore.Models;
using SportsStore.Pages.Helpers;

namespace SportsStore.Controls
{
    public partial class CartSummary : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cart userCart = SessionHelper.GetCart(Session);

            csQuantity.InnerText = userCart.Lines.Sum(line => line.Quanity).ToString();
            csTotal.InnerText = userCart.ComputeTotalValue().ToString("c");
            csLink.HRef = RouteTable.Routes.GetVirtualPath(null, "checkout", null).VirtualPath;
        }
    }
}