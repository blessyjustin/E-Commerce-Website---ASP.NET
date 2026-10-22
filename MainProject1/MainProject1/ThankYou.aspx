<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ThankYou.aspx.cs" Inherits="MainProject1.ThankYou" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .thankyou {
            text-align: center;
            padding: 100px 20px;
        }

        .thankyou h1 {
            font-size: 40px;
            margin-bottom: 20px;
        }

        .thankyou h3 {
            font-weight: normal;
            margin-bottom: 30px;
        }

        .thankyou a {
            text-decoration: none;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="thankyou">

        <h1>Thank You!</h1>

        <h3>Your payment was successful.</h3>

        <p>Your order has been placed successfully.</p>

        <br />

        <asp:Button ID="HomeButton" runat="server"
            Text="Continue Shopping"
            PostBackUrl="~/HomePage.aspx" />

    </div>

</asp:Content>