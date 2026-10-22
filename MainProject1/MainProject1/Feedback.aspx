<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="MainProject1.Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .feedback-container {
    width: 500px;
    margin: 60px auto;
    padding: 30px;
}

.feedback-container h2 {
    text-align: center;
}

.feedback-container p {
    text-align: center;
    margin-bottom: 30px;
}

.feedback-container input[type="text"],
.feedback-container textarea {
    width: 100%;
    padding: 10px;
    margin-top: 5px;
    box-sizing: border-box;
}

.feedback-container textarea {
    resize: none;
}

.feedback-container input[type="submit"] {
    padding: 10px 20px;
    cursor: pointer;
}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="feedback-container">

    <h2>Send Us Your Feedback</h2>

    <p>We would love to hear from you.</p>

    <asp:Label ID="NameLabel" runat="server" Text="Name"></asp:Label>
    <br />
    <asp:TextBox ID="NameTextBox" runat="server"
        placeholder="Enter your name"></asp:TextBox>

    <br /><br />

    <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
    <br />
    <asp:TextBox ID="EmailTextBox" runat="server"
        placeholder="Enter your email"></asp:TextBox>

    <br /><br />

    <asp:Label ID="FeedbackLabel" runat="server" Text="Feedback"></asp:Label>
    <br />
    <asp:TextBox ID="FeedbackTextBox" runat="server"
        TextMode="MultiLine"
        Rows="5"
        placeholder="Write your feedback..."></asp:TextBox>

    <br /><br />

    <asp:Button ID="SubmitButton" runat="server"
        Text="Submit Feedback"
        OnClick="SubmitButton_Click" />

    <br /><br />

    <asp:Label ID="MessageLabel" runat="server"></asp:Label>

</div>

</asp:Content>
