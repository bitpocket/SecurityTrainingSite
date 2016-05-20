using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Opole
{
    public partial class CSRF2 : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            ViewStateUserKey = Session.SessionID;
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            btnSubmit.Click += new EventHandler(btnSubmit_Click);
        }

        void btnSubmit_Click(object sender, EventArgs e)
        {
            this.lblWarning.Visible = false;
            
            if (Request.Cookies.AllKeys.Contains("UserName"))
            {
                if (!string.IsNullOrEmpty(text.Text))
                {
                    SqlHelper.AddComment(text.Text);
                }
            }
            else
            {
                this.lblWarning.Visible = true;
            }
        }
    }
}