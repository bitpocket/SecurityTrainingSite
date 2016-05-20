using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Security.Application;

namespace Opole
{
    public partial class PetsChosen2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.gv1.RowDataBound += new GridViewRowEventHandler(gv1_RowDataBound);
            DataSet dataSet = SqlHelper.GetChosenPets();
            this.gv1.DataSource = dataSet;

            this.DataBind();
        }

        protected void gv1_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            foreach (TableCell cell in e.Row.Cells)
            {
                cell.Text = Encoder.HtmlEncode(cell.Text);
            }
        }
    }
}