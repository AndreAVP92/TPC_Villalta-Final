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
    public partial class ABM_SubRubro : System.Web.UI.Page
    {
        //Rubro rubro = new Rubro();
        SubRubro subRubro = new SubRubro();
        SubRubroBLL subRubroBLL = new SubRubroBLL();

        protected void Page_Load(object sender, EventArgs e)
        {                    
            if (!IsPostBack)
            {
                mostrarRubros();
                AddListaSubRubro();                
            }   
        }
        void mostrarRubros()
        {
            RubroBLL rubroBLL = new RubroBLL();

            DropDownListRubros.DataSource = rubroBLL.listarRubros();
            DropDownListRubros.DataValueField = "IdRubro";
            DropDownListRubros.DataTextField = "DescripcionR";
            DropDownListRubros.DataBind();
        }

        void AddListaSubRubro()
        {
            SubRubroBLL subrubroBLL = new SubRubroBLL();

            tablaSubRubros.DataSource = subrubroBLL.listarSubRubros();
            tablaSubRubros.DataBind();
        }

        public void asignarRubroxSubRubro(Int32 idRubro, Int32 idSubRubro)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                datos.setearQuery("INSERT INTO SUBRUBROxRUBRO (IdRubro_SRR, IdSubRubro_SRR) VALUES (@IdRubro_SRR, @IdSubRubro_SRR)");
                
                datos.agregarParametro("@IdRubro_SRR", idRubro);
                datos.agregarParametro("@IdSubRubro_SRR", idSubRubro);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        protected void ButtonAddSubRubro_Click(object sender, EventArgs e)
        {
            ConexionBD datos = new ConexionBD();
            try
            {
                RubroBLL rubroBLL = new RubroBLL();

                int idRubro = Convert.ToInt32(DropDownListRubros.SelectedValue);

                subRubro.DescripcionSR = InputDescripcion.Text;
                subRubro.Estado = true;                               

                if (subRubroBLL.agregarSubRubro(subRubro))
                {
                    Int32 idSubRubro = subRubroBLL.obtenerUltimoIdSubRubro();
                    asignarRubroxSubRubro(idRubro, idSubRubro);

                    AddListaSubRubro();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        protected void tablaSubRubros_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SubRubroBLL subrubroBLL = new SubRubroBLL();
      
            int idSR = Convert.ToInt32(tablaSubRubros.DataKeys[e.RowIndex].Values[0]);
            subrubroBLL.desvincularSubRubro(idSR);
            //subrubroBLL.eliminarSubRubro(id); 
            //faltaría eliminar la tabla intermedia
            //Metodo que desvincule el id SubRubro del Rubro
            subrubroBLL.eliminarSubRubro(idSR);

            tablaSubRubros.EditIndex = -1;
            AddListaSubRubro();
        }

        protected void tablaSubRubros_RowEditing(object sender, GridViewEditEventArgs e)
        {
            SubRubroBLL subrubroBLL = new SubRubroBLL();

            tablaSubRubros.EditIndex = Convert.ToInt16(e.NewEditIndex);
            //HiddenField1.Value = e.NewEditIndex.ToString();
            tablaSubRubros.DataSource = subrubroBLL.listarSubRubros();
            tablaSubRubros.DataBind();
        }

        protected void tablaSubRubros_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            SubRubroBLL subrubroBLL = new SubRubroBLL();

            tablaSubRubros.EditIndex = -1;

            tablaSubRubros.DataSource = subrubroBLL.listarSubRubros();
            tablaSubRubros.DataBind();
        }

        protected void tablaSubRubros_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SubRubroBLL subrubroBLL = new SubRubroBLL();
            SubRubro subrubro = new SubRubro();
            //TextBox text = tablaSubRubros.Rows[e.RowIndex].Cells[1].Controls[0] as TextBox;
            //int id = Convert.ToInt32(tablaSubRubros.DataKeys[e.RowIndex].Values[0]);
            //string desc = text.Text;
            subrubroBLL.editarSubRubro(subrubro);

            tablaSubRubros.EditIndex = -1;
            tablaSubRubros.DataSource = subrubroBLL.listarSubRubros();
            tablaSubRubros.DataBind();
        }
    }
}