<%@ Page Title="Categories"
    Language="C#"
    MasterPageFile="~/Admin.Master"
    AutoEventWireup="true"
    CodeBehind="Category.aspx.cs"
    Inherits="MainProject1.Category" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="ContentPlaceHolder1"
    runat="server">

    <div class="admin-page">

        <h1>Categories</h1>

        <p>Add a new product category.</p>


        <div class="admin-form-card">

            

            <div class="admin-form-group">

                <asp:Label
                    ID="Label1"
                    runat="server"
                    Text="Category Name">
                </asp:Label>

                <asp:TextBox
                    ID="TextBox1"
                    runat="server">
                </asp:TextBox>

            </div>


            

            <div class="admin-form-group">

                <asp:Label
                    ID="Label2"
                    runat="server"
                    Text="Category Image">
                </asp:Label>

                <asp:FileUpload
                    ID="FileUpload1"
                    runat="server" />

            </div>


            

            <asp:Button
                ID="Button1"
                runat="server"
                Text="ADD CATEGORY"
                CssClass="admin-button"
                OnClick="Button1_Click" />


           

            <asp:Label
                ID="Label3"
                runat="server"
                Visible="False"
                CssClass="admin-message">
            </asp:Label>

        </div>

    </div>
    <div class="admin-card category-management">

    <h2>View and Manage Categories</h2>

    <div class="category-table-wrapper">

        <asp:GridView
            ID="GridView1"
            runat="server"
            AutoGenerateColumns="False"
            CssClass="admin-grid"
            GridLines="None" OnRowCancelingEdit="GridView1_RowCancelingEdit" 
            OnRowDeleting="GridView1_RowDeleting" 
            OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" 
            DataKeyNames="category_id">

            <Columns>

                <asp:BoundField
                    DataField="category_id"
                    HeaderText="ID"
                    ReadOnly="True" />

                <asp:BoundField
                    DataField="category_name"
                    HeaderText="CATEGORY NAME" />

                <asp:TemplateField HeaderText="IMAGE">
                    <EditItemTemplate>
                        <asp:Image ID="Image2" runat="server"  ImageUrl='<%# Eval("image") %>'  />
                        <br />
                        <asp:FileUpload ID="FileUpload2" runat="server" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("image") %>' />
                    </ItemTemplate>
                    <ControlStyle CssClass="category-grid-image" />
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