<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="singleProduct.aspx.cs" Inherits="MainProject1.singleProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
.single-product {
    display: flex;
    gap: 60px;
    margin-top: 120px;
    padding: 50px;
}

.product-image {
    width: 450px;
    margin-left:100px;
    margin-right:20px;
}

.product-image img {
    width: 100%;
    height: 500px;
    object-fit: contain;
}

.product-details {
    width: 400px;
    padding-top: 30px;
}

.product-details h2 {
    margin-bottom: 15px;
}

.product-details h3 {
    margin-bottom: 25px;
}

.product-details p {
    margin-bottom: 20px;
}
.size-section {
    margin-top: 25px;
}

.size-buttons {
    margin-top: 10px;
}

.size-button {
    background-color: white;
    border: 1px solid #000;
    padding: 8px 18px;
    margin-right: 8px;
    cursor: pointer;
}

.size-button:hover {
    background-color: #000;
    color: white;
}
.size-button.selected {
    background-color: #000;
    color: white;
}
.add-cart-button {
    margin-top: 25px;
    padding: 12px 35px;
    background-color: sandybrown;
    color: white;
    border: 1px solid sandybrown;
    cursor: pointer;
}

.add-cart-button:hover {
    background-color: white;
    color: sandybrown;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="single-product">
    <div class="product-image">
        <asp:Image ID="ProductImage" runat="server" />
    </div>
    <div class="product-details">
        <h2><asp:Label ID="ProductName" runat="server"></asp:Label></h2>
        <h3>₹ <asp:Label ID="ProductPrice" runat="server"></asp:Label></h3>
        <p><asp:Label ID="ProductDescription" runat="server"></asp:Label></p>
        <div class="size-section">
            <b>Size:</b>
            <div class="size-buttons">
                <asp:Button ID="SizeS" runat="server" Text="S" CssClass="size-button" OnClick="SizeS_Click"  />
                <asp:Button ID="SizeM" runat="server" Text="M" CssClass="size-button" OnClick="SizeM_Click" />
                <asp:Button ID="SizeL" runat="server" Text="L" CssClass="size-button" OnClick="SizeL_Click" />
                <asp:Button ID="SizeXL" runat="server" Text="XL" CssClass="size-button" OnClick="SizeXL_Click" />
                <asp:Label ID="SelectedSize" runat="server" Visible="False"></asp:Label>
             </div>
        </div>
        <p>
            <b>Available:</b>
            <asp:Label ID="ProductStock" runat="server"></asp:Label>
        </p>
        <div class="quantity-section">
            <div class="quantity-box">
                <b>Quantity:</b>
                <asp:Button ID="btnMinus" runat="server" Text="−" CssClass="quantity-button" OnClick="btnMinus_Click" />
                <asp:Label ID="lblQuantity" runat="server" Text="1" CssClass="quantity-number"></asp:Label>
                <asp:Button ID="btnPlus" runat="server" Text="+" CssClass="quantity-button" OnClick="btnPlus_Click" />
             </div>
        </div>
        <asp:Button  ID="Button1"  runat="server"  Text="ADD TO CART" CssClass="add-cart-button" OnClick="Button1_Click" />
    </div>
</div>
</asp:Content>
