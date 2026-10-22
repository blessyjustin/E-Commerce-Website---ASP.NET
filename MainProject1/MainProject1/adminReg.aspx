<%@ Page Title="Admin Registration" Language="C#" MasterPageFile="~/Simple.master" AutoEventWireup="true" CodeBehind="adminReg.aspx.cs" Inherits="MainProject1.adminReg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="register-container">

        <div class="register-card">

            <h2>Admin Registration</h2>
            <p>Set up your Novara Store administrator account</p>

            <div class="form-group">

                <asp:Label ID="Label1" 
                    runat="server" 
                    Text="Name"> </asp:Label>

                <asp:TextBox 
                    ID="TextBox1" 
                    runat="server"> </asp:TextBox>

                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1"
                    runat="server"
                    ControlToValidate="TextBox1"
                    ErrorMessage="Name is required"
                    ForeColor="Red">
                    
                </asp:RequiredFieldValidator>

            </div>


           

            <div class="form-group">

                <asp:Label
                    ID="Label2"
                    runat="server"
                    Text="Email">
                </asp:Label>

                <asp:TextBox
                    ID="TextBox2"
                    runat="server">
                </asp:TextBox>

                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2"
                    runat="server"
                    ControlToValidate="TextBox2"
                    ErrorMessage="Email is required"
                    ForeColor="Red">
                    
                </asp:RequiredFieldValidator>

                <asp:RegularExpressionValidator
                    ID="RegularExpressionValidator1"
                    runat="server"
                    ControlToValidate="TextBox2"
                    ErrorMessage="Enter a valid email address"
                    ForeColor="Red"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

            </div>



            <div class="form-group">

                <asp:Label
                    ID="Label3"
                    runat="server"
                    Text="Username">
                </asp:Label>

                <asp:TextBox
                    ID="TextBox3"
                    runat="server"
                    AutoPostBack="true"
                    OnTextChanged="TextBox3_TextChanged">
                </asp:TextBox>

                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator3"
                    runat="server"
                    ControlToValidate="TextBox3"
                    ErrorMessage="Username is required"
                    ForeColor="Red">
                    
                </asp:RequiredFieldValidator>

                <asp:Label
                    ID="Label5"
                    runat="server"
                    Visible="False"
                    CssClass="error-message">
                </asp:Label>

            </div>


           

            <div class="form-group">

                <asp:Label
                    ID="Label4"
                    runat="server"
                    Text="Password">
                </asp:Label>

                <asp:TextBox
                    ID="TextBox4"
                    runat="server"
                    TextMode="Password">
                </asp:TextBox>

                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator4"
                    runat="server"
                    ControlToValidate="TextBox4"
                    ErrorMessage="Password is required"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>


            </div>



            <asp:Button
                ID="Button1"
                runat="server"
                Text="REGISTER"
                CssClass="register-button"
                OnClick="Button1_Click" />


            

            <asp:Label
                ID="Label6"
                runat="server"
                Visible="False"
                CssClass="success-message">
            </asp:Label>



            <div class="login-link">

                Already have an admin account?
                <a href="Login.aspx">Login</a>

            </div>

        </div>

    </div>

</asp:Content>