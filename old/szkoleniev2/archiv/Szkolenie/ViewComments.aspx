<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewComments.aspx.cs" Inherits="Opole.ViewComments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="NoCommentVisibleMessage" runat="server">You must be logged in to view comments.</asp:Panel>
    <asp:Label ID="CommentAddedMessage" runat="server"></asp:Label>
    <asp:GridView ID="gv1" runat="server"></asp:GridView>
</asp:Content>
