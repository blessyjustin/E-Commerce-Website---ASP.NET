<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="Product.aspx.cs"
    Inherits="MainProject1.Product"
    MasterPageFile="~/Admin.Master" %>

<asp:Content
    ID="Content1"
    ContentPlaceHolderID="ContentPlaceHolder1"
    runat="server">

    <div class="admin-page">

        <h1>Add Product.</h1>

        <p>
            Add a new product to your Novara Store.
        </p>

        <div class="admin-form-card">

            

            <div class="admin-form-group">

                <asp:Label
                    ID="Label1"
                    runat="server"
                    Text="Select Category">
                </asp:Label>

                <asp:DropDownList
                    ID="DropDownList1"
                    runat="server"
                    CssClass="admin-input"
                    AutoPostBack="true"
                    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>

            </div>


            

            <div class="admin-form-group">

                <asp:Label
                    ID="Label2"
                    runat="server"
                    Text="Select Subcategory">
                </asp:Label>

                <asp:DropDownList
                    ID="DropDownList2"
                    runat="server"
                    CssClass="admin-input">
                </asp:DropDownList>

            </div>


            

            <div class="admin-form-group">

                <asp:Label
                    ID="Label3"
                    runat="server"
                    Text="Product Name">
                </asp:Label>

                <asp:TextBox
                    ID="TextBox1"
                    runat="server"
                    CssClass="admin-input"
                    >
                </asp:TextBox>

            </div>


            

            <div class="admin-form-group">

                <asp:Label
                    ID="Label4"
                    runat="server"
                    Text="Price">
                </asp:Label>

                <asp:TextBox
                    ID="TextBox2"
                    runat="server"
                    CssClass="admin-input"
                    >
                </asp:TextBox>

            </div>


            

            <div class="admin-form-group">

                <asp:Label
                    ID="Label5"
                    runat="server"
                    Text="Stock">
                </asp:Label>

                <asp:TextBox
                    ID="TextBox3"
                    runat="server"
                    CssClass="admin-input"
                    >
                </asp:TextBox>

            </div>


            

            <div class="admin-form-group">

                <asp:Label
                    ID="Label6"
                    runat="server"
                    Text="Product Description">
                </asp:Label>

                <asp:TextBox
                    ID="TextBox4"
                    runat="server"
                    CssClass="admin-input"
                    TextMode="MultiLine"
                    >
                </asp:TextBox>

            </div>


            

            <div class="admin-form-group">

                <asp:Label
                    ID="Label7"
                    runat="server"
                    Text="Product Image">
                </asp:Label>

                <asp:FileUpload
                    ID="FileUpload1"
                    runat="server"
                    CssClass="admin-file">
                </asp:FileUpload>

            </div>


            

            <asp:Button
                ID="Button1"
                runat="server"
                Text="ADD PRODUCT"
                CssClass="admin-button"
                OnClick="Button1_Click" />


           

            <asp:Label
                ID="Label8"
                runat="server"
                Visible="False"
                CssClass="admin-message">
            </asp:Label>

        </div>

    </div>
    <div class="admin-card category-management">

    <h2>View and Manage Products</h2>

    <div class="category-table-wrapper">

        <asp:GridView
            ID="GridView1"
            runat="server"
            AutoGenerateColumns="False"
            CssClass="admin-grid"
            GridLines="None"
            DataKeyNames="product_id" OnRowCancelingEdit="GridView1_RowCancelingEdit" 
            OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" 
            OnRowUpdating="GridView1_RowUpdating" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging">

            <Columns>

                <asp:BoundField
                    DataField="product_id"
                    HeaderText="PROD ID"
                    ReadOnly="True" />

                <asp:BoundField 
                    DataField="category_name" 
                    HeaderText="CATEGORY"
                    ReadOnly="True"/>

                <asp:BoundField 
                    DataField="subcategory_name" 
                    HeaderText="SUBCATEGORY"
                    ReadOnly="True"/>

                <asp:BoundField
                    DataField="product_name"
                    HeaderText="PRODUCT NAME" />

                <asp:BoundField
                    DataField="price"
                    HeaderText="PRICE" />

                <asp:BoundField
                    DataField="stock"
                    HeaderText="STOCK" />

                <asp:BoundField
                    DataField="description"
                    HeaderText="DESCRIPTION" />

                <asp:TemplateField HeaderText="IMAGE">

                    <ItemTemplate>

                        <asp:Image
                            ID="Image1"
                            runat="server"
                            ImageUrl='<%# Eval("image") %>'
                            CssClass="category-grid-image" />

                    </ItemTemplate>

                    <EditItemTemplate>

                        <asp:Image
                            ID="Image2"
                            runat="server"
                            ImageUrl='<%# Eval("image") %>'
                            CssClass="category-grid-image" />

                        <br />

                        <asp:FileUpload
                            ID="FileUpload2"
                            runat="server" />

                    </EditItemTemplate>

                </asp:TemplateField>

                <asp:CommandField
                    ShowEditButton="True"
                    ShowDeleteButton="True"
                    HeaderText="ACTION"
                    ButtonType="Link" />

            </Columns>

        </asp:GridView>

    </div>

</div>

</asp:Content>