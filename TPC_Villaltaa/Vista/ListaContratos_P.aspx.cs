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
    public partial class ListaContratos_P : System.Web.UI.Page
    {
        public List<Contrato> ListaContratoP { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ContratoBLL contratoBLL = new ContratoBLL();
            ProfesionalBLL profesionalBLL = new ProfesionalBLL();

            string mailProfesional = Session["Usuario"].ToString();
            int idProfesional = profesionalBLL.obtenerIdProfesional(mailProfesional);
            
            ListaContratoP = contratoBLL.ListarContratoxIdProfesional(idProfesional);
        }
    }
}
