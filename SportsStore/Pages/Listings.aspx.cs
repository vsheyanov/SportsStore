using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SportsStore.Models;
using SportsStore.Models.Repository;

namespace SportsStore.Pages
{
    public partial class Listings : System.Web.UI.Page
    {
        private Repository repository = new Repository();

        private int pageSize = 4;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected IEnumerable<Product> GetProducts()
        {
            return repository.Products
                .OrderBy(product => product.Price)
                .Skip((CurrentPage-1) * pageSize)
                .Take(pageSize);
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
                return (int)Math.Ceiling((decimal)repository.Products.Count() / pageSize);
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