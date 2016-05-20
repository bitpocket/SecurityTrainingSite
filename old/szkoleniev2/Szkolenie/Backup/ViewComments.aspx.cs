using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Opole
{
    public partial class ViewComments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.gv1.DataSource = SqlHelper.GetComments();
            this.DataBind();
        }
    }
}