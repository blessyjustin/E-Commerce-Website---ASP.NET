<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="MainProject1.cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    .cart-section {
        margin-top:100px;
        padding:50px;
    }
      
    .cart-title {
        margin-bottom:30px;
    }

    .cart-table {
        width:100%;
        border-collapse:collapse;
    }

    .cart-table th {
        text-align:left;
        padding:15px;
        border-bottom:1px solid #ddd;
    }

    .cart-table td {
        padding:15px;
        /*border-bottom:1px solid #ddd;*/
        vertical-align:middle;
    }

    .cart-image {
        width:100px;
        height:120px;
        object-fit:cover;
    }

    .quantity-button {
        width:30px;
        height:30px;
        border:1px solid #000;
        background-color:white;
        cursor:pointer;
    }

    .quantity-number {
        margin:0 10px;
    }

    .remove-button {
        border:none;
        background-color:white;
        color:red;
        cursor:pointer;
    }

    .subtotal {
        text-align:right;
        margin-top:30px;
        font-size:20px;
    }
    .order-button {
    text-align: right;
    margin-top: 20px;
    }

    .place-order-button {
        padding: 12px 30px;
        background-color: sandybrown;
        color: white;
        border: 1px solid sandybrown;
        cursor: pointer;
    }

    .place-order-button:hover {
        background-color: white;
        color: sandybrown;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="cart-section">
    <h2 class="cart-title">My Cart</h2>

    <asp:DataList ID="DataList1" runat="server" Width="100%">
        <HeaderTemplate>
            <table class="cart-table">
                <tr>
                    <th>Product</th>
                    <th>Price</th>
                    <th>Size</th>
                    <th>Quantity</th>
                    <th>Total</th>
                    <th></th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Image ID="ProductImage" runat="server" ImageUrl='<%# Eval("image") %>' CssClass="cart-image" />
                    <asp:Label ID="ProductName" runat="server" Text='<%# Eval("product_name") %>'> </asp:Label>
                </td>
                <td>
                    ₹
                    <asp:Label ID="ProductPrice" runat="server" Text='<%# Eval("price") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="ProductSize" runat="server" Text='<%# Eval("size") %>'></asp:Label>
                </td>
                <td>
                    <asp:Button ID="Button_Minus" runat="server" Text="−" CssClass="quantity-button" CommandArgument='<%# Eval("cart_id") %>' OnCommand="Button_Minus_Command" />
                    <asp:Label ID="Quantity" runat="server" Text='<%# Eval("quantity") %>'  CssClass="quantity-number"></asp:Label>
                    <asp:Button ID="Button_Plus" runat="server" Text="+" CssClass="quantity-button" CommandArgument='<%# Eval("cart_id") %>' OnCommand="Button_Plus_Command" />
                </td>
                <td>
                    ₹<asp:Label ID="ItemTotal" runat="server" Text='<%# Eval("subtotal") %>'> </asp:Label>
                </td>
                <td>
                    <asp:Button ID="Button_Remove" runat="server" Text="Remove"  CssClass="remove-button" CommandArgument='<%# Eval("cart_id") %>' OnCommand="Button_Remove_Command" />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:DataList>
    <div class="subtotal">
        <b>Subtotal: ₹</b>
        <asp:Label ID="Subtotal" runat="server"></asp:Label>
    </div>
    <div class="order-button">
    <asp:Button ID="Order" runat="server" Text="Proceed to Buy" CssClass="place-order-button" OnClick="Order_Click"  />
</div>
</div>
</asp:Content>
