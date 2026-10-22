<%@ Page Title="checkout" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="MainProject1.checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .checkout-section {
            width: 90%;
            margin: 150px auto 80px;
        }
        .checkout-header {
            margin-bottom: 40px;
            justify-content:center;
        }
        .checkout-header h1 {
            font-size: 38px;
            margin-bottom: 15px;
        }
        .checkout-container {
            display: flex;
            gap: 50px;
            align-items: flex-start;
        }
        .shipping-section {
            width: 55%;
        }

        .shipping-section h2 {
            font-size: 18px;
            margin-bottom: 25px;
        }

        .address-section {
            margin-top: 20px;
            padding: 25px;
            border: 1px solid #e5e5e5;
        }

        .address-section h3 {
            margin-bottom: 20px;
        }

        .address-label {
            display: block;
            font-size: 16px;
            color: #555;
            line-height: 1.6;
        }

        .edit-details {
            margin-top: 20px;
            padding: 25px;
            border: 1px solid #e5e5e5;
        }

        .input-field {
            margin-bottom: 18px;
        }

        .input-field label {
            display: block;
            font-size: 14px;
            font-weight: bold;
            margin-bottom: 7px;
        }

        .input-field input,
        .input-field textarea {
            width: 100%;
            padding: 12px;
            border: 1px solid #ccc;
            box-sizing: border-box;
            font-size: 15px;
        }

        .input-field textarea {
            resize: none;
        }
        .order-summary {
            width: 45%;
            border: 1px solid #e2e2e2;
            padding: 30px;
            box-sizing: border-box;
        }

        .order-summary h2 {
            font-size: 24px;
            margin-bottom: 25px;
        }
        .review-table {
            width: 100%;
            border-collapse: collapse;
        }

        .review-table th {
            padding: 12px 8px;
            text-align: left;
            font-size: 13px;
            color: #777;
            border-bottom: 1px solid #ddd;
        }

        .review-table td {
            padding: 15px 8px;
            font-size: 14px;
            border-bottom: 1px solid #eee;
        }
        .summary-line {
            display: flex;
            justify-content: space-between;
            padding: 18px 0;
            border-bottom: 1px solid #eee;
            font-size: 15px;
        }

        .total-line {
            font-size: 20px;
            padding-top: 20px;
            border-bottom: none;
        }
        .payment-button {
            width: 100%;
            padding: 15px;
            margin-top: 15px;
            background-color: sandybrown;
            color: white;
            border: 1px solid sandybrown;
            cursor: pointer;
            font-size: 18px;
        }

        .payment-button:hover {
            background-color: white;
            color: sandybrown;
        }

        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="checkout-section">
    <div class="checkout-header">
        <h1>Review Order</h1>
        <div class="checkout-container">

        <div class="shipping-section">
            <h3> Delivering to <asp:Label ID="CustomerNameLabel" runat="server"></asp:Label></h3>

            <div class="address-section">
                <h3>Shipping Address</h3>
                <asp:Label ID="AddressLabel" runat="server"></asp:Label>
                <br /><br />

            <asp:Button ID="AddAddressbtn" runat="server" Text="+ ADD ADDRESS" OnClick="AddAddressbtn_Click" />
            </div>

            <div id="addAddressPanel" runat="server" visible="false" class="edit-details">
                <div class="input-field">
                    <label>Address</label>
                    <asp:TextBox ID="AddressTextBox" runat="server"></asp:TextBox>
  
                    <label>City</label>
                    <asp:TextBox ID="CityTextBox" runat="server"></asp:TextBox>
                
                    <label>District</label>
                    <asp:TextBox ID="DistrictTextBox" runat="server"></asp:TextBox>
           
                    <label>PIN</label>
                    <asp:TextBox ID="PinTextBox" runat="server"></asp:TextBox>
                </div>

            <asp:Button ID="SaveAddressbtn" runat="server" Text="SAVE" OnClick="SaveAddressbtn_Click"  />
            </div>


            <div class="phone-section">
                <b>Phone Number</b>
                <asp:Label ID="PhoneLabel"  runat="server"></asp:Label>
                <asp:Button ID="EditPhoneButton" runat="server" Text="EDIT" OnClick="EditPhoneButton_Click"  />
            </div>

            <div id="editPhonePanel" runat="server" visible="false" class="edit-details">
                <div class="input-field">
                    <label>Phone Number: </label>
                    <asp:TextBox ID="PhoneTextBox" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="PhoneTextBox" ErrorMessage="Enter valid phone number" ValidationExpression="^[6789]\d{9}$"></asp:RegularExpressionValidator>
                </div>
                <asp:Button ID="SavePhoneBtn" runat="server" Text="SAVE" OnClick="SavePhoneBtn_Click"  />
           </div>
</div>

        <div class="order-summary">
            <h2>Order Summary</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="review-table" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="product_name" HeaderText="Product" />
                    <asp:BoundField DataField="price" HeaderText="Price" />
                    <asp:BoundField DataField="size" HeaderText="Size" />
                    <asp:BoundField DataField="quantity" HeaderText="Qty" />
                    <asp:BoundField DataField="subtotal" HeaderText="Subtotal" />
                </Columns>
            </asp:GridView>

            <div class="summary-line">
                <span>Subtotal</span>
                <span> ₹<asp:Label ID="TotalAmount"  runat="server"></asp:Label></span>
            </div>

            <div class="summary-line total-line">
                <b>Total</b>
                <b>
                    ₹<asp:Label ID="FinalTotal" runat="server"></asp:Label>
                </b>
            </div>

            <asp:Button ID="Payment" runat="server"   Text="Confirm and Pay→" CssClass="payment-button" OnClick="Payment_Click" />
        </div>
    </div>
</div>
</div>
</asp:Content>
