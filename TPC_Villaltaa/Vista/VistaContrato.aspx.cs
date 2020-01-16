using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//using System.Net;
//using System.Net.Mail;

using Controlador;
using Modelo;


namespace Vista
{
    public partial class VistaContrato : System.Web.UI.Page
    {
        public Profesional profesional { get; set; }
        public Cliente cliente { get; set; }

        ContratoBLL contratoBLL = new ContratoBLL();
        ClienteBLL clienteBLL = new ClienteBLL();
        ProfesionalBLL profesionalBLL = new ProfesionalBLL();
        EstadoContratoBLL estadoContratoBLL = new EstadoContratoBLL();
        RubroBLL rubroBLL = new RubroBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            string RubroElegido = Request.QueryString["rubro"];
            TextBoxRubro.Text = RubroElegido;

            try
            {
                List<Profesional> listaProfesionales;
                listaProfesionales = profesionalBLL.listarProfesional();
                Int32 clienteQueSolicita = Convert.ToInt32(Session["IdCliente"]);


                Int32 profesionalSeleccionado = Convert.ToInt32(Request.QueryString["idprofesional"]);
                profesional = listaProfesionales.Find(P => P.IdProfesional == profesionalSeleccionado);

                TextBoxProfesional.Text = profesional.ToString();
                TextBoxCliente.Text = clienteBLL.obtenerNombreCliente(clienteQueSolicita);
                TextBoxCuit.Text = profesional.CuitCuil.ToString();

                TextBoxEstadoContrato.Text = "";

                if (!IsPostBack)
                {
                    listarModosdePago(); //DropDownListPago             
                }
            }
            catch (Exception ex)
            {
                Session["Error" + Session.SessionID] = ex;
                Response.Redirect("Error.aspx");
            }
        }

        //void listarDatosxDefault()
        //{
        //    List<Profesional> listaProfesionales;
        //    listaProfesionales = profesionalBLL.listarProfesional();

        //    Int32 clienteQueSolicita = Convert.ToInt32(Session["IdCliente"]);

        //    string  RubroElegido = Request.QueryString["rubro"];
        //    Int32 profesionalSeleccionado = Convert.ToInt32(Request.QueryString["idprofesional"]);
        //    profesional = listaProfesionales.Find(P => P.IdProfesional == profesionalSeleccionado);
        //    listarModosdePago();
        //    TextBoxProfesional.Text = profesional.ToString();
        //    TextBoxCliente.Text = clienteBLL.obtenerNombreCliente(clienteQueSolicita);
        //    TextBoxCuit.Text = profesional.CuitCuil.ToString();
        //    TextBoxRubro.Text = RubroElegido;
        //    //TextBoxImporte.Text = "";
        //    TextBoxEstadoContrato.Text = "";
        //}

        void listarModosdePago()
        {
            PagoBLL pagoBLL = new PagoBLL();
            DropDownListPago.DataSource = pagoBLL.listarPago();
            DropDownListPago.DataValueField = "IdPago";
            DropDownListPago.DataTextField = "DescripcionP";
            DropDownListPago.DataBind();
        }

        protected void ButtonEnviarSolicitud_Click(object sender, EventArgs e)
        {
            //RubroBLL rubroBLL = new RubroBLL();
            Contrato contrato = new Contrato();
            contrato.Direccion = TextBoxDireccion.Text;
            contrato.Descripcion = TextBoxDescripcion.Text;
            contrato.Importe = 0;
            contrato.Estado = true;
            contrato.FechaContrato = DateTime.Now;

            contrato.Cliente = new Cliente();
            contrato.Cliente.IdCliente = clienteBLL.obtenerIdCliente(Session["MailCliente"].ToString()); //obtengo el ID desde el mail del cliente

            contrato.Profesional = new Profesional();
            contrato.Profesional.IdProfesional = Convert.ToInt32(profesionalBLL.obtenerIdProfesionalxCuit(Convert.ToInt64(TextBoxCuit.Text))); //obtengo el ID desde el cuit del profesional

            contrato.Profesional.Rubro = new Rubro();
            contrato.Profesional.Rubro.IdRubro = rubroBLL.obtenerIdRubro(TextBoxRubro.Text); //obtengo el ID desde la descripcion Rubro

            contrato.Pago = new Pago();
            contrato.Pago.IdPago = Convert.ToInt32(DropDownListPago.SelectedValue.ToString());

            contrato.EstadoContrato = new EstadoContrato();
            TextBoxEstadoContrato.Text = "En Revisión";
            contrato.EstadoContrato.IdEstadoContrato = estadoContratoBLL.obtenerIdEstadoContrato(TextBoxEstadoContrato.Text);

            contratoBLL.agregarContrato(contrato);
        }

        //Intentemos avisar al profesional por whatsapp de la nueva solicitud

        //public void enviarWhatsapp ()
        //{
        //    ProfesionalBLL profesionalBLL = new ProfesionalBLL();
        //    string mail = profesionalBLL.obtenerMailProfesional(Convert.ToInt64(TextBoxCuit.Text));
        //    try
        //    {
        //        MailMessage msj = new MailMessage();
        //        msj.From = new MailAddress(mail);
        //        msj.To.Add()
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //En ella, guardo el registro solicitud en la base de datos con Estado = "En Revision"
        //Y esperar a que el profesional actualice (con Update) el importe
        //Despues el cliente acepta ("En camino") ó rechaza la solicitud ("Cancelado")
        //Si terminó el trabajo, el profesional actualiza la solicitud en Estado = "Terminado"
    }       
}
