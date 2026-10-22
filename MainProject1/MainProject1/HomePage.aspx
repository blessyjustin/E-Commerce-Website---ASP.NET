<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="MainProject1.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
.hero-section {
    margin-top:150px;
    position: relative;
}

.hero-image {
    width: 100%;
    display: block;
}

.hero-text {
    position: absolute;
    top: 50%;
    left: 10%;
    transform: translateY(-50%);
}
.categories h2{
    text-align:center;
    margin-top:30px;
    
}
.category-container {
    width: 100%;
    text-align: center;
}

.category-container table {
    width: 100%;
}

.category-container td {
    width: 25%;
    text-align: center;
    vertical-align: top;
}

.category-card {
    margin: 20px 20px;
    text-align: center;
}

.category-card-img {
    width: 100%;
    height: auto;
    display: block;
}


    </style>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero-section">
        <img src="assets\images\banner-image01.png" class="hero-image" />
        <div class="hero-text">
            <h1>Welcome to Our Store</h1>
            <h3>Fashion for a Better You</h3>
            <p>
                Discover stylish collections for men, women and kids.<br />
                Quality, comfort and style – all in one place.
            </p>
            <a href="Login.aspx" class="shop-btn" style="background-color:sandybrown;color:white">SHOP NOW →</a>
        </div>
    </div>
    <div class="categories">
    <h2>Shop By Category</h2>
        <div class="category-container">
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                <ItemStyle ForeColor="Black" />
                <ItemTemplate>
                <div class="category-card">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("image") %>' CssClass="category-card-img" CommandArgument='<%# Eval("category_id") %>' OnCommand="ImageButton1_Command" />
                    <br />
                    <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("category_name") %>' Font-Bold="True" Font-Size="Larger" ForeColor="Black" CommandArgument='<%# Eval("category_id") %>' OnCommand="LinkButton1_Command"></asp:LinkButton>
                </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
</div>
</asp:Content>

