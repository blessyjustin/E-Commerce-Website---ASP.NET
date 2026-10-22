<%@ Page Title="Login" Language="C#" MasterPageFile="~/Simple.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MainProject1.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="login-container">

        <div class="login-card">

            <h2>Welcome Back</h2>

            <p>Login to continue shopping</p>


            <div class="form-group">

                <asp:Label
                    ID="Label1"
                    runat="server"
                    Text="Username">
                </asp:Label>

                <asp:TextBox
                    ID="TextBox1"
                    runat="server">
                </asp:TextBox>

                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1"
                    runat="server"
                    ControlToValidate="TextBox1"
                    ErrorMessage="Username is required"
                    ForeColor="Red"
                    >
                </asp:RequiredFieldValidator>

            </div>


            <div class="form-group">

                <asp:Label
                    ID="Label2"
                    runat="server"
                    Text="Password">
                </asp:Label>

                <asp:TextBox
                    ID="TextBox2"
                    runat="server"
                    TextMode="Password">
                </asp:TextBox>

                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2"
                    runat="server"
                    ControlToValidate="TextBox2"
                    ErrorMessage="Password is required"
                    ForeColor="Red">
                   
                </asp:RequiredFieldValidator>

            </div>


            <asp:Button
                ID="Button1"
                runat="server"
                Text="Login"
                CssClass="login-button" OnClick="Button1_Click"/>


            <asp:Label
                ID="Label3"
                runat="server"
                Visible="False"
                CssClass="login-error">
            </asp:Label>


            <div class="register-link">

                Don't have an account?
                <a href="UserReg.aspx">Create an account</a>

            </div>

        </div>

    </div>

</asp:Content>