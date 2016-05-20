using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Opole
{
    public partial class Links : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Display();
        }

        protected void btnSend_Click(Object sender, EventArgs e)
        {
            //SqlHelper.InsertLink(HttpUtility.HtmlEncode(tbLink.Text));
            SqlHelper.InsertLink(tbLink.Text);
            Display();
        }

        protected void Display()
        {
            DataSet ds = SqlHelper.GetLinks();
            rPolecone.DataSource = ds;
            rPolecone.DataBind();
        }
    }
}