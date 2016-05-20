using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

namespace Opole
{
    public partial class DropDown2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            this.lblRecent.Text = Encoder.HtmlEncode(SqlHelper.LastChosenPet());
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string pet = Request.Params["ctl00$MainContent$list"].ToString();
            valueLabel.Text = pet;
            SqlHelper.StoreChosenPet(pet, Request.Params["ctl00$MainContent$tbName"]);
        }
    }
}