using System;
using Opole.Misc;

namespace Opole
{
    public partial class ViewComments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HideCommentsForNotAuthenticatedUser();

            if (AuthenticationService.IsUserAuthenticated())
            {
                DisplayMessageFromUrlParameter();
                gv1.DataSource = SqlHelper.GetComments();
            }

            DataBind();
        }

        private void HideCommentsForNotAuthenticatedUser()
        {
            gv1.Visible = AuthenticationService.IsUserAuthenticated();
            NoCommentVisibleMessage.Visible = !AuthenticationService.IsUserAuthenticated();
        }

        private void DisplayMessageFromUrlParameter()
        {
            string message = Request.QueryString["msg"];
            CommentAddedMessage.Text = message;
        }
    }
}