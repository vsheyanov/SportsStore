<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listings.aspx.cs" Inherits="SportsStore.Pages.Listings"
    MasterPageFile="/Pages/Store.Master" %>
<%@ Import Namespace="System.Web.Routing" %>

<asp:Content ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
              <%foreach (SportsStore.Models.Product product in GetProducts()) {
                      Response.Write("<div class='item'>");
                      Response.Write(string.Format("<h3>{0}</h3>", product.Name));
                      Response.Write(product.Description);
                      Response.Write(string.Format("<h4>{0:c}</h4>", product.Price));
                      Response.Write("</div>");
                  } %>  
        </div>

    <div class="pager">
        <% for (int i = 1; i <= MaxPage; i++)
            {
                string path = RouteTable.Routes.GetVirtualPath(null, null, new RouteValueDictionary() { { "page", i } }).VirtualPath;
                Response.Write(string.Format("<a href='{0}' {1}>{2}</a>", path, (i==CurrentPage?"class='selected'":""), i));
            } %>
    </div>
</asp:Content>