<%@ Page Title="Admin Home"
    Language="C#"
    MasterPageFile="~/Admin.Master"
    AutoEventWireup="true"
    CodeBehind="adminHome.aspx.cs"
    Inherits="MainProject1.adminHome" %>


<asp:Content
    ID="Content1"
    ContentPlaceHolderID="ContentPlaceHolder1"
    runat="server">


    <div class="admin-page">

    <h1>Welcome back.</h1>

    <p>
        Manage your Novara Store from here.
    </p>

    <div class="admin-actions">

        <h2>Quick Actions</h2>

        <div class="admin-action-buttons">

            <a href="Category.aspx">
                ADD CATEGORY
            </a>

            <a href="Subcategory.aspx">
                ADD SUBCATEGORY
            </a>

            <a href="Product.aspx">
                ADD PRODUCT
            </a>

        </div>

    </div>

</div>

    


</asp:Content>