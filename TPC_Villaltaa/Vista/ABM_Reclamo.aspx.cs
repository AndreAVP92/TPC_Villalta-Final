using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controlador;
using Modelo;

namespace Vista
{
    public partial class ABM_Reclamo : System.Web.UI.Page
    {
        public List<Reclamo> ListaReclamos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    mostrar();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void mostrar()
        {
            ReclamoBLL reclamoBLL = new ReclamoBLL();

            ListaReclamos = reclamoBLL.listarReclamos();
        }
    }
}