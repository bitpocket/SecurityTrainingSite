using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Opole.Misc;

namespace Opole
{
    public partial class SiteMaster : MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            HeadLoginView.Controls.Clear();
            if (!AuthenticationService.IsUserAuthenticated())
            {
                HeadLoginView.AnonymousTemplate.InstantiateIn(HeadLoginView);
            }
            else
            {
                HeadLoginView.LoggedInTemplate.InstantiateIn(HeadLoginView);
                ShowWelcomeMessage();
            }
        }

        protected void LogoutLinkButton_Click(object sender, EventArgs e)
        {
            
        }

        protected void HeadLoginStatus_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            
        }

        protected void LogOutButton_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Abandon();
            Response.Redirect(Request.RawUrl);
        }

        protected void LogOutButton_Command(object sender, CommandEventArgs e)
        {

        }

        private void ShowWelcomeMessage()
        {
            string userName = HttpContext.Current.Session["UserName"].ToString();
            var label = (Label) HeadLoginView.FindControl("WelcomeLabel");

            if (label != null)
            {
                label.Text = string.Format("{0} {1}!", "Welcome", userName);
            }
        }
	}
}
