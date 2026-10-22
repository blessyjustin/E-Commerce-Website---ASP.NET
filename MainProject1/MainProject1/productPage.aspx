<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="productPage.aspx.cs" Inherits="MainProject1.productPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        h2{
            margin-bottom:10px;
        }

        .products-section {
            margin-top:100px;
            text-align: left;
            padding: 50px;
        }

        .product-container {
            width: 100%;
        }

        .product-container table {
            width: 100%;
        }

        .product-container td {
            width: 25%;
            vertical-align: top;
        }

        .product-card {
            width: 90%;
            margin: 0 auto 40px;
        }

        .product-card-img {
            width: 100%;
            height: 320px;
            object-fit: cover;
            display: block;
        }
        .subcategory-button {
            display: inline-block;
            padding: 8px 20px;
            margin: 5px;
            border: 1px solid #000;
            color: #000;
            text-decoration: none;
            transition: 0.3s;
        }

        .subcategory-button:hover {
            background-color: #000;
            color: white;
            text-decoration: none;
        }
        .subcategory-container {
            margin: 30px 0;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="products-section">
        <h2>
          <asp:Label ID="Label1" runat="server"></asp:Label>
        </h2>
        <div class="subcategory-container">
            <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal">
            <ItemTemplate>
                <asp:LinkButton ID="Subcategory" CssClass="subcategory-button" runat="server" Text='<%# Eval("subcategory_name") %>' CommandArgument='<%# Eval("subcategory_id") %>' OnCommand="Subcategory_Command"></asp:LinkButton>
            </ItemTemplate>
            </asp:DataList>
        </div>
        <div class="product-container">
            <asp:DataList ID="DataList2"  runat="server" RepeatDirection="Horizontal" RepeatColumns="4">
            <ItemTemplate>
            <div class="product-card">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("image") %>' CssClass="product-card-img" CommandArgument='<%# Eval("product_id") %>' OnCommand="ImageButton1_Command"  />
                <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("product_name") %>' Font-Size="Large" ForeColor="Black" CommandArgument='<%# Eval("product_id") %>' OnCommand="LinkButton1_Command" ></asp:LinkButton>
                <br />
                <asp:Label ID="productprice" runat="server" Text='<%# "₹ "+ Eval("price") %>' Font-Size="Medium" ForeColor="#666666"></asp:Label>
            </div>
            </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
