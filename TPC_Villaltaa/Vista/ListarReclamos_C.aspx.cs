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
    public partial class ListarReclamos_C : System.Web.UI.Page
    {
        public List<Reclamo> ListaReclamoC { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ReclamoBLL reclamoBLL = new ReclamoBLL();
            ClienteBLL clienteBLL = new ClienteBLL();

            string mailCliente = Session["Usuario"].ToString();
            int idCliente = clienteBLL.obtenerIdCliente(mailCliente);

            ListaReclamoC = reclamoBLL.listarReclamosxIdCliente(idCliente);
        }

        protected void ButtonAltaPago_Click(object sender, EventArgs e)
        {

        }
    }
}