<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="true" AutoEventWireup="true" CodeBehind="Private1.aspx.cs" Inherits="Opole.Private1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="tbAnimal" runat="server" Width="400" />
    <asp:Button ID="btnSubmit" runat="server" Text="Show names for that animal" /><br /><br />
    <asp:GridView ID="gv1" runat="server"></asp:GridView>
</asp:Content>
