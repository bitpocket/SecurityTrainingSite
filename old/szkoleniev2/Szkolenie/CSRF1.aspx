<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableViewState="true" EnableEventValidation="false" CodeBehind="CSRF1.aspx.cs" Inherits="Opole.CSRF1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
Submit comment:<br />

<asp:TextBox ID="text" runat="server" />
<asp:Button ID="btnSubmit" Text="Submit" runat="server" />

<br />
<asp:Label ID="lblWarning" runat="server" Text="You need to be authorised!" Visible="false" ForeColor="Red" />
</asp:Content>
