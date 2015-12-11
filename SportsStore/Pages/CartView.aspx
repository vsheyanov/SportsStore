<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartView.aspx.cs" Inherits="SportsStore.Pages.CartView" 
    MasterPageFile="~/Pages/Store.Master" %>

<asp:Content ID="cartContent" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <h2>Your cart</h2>
        <table id="cartTable">
            <thead>
                <tr><th>Quantity</th><th>Item</th><th>Price</th><th>Subtotal</th></tr>
            </thead>
            <tbody>
                <asp:Repeater ItemType="SportsStore.Models.CartLine" SelectMethod="GetCartLine"  runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <tr>
                            <td><%# Item.Quanity %></td>
                            <td><%# Item.Product.Name %></td>
                            <td><%# Item.Product.Price %></td>
                            <td><%# (Item.Quanity * Item.Product.Price).ToString("c") %></td>
                            <td><button type="submit"
                                        class="actionButtons"
                                        name="remove"
                                        value="<%# Item.Product.ProductID %>">Remove</button></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="3">Total:</td>
                    <td><%= CartTotal.ToString("c") %></td>
                </tr>
            </tfoot>
        </table>
        <p class="actionButtons"><a href="<%= ReturnURL %>">Continue shopping</a></p>
    </div>
</asp:Content>