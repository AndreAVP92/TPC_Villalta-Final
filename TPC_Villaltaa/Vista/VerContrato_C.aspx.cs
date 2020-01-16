using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;
using Controlador;

namespace Vista
{
    public partial class VerContrato_C : System.Web.UI.Page
    {
        public Contrato contrato { get; set; }
        private Contrato ccc = null;
        ContratoBLL contratoBLL = new ContratoBLL();
        ClienteBLL clienteBLL = new ClienteBLL();
        ProfesionalBLL profesionalBLL = new ProfesionalBLL();
        EstadoContratoBLL estadoContratoBLL = new EstadoContratoBLL();
        RubroBLL rubroBLL = new RubroBLL();
        PagoBLL pagoBLL = new PagoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                    List<Contrato> listarContrato;
                    listarContrato = contratoBLL.listarContrato();
                    Int32 contratoSeleccionado = Convert.ToInt32(Request.QueryString["idcontrato"]);
                    contrato = listarContrato.Find(Pc => Pc.IdContrato == contratoSeleccionado);

                    TextBoxIDContrato.Text = contrato.IdContrato.ToString();
                    TextBoxCliente.Text = clienteBLL.obtenerNombreCliente(contrato.Cliente.IdCliente).ToString();
                    TextBoxProfesional.Text = profesionalBLL.obtenerNombreProfesional(contrato.Profesional.IdProfesional).ToString();
                    TextBoxCuit.Text = profesionalBLL.obtenerCuit(contrato.Profesional.IdProfesional).ToString();
                    TextBoxRubro.Text = rubroBLL.obtenerNombreRubro(contrato.Profesional.Rubro.IdRubro).ToString();
                    TextBoxPago.Text = pagoBLL.obtenerNombrePago(contrato.Pago.IdPago).ToString();
                    TextBoxDescripcion.Text = contrato.Descripcion;
                    TextBoxDireccion.Text = contrato.Direccion;
                    TextBoxImporte.Text = contrato.Importe.ToString();
                    TextBoxEstadoContrato.Text = estadoContratoBLL.obtenerNombreEstadoContrato(contrato.EstadoContrato.IdEstadoContrato).ToString();
                    if (TextBoxEstadoContrato.Text == "Cancelado")
                    {
                        ButtonCancelar.Visible = false;
                        ButtonConfirmar.Visible = false;
                    }
                    else if (TextBoxEstadoContrato.Text == "Reparando") {
                        ButtonCancelar.Visible = false;
                        ButtonConfirmar.Visible = false;
                    }
                    else if(TextBoxEstadoContrato.Text == "Finalizado")
                    {
                        ButtonCancelar.Visible = false;
                        ButtonConfirmar.Visible = false;
                        ButtonValorar.Visible = true;
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }          

        protected void ButtonConfirmar_Click(object sender, EventArgs e)
        {
            ButtonConfirmar.Visible = false;
            ButtonCancelar.Visible = false;
            
            if (ccc == null)
            {
                ccc = new Contrato();               
                ccc.IdContrato = Convert.ToInt32(TextBoxIDContrato.Text);
                
                ccc.EstadoContrato = new EstadoContrato();
                ccc.EstadoContrato.IdEstadoContrato = estadoContratoBLL.obtenerIdEstadoContrato("Confirmado");

                if (ccc.IdContrato != 0)
                {
                    if (TextBoxEstadoContrato.Text != "Finalizado") 
                    {
                        contratoBLL.actualizarEstadoContrato(ccc);
                    }
                    else if(TextBoxEstadoContrato.Text == "Finalizado")
                    {
                        Label1.Visible = true;
                        TextBoxValoracion.Visible = true;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Importe inválido');window.location ='VerContrato_C.aspx';", true);
                }
            }
            Response.Redirect("ListaContratos_C.aspx");
        }

        protected void ButtonValorar_Click(object sender, EventArgs e)
        {
            ProfesionalBLL profesionalBLL = new ProfesionalBLL();
            //if(TextBoxEstadoContrato.Text == "Finalizado")
            //{
            //    Label1.Visible = true;
            //    TextBoxValoracion.Visible = true;             
            //}
            profesionalBLL.ValoracionP(Convert.ToDecimal(TextBoxValoracion.Text));
            Response.Redirect("ListaContratos_C.aspx");
        }

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
           
            if (ccc == null)
            {
                ccc = new Contrato();
                ccc.IdContrato = Convert.ToInt32(TextBoxIDContrato.Text);

                if (ccc.IdContrato != 0)
                {
                    ccc.EstadoContrato = new EstadoContrato();
                    ccc.EstadoContrato.IdEstadoContrato = estadoContratoBLL.obtenerIdEstadoContrato("Cancelado");
                    contratoBLL.actualizarEstadoContrato(ccc);

                    ButtonCancelar.Visible = false;
                    ButtonConfirmar.Visible = false;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No se pudo cancelar');window.location ='VerContrato_C.aspx';", true);
                }
                Response.Redirect("ListaContratos_C.aspx");
            }
            
        }
    }
}