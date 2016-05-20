<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DropDown2.aspx.cs" Inherits="Opole.DropDown2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<form>
Choose your favourite pet:<br />
<asp:DropDownList ID="list" runat="server">
	<asp:ListItem Text="Dog" Value="Dog" />
	<asp:ListItem Text="Cat" Value="Cat" />
	<asp:ListItem Text="Frog" Value="Frog" />
</asp:DropDownList>
Name: <asp:TextBox ID="tbName" runat="server" width="400" />
<asp:Button ID="Button1" type="btnSubmit"  runat="server" Text="Choose" value="Submit" OnClick="btnSubmit_Click" />
</form>

<asp:Label ID="valueLabel" runat="server" />

    <br /><br />
    <asp:Button ID="btnShow" runat="server" Text="Show last one" OnClick="btnShow_Click" />
    <asp:Label ID="lblRecent" runat="server" />
</asp:Content>
