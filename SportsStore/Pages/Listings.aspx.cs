using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;

using SportsStore.Models;
using SportsStore.Models.Repository;

using SportsStore.Pages.Helpers;

namespace SportsStore.Pages
{
    public partial class Listings : System.Web.UI.Page
    {
        private Repository repository = new Repository();

        private int pageSize = 4;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                return;

            int selectedProductId;

            if (int.TryParse(Request.Form["add"], out selectedProductId))
            {
                Product product = repository.Products
                    .Where(p => p.ProductID == selectedProductId)
                    .FirstOrDefault();
                if (product != null)
                {
                    SessionHelper.GetCart(Session).AddItem(product, 1);
                    SessionHelper.Set(Session, SessionKey.RETURN_URL, Request.RawUrl);
                    Response.Redirect(RouteTable.Routes.GetVirtualPath(null, "cart", null).VirtualPath);
                }
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            return FilteredProducts()
                .OrderBy(product => product.Price)
                .Skip((CurrentPage-1) * pageSize)
                .Take(pageSize);
        }

        protected IEnumerable<Product> FilteredProducts()
        {
            IEnumerable<Product> products = repository.Products; 
            string category = (string)RouteData.Values["category"] ?? Request.QueryString["category"];
            return category == null ? products : products.Where(product => product.Category == category);
        }

        protected int CurrentPage
        {
            get
            {
                int page = GetPageFromRequest();
                return page > MaxPage ? MaxPage : page;
            }
        }

        protected int MaxPage
        {
            get
            {
                return (int)Math.Ceiling((decimal)FilteredProducts().Count() / pageSize);
            }
        }

        private int GetPageFromRequest()
        {
            int page;
            string reqValue = (string)RouteData.Values["page"] ?? Request.QueryString["page"];
            return reqValue != null && int.TryParse(reqValue, out page) ? page : 1;
        }        
    }
}