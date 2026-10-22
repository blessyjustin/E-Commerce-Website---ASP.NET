<%@ Page Title="Payment" Language="C#" MasterPageFile="~/Site1.Master"  AutoEventWireup="true" CodeBehind="payment.aspx.cs" Inherits="MainProject1.payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .payment-section {
            width: 500px;
            margin: 150px auto 80px;
        }

        .payment-section h1 {
            text-align: center;
            margin-bottom: 30px;
        }

        .payment-box {
            border: 1px solid #ddd;
            padding: 30px;
        }

        .payment-box h2 {
            margin-bottom: 25px;
        }

        .amount {
            font-size: 20px;
            margin-bottom: 25px;
        }

        .account-details {
            margin-bottom: 25px;
        }

        .account-details p {
            margin: 12px 0;
        }

        .input-field {
            margin-bottom: 20px;
        }

        .input-field label {
            display: block;
            font-weight: bold;
            margin-bottom: 8px;
        }

        .input-field input {
            width: 100%;
            padding: 12px;
            border: 1px solid #ccc;
            box-sizing: border-box;
        }

        .pay-button {
            width: 100%;
            padding: 14px;
            background-color: sandybrown;
            color: white;
            border: 1px solid sandybrown;
            cursor: pointer;
            font-size: 16px;
        }

        .pay-button:hover {
            background-color: white;
            color: sandybrown;
        }

        .message {
            display: block;
            margin-top: 20px;
            text-align: center;
            font-weight: bold;
        }
    </style>

</asp:Content>


<asp:Content ID="Content2"  ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="payment-section">
        <h1>Payment</h1>
        <div class="payment-box">
            <div class="amount">
                Amount: ₹<asp:Label ID="AmountLabel" runat="server"></asp:Label>
            </div>
            <div id="Account" runat="server" visible="true">
                <div class="input-field">
                    <label>Account Number</label>
                    <asp:TextBox ID="AccountNumberTextBox" runat="server"></asp:TextBox>
                    <label>Account Holder Name</label>
                    <asp:TextBox ID="AccountHolderTextBox" runat="server"></asp:TextBox>
                    <label>Initial Balance</label>
                    <asp:TextBox ID="BalanceTextBox" runat="server"></asp:TextBox>
                </div>
            </div>


            <asp:Button ID="PayButton" runat="server" Text="PAY NOW" CssClass="pay-button" OnClick="PayButton_Click" />

            <asp:Label ID="MessageLabel" runat="server" CssClass="message"></asp:Label>

        </div>

    </div>

</asp:Content>