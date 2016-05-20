using System;
using Opole.Misc;

namespace Opole
{
    public partial class CSRF1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSubmit.Click += btnSubmit_Click;
        }

        void btnSubmit_Click(object sender, EventArgs e)
        {
            lblWarning.Visible = false;

            if (AuthenticationService.IsUserAuthenticated())
            {
                if (!string.IsNullOrEmpty(text.Text))
                {
                    SqlHelper.AddComment(text.Text);
                    Response.Redirect("ViewComments.aspx?msg=New comment added.");
                }
            }
            else
            {
                lblWarning.Visible = true;
            }
        }
    }
}