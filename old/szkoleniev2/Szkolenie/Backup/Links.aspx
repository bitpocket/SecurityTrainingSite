<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" ValidateRequest="true" AutoEventWireup="true" CodeBehind="Links.aspx.cs" Inherits="Opole.Links" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<asp:TextBox ID="tbLink" runat="server" width="400" /><br />
<asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Text="Recommend!" />
<br /> <br />

<asp:Repeater ID="rPolecone" runat="server">
    <HeaderTemplate>
             <table border="1">
                <tr>
                   <td><b>Recommended links</b></td>
                </tr>
			
          </HeaderTemplate>
    <ItemTemplate>
         <tr>
            <td> <%# string.Format("<a href=\"{0}\" >{0}</a>", DataBinder.Eval(Container.DataItem, "link")) %> </td>
            <!--<td> <%# string.Format("<a href=\"{0}\" />", DataBinder.Eval(Container.DataItem, "link")) %> </td>-->

            </tr>
    </ItemTemplate>
	<FooterTemplate>
		</table>
	</FooterTemplate>
</asp:Repeater>

</asp:Content>
