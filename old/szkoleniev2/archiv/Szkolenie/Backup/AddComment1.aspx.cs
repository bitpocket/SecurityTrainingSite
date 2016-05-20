using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Opole
{
    public partial class AddComment1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies.AllKeys.Contains("UserName"))
            {
                string msg = this.Request.QueryString["comment"];
                if (string.IsNullOrEmpty(msg))
                {
                    this.lblMsg.Text = "No comment was specified";
                }
                else
                {
                    SqlHelper.AddComment(msg);
                    this.lblMsg.Text = "Thank you for your comment";
                }
            }
            else
            {
                this.lblMsg.Text = "You need to be logged in to submit comments.";
            }
        }
    }
}