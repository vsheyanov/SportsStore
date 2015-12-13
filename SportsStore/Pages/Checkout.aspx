<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="SportsStore.Pages.Checkout"
        MasterPageFile="~/Pages/Store.Master" %>

<asp:Content ID="checkoutContent" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <div id="checkoutForm" class="checkout" runat="server">
            <h2>Checkout Now</h2>
            Please enter you details, and we'll ship your goods right away!

            <div id="errors" data-valmsg-summary="true">
                <ul><li style="display: none"></li></ul>
                <asp:ValidationSummary runat="server" />
            </div>

            <h3>Ship to</h3>
            <div>
                <label for="name">Name:</label>
                <SX:VInput Property="Name" runat="server"/>
            </div>

            <h3>Address</h3>
            <div><label for="line1">Line 1:</label><input type="text" id="line1" name="line1" /></div>
            <div><label for="line2">Line 2:</label><input type="text" id="line2" name="line2" /></div>
            <div><label for="line3">Line 3:</label><input type="text" id="line3" name="line3" /></div>
            <div><label for="city">City:</label><input type="text" id="city" name="city" /></div>
            <div><label for="state">State:</label><input type="text" id="state" name="state" /></div>

            <h3>Options</h3>
            <input type="checkbox" id="giftwrap" name="giftwrap" value="true" />
            Gift wrap this items?

            <p class="actionButtons">
                <button class="actionButtons" type="submit">Complete Order</button>
            </p>
        </div>
        <div id="checkoutMessage" runat="server">
            <h2>Thanks</h2>
            Thanks for placing your order. We'll ship our goods as soon as possible.
        </div>
    </div>
</asp:Content>