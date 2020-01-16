using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class SiteMaster : MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            LinkButtonPago.Visible = false;
            LinkButtonRubro.Visible = false;
            LinkButtonSubRubro.Visible = false;
            LinkButtonEstadoContrato.Visible = false;
            LinkButtonReclamo.Visible = false;

            if (Session["Usuario"] != null)
            {            
                LinkButtonAdmin.Text = Session["Usuario"].ToString();
                LinkButtonPago.Visible = true;
                LinkButtonRubro.Visible = true;
                LinkButtonSubRubro.Visible = true;
                LinkButtonEstadoContrato.Visible = true;
                LinkButtonReclamo.Visible = true;
            }
        }
    }
}

