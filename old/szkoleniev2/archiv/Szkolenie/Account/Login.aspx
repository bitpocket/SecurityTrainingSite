<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Opole.Account.Login"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel runat="server" DefaultButton="LoginLinkButton">
        <asp:Label ID="UserNameLabel" runat="server" Text="UserName:"></asp:Label>
        <asp:TextBox ID="UserNameTextBox" runat="server" width="400"></asp:TextBox>
        <br />
        <asp:Label ID="PasswordLabel" runat="server" Text="Password:"></asp:Label>
        <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" width="400"></asp:TextBox>
        <br />
        <asp:LinkButton ID="LoginLinkButton" runat="server">Login</asp:LinkButton>
    </asp:Panel>
    
    <div class="login-error-message">
        <asp:Label ID="LoginResultLabel" runat="server"></asp:Label>
    </div>
</asp:Content>
