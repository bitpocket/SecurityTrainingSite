using System;
using System.Web.UI;
using Opole.Misc;

namespace Opole
{
    public partial class AddComment1 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthenticationService.IsUserAuthenticated())
            {
                var msg = Request.QueryString["comment"];
                if (string.IsNullOrEmpty(msg))
                {
                    lblMsg.Text = "No comment was specified";
                }
                else
                {
                    SqlHelper.AddComment(msg);
                    Response.Redirect("ViewComments.aspx?msg=Thanks you for adding a comment");
                }
            }
            else
            {
                lblMsg.Text = "You need to be logged in to submit comments.";
            }
        }
    }
}