using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Vista
{
    public partial class Site2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                LinkButtonLogin.Text = Session["Usuario"].ToString();
                LinkButtonSignIn.Visible = false;
                LinkButtonSignUp.Visible = false;
            }               
        }
    }
}