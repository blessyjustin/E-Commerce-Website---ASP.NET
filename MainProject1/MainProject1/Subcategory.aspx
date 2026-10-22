<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Subcategory.aspx.cs"
    Inherits="MainProject1.Subcategory"
    MasterPageFile="~/Admin.Master" %>

<asp:Content
    ID="Content1"
    ContentPlaceHolderID="ContentPlaceHolder1"
    runat="server">

    <div class="admin-page">

        <h1>Add Subcategory.</h1>

        <p>
            Create a new subcategory for your Novara Store.
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
                    CssClass="admin-input">

                </asp:DropDownList>

            </div>


           

            <div class="admin-form-group">

                <asp:Label
                    ID="Label2"
                    runat="server"
                    Text="Subcategory Name">
                </asp:Label>

                <asp:TextBox
                    ID="TextBox1"
                    runat="server"
                    CssClass="admin-input">
                </asp:TextBox>

            </div>


            

            <asp:Button
                ID="Button1"
                runat="server"
                Text="ADD SUBCATEGORY"
                CssClass="admin-button" OnClick="Button1_Click1" />


           

            <asp:Label
                ID="Label3"
                runat="server"
                Visible="False"
                CssClass="admin-message"></asp:Label>

        </div>

    </div>
    <div class="admin-card category-management">

    <h2>View and Manage Subcategories</h2>

    <div class="category-table-wrapper">

        <asp:GridView
            ID="GridView1"
            runat="server"
            AutoGenerateColumns="False"
            CssClass="admin-grid subcategory-grid"
            GridLines="None"
            DataKeyNames="subcategory_id" OnRowCancelingEdit="GridView1_RowCancelingEdit" 
            OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
            

            <Columns>

                <asp:BoundField
                    DataField="subcategory_id"
                    HeaderText="SUB ID"
                    ReadOnly="True" />

                <asp:BoundField 
                    DataField="category_name" 
                    HeaderText="CATEGORY"
                    ReadOnly="True"/>

                <asp:BoundField
                    DataField="subcategory_name"
                    HeaderText="SUBCATEGORY" />

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