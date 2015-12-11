using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SportsStore.Models;
using SportsStore.Pages.Helpers;

using SportsStore.Models.Repository;

namespace SportsStore.Pages
{
    public partial class CartView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                return;

            var repository = new Repository();
            int productId;
            if (int.TryParse(Request.Form["remove"], out productId))
            {
                Product productToRemove = repository.Products
                    .Where(product => product.ProductID == productId)
                    .FirstOrDefault();

                if (productToRemove != null)
                {
                    SessionHelper.GetCart(Session).RemoveLine(productToRemove);
                }
            }
        }

        public IEnumerable<CartLine> GetCartLine()
        {
            return SessionHelper.GetCart(Session).Lines;
        }

        public decimal CartTotal
        {
            get
            {
                return SessionHelper.GetCart(Session).ComputeTotalValue();
            }
        }

        public string ReturnURL
        {
            get {
                return SessionHelper.Get<string>(Session, SessionKey.RETURN_URL);
            }
        }
    }
}