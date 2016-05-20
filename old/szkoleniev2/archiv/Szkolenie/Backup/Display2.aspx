<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="Display2.aspx.cs" Inherits="Opole.Display2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Response.Write(Microsoft.Security.Application.Encoder.HtmlEncode(Request.Params["data1"])); %><br />
<% Response.Write(Microsoft.Security.Application.Encoder.HtmlEncode(Request.QueryString["show"])); %>
<br /> <br />
<asp:Label ID="Label1" runat="server" Text="What should I display?" /> <br />

    <form id="frmData" method="post" action="Display.aspx" >
        <input type="text" name="data1" id="data1"  />
        <asp:Button ID="btnSubmit" runat="server" Text="POST" />
    </form><br />

    <asp:TextBox ID="tbGet" runat="server" />
    <asp:Button ID="btnGet" runat="server" Text="GET" OnClick="btnGet_Click" />


</asp:Content>
