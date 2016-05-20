<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="Display.aspx.cs" Inherits="Opole.Display" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% Response.Write(Request.Params["data1"]); %><br />
<% Response.Write(Request.QueryString["show"]); %>
<asp:Label ID="lblDisplay" runat="server" /> <br /> <br />
<asp:Label ID="Label1" runat="server" Text="What should I display?" /> <br />

    <form id="frmData" method="post" action="Display.aspx" >
        <input type="text" name="data1" id="data1"  />
        <asp:Button ID="btnSubmit" runat="server" Text="POST" />
    </form><br />

    <asp:TextBox ID="tbGet" runat="server" />
    <asp:Button ID="btnGet" runat="server" Text="GET" OnClick="btnGet_Click" />

</asp:Content>
