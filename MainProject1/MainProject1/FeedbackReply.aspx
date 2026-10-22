<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="FeedbackReply.aspx.cs" Inherits="MainProject1.FeedbackReply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="admin-page">
    <h2>Reply to Customer</h2>
    <div class="admin-form-card">
    <div class="admin-form-group">
    <asp:Label ID="NameLabel" runat="server" Text="Customer Name : "></asp:Label>
    <asp:Label ID="CustomerNameLabel" runat="server"></asp:Label>
    </div>
    <div class="admin-form-group">
    <asp:Label ID="EmailLabel" runat="server" Text="Customer Email : "></asp:Label>
    <asp:Label ID="CustomerEmailLabel" runat="server"></asp:Label>
    </div>
    <div class="admin-form-group">
    <asp:Label ID="FeedbackLabel" runat="server" Text="Customer Feedback : "></asp:Label>
    <asp:Label ID="CustomerFeedbackLabel" runat="server"></asp:Label>
    </div>
    <div class="admin-form-group">
    <asp:Label ID="ReplyLabel" runat="server" Text="Your Reply :"></asp:Label>
    <asp:TextBox ID="ReplyTextBox" runat="server" TextMode="MultiLine" Rows="6"></asp:TextBox>
    </div>

    <asp:Button ID="SendReplyButton" runat="server" Text="Send Reply"  CssClass="admin-button" OnClick="SendReplyButton_Click" />

    <asp:Label ID="MessageLabel" runat="server" CssClass="admin-message"></asp:Label>
    </div>

</asp:Content>