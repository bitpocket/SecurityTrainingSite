using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

namespace Opole
{
    public partial class Display : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            string dest = "Display.aspx?show=" + Encoder.UrlEncode(Encoder.HtmlEncode(tbGet.Text));
            Response.Redirect(dest);
        }
    }
}