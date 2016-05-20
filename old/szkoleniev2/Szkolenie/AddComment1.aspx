<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddComment1.aspx.cs" EnableViewState="true" Inherits="Opole.AddComment1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Label ID="lblMsg" runat="server" />

<form method="post" action="CSRF2.aspx">
    <input type="text" name="comment" />
    <input type="submit" value="Submit" />
</form><br />

</asp:Content>
