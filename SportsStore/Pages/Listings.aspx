<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listings.aspx.cs" Inherits="SportsStore.Pages.Listings"
    MasterPageFile="/Pages/Store.Master" %>

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
        <% for (int i = 0; i < MaxPage; i++)
            {
                Response.Write(string.Format("<a href='/list/{0}' {1}>{0}</a>", i+1, (i+1==CurrentPage?"class='selected'":"")));
            } %>
    </div>
</asp:Content>