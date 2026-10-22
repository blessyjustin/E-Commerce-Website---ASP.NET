<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminFeedback.aspx.cs" Inherits="MainProject1.AdminFeedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="admin-card category-management">
    <h2>Customer Feedback</h2>

   <div class="category-table-wrapper">

   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="admin-grid" DataKeyNames="feedback_id" OnRowCommand="GridView1_RowCommand">
        <Columns>

            <asp:BoundField DataField="user_name" HeaderText="Name" />

            <asp:BoundField DataField="user_email" HeaderText="Email" />

            <asp:BoundField DataField="feedback" HeaderText="Feedback" />

            <asp:BoundField DataField="feedback_date" HeaderText="Date" />

            <asp:ButtonField ButtonType="Button" Text="Reply" CommandName="Reply" HeaderText="Action" />

        </Columns>

    </asp:GridView>
    </div>
  </div>

</asp:Content>
