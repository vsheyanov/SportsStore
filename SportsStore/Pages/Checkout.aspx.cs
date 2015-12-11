using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;

using SportsStore.Models;
using SportsStore.Models.Repository;
using SportsStore.Pages.Helpers;

namespace SportsStore.Pages
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkoutForm.Visible = true;
            checkoutMessage.Visible = false;

            if (!IsPostBack)
                return;

            Order usersOrder = new Order();
            if (TryUpdateModel(usersOrder, new FormValueProvider(ModelBindingExecutionContext))){
                usersOrder.OrderLines = new List<OrderLine>();

                Cart userCart = SessionHelper.GetCart(Session);

                foreach (CartLine line in userCart.Lines)
                {
                    usersOrder.OrderLines.Add(new OrderLine() {
                        Order = usersOrder,
                        Product = line.Product,
                        Quantity = line.Quanity
                    });
                }

                (new Repository()).SaveOrder(usersOrder);

                userCart.Clear();

                checkoutForm.Visible = false;
                checkoutMessage.Visible = true;
            }
        }
    }
}