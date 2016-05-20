using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Opole
{
	public partial class SiteMaster : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            HeadLoginView.Controls.Clear();
            if (!Request.Cookies.AllKeys.Contains("UserName"))
            {
                HeadLoginView.AnonymousTemplate.InstantiateIn(HeadLoginView);
            }
            else
            {
                HeadLoginView.LoggedInTemplate.InstantiateIn(HeadLoginView);
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
            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect(Request.RawUrl);
        }

        protected void LogOutButton_Command(object sender, CommandEventArgs e)
        {

        }
	}
}
