using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Opole.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (Opole.SqlHelper.CredentialsCorrect(UserNameTextBox.Text, PasswordTextBox.Text))
                {
                    {
                        Response.Cookies["UserName"].Value = UserNameTextBox.Text;
                        Response.Cookies["UserName"].Expires = DateTime.Now.AddMinutes(30);
                    }
                }
            }
        }
    }
}