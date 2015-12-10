<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listings.aspx.cs" Inherits="SportsStore.Pages.Listings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sports store</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
              <%foreach (SportsStore.Models.Product product in GetProducts()) {
                      Response.Write("<div class='item'>");
                      Response.Write(string.Format("<h3>{0}</h3>", product.Name));
                      Response.Write(product.Description);
                      Response.Write(string.Format("<h4>{0:c}</h4>", product.Price));
                      Response.Write("</div>");
                  } %>  
        </div>
    </form>
</body>
</html>
