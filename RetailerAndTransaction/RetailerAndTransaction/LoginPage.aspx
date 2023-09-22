<%@ Page  Title="" Language="C#"  MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="RetailerAndTransaction.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Login.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="login">
        <div class="login-form">
            <div class="login-form-elements">
                <h2>LOGIN FORM</h2>
                <asp:Label runat="server">Email :</asp:Label>
                <asp:TextBox ID="txtEmail"  runat="server" AutoPostBack="True" TextMode="Email"></asp:TextBox>
                <asp:Label runat="server">Password :</asp:Label>
                <asp:TextBox ID="txtPassword"  runat="server" AutoPostBack="False" TextMode="Password"></asp:TextBox>
                <asp:Button ID="btnLogIn" runat="server" Text="LogIn" class="custom-button" OnClick="LoginButtonClickHandler"/>
            </div>
        </div>
    </div>
</asp:Content>
