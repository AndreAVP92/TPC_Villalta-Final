using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;
using Controlador;
using System.Data.SqlClient;

namespace Vista
{
    public partial class ABM_Rubro : System.Web.UI.Page
    {
        Rubro rubro = new Rubro();  
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                AddListaRubro();
        }
        
        void AddListaRubro()
        {   
            RubroBLL rubroBLL = new RubroBLL();

            tablaRubros.DataSource = rubroBLL.listarRubros();
            tablaRubros.DataBind();
        }

        //protected void GetContadorRubros()
        //{
        //    RubroBLL rubroBLL = new RubroBLL();
        //    TextContador.Text = rubroBLL.ContarRubros();
        //}

        protected void ButtonAltaRubro_Click(object sender, EventArgs e)
        {
            RubroBLL rubroBLL = new RubroBLL();

            try
            {
                rubro = new Rubro();

                rubro.DescripcionR = InputDescripcion.Text;
                rubro.Estado = true;

                rubroBLL.agregarRubro(rubro);

                AddListaRubro();
            }
            catch (Exception ex)
            {
                throw ex;
            }     
        }

        protected void Cancelar(object sender, GridViewCancelEditEventArgs e)
        {
            tablaRubros.EditIndex = -1;
            AddListaRubro();
        }

        protected void Eliminar(object sender, GridViewDeleteEventArgs e)
        {
            RubroBLL rubroBLL = new RubroBLL();
            
            int id = Convert.ToInt32(tablaRubros.DataKeys[e.RowIndex].Values[0]);

            rubroBLL.eliminarRubro(id);

            tablaRubros.EditIndex = -1;
            AddListaRubro();
        }

        protected void Editar(object sender, GridViewEditEventArgs e)
        {
            tablaRubros.EditIndex = e.NewEditIndex;

            AddListaRubro();
        }

        protected void Actualizar(object sender, GridViewUpdateEventArgs e)
        {
            ConexionBD datos = new ConexionBD();
            try
            {
                string consulta = "UPDATE RUBRO SET Descripcion_R=@Descripcion, Estado=@Estado Where IdRubro= @Id";
                datos.conexion.Open();
                SqlCommand cmd = new SqlCommand(consulta, datos.conexion);
                cmd.Parameters.AddWithValue("@Descripcion", (tablaRubros.Rows[e.RowIndex].FindControl("TextBoxDescripcion") as TextBox).Text.Trim());
                cmd.Parameters.AddWithValue("@Estado", Convert.ToBoolean(tablaRubros.Rows[e.RowIndex].FindControl("CheckBoxEstado") as CheckBox));

                cmd.ExecuteNonQuery();
                
                tablaRubros.EditIndex = -1;
                AddListaRubro();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }      
    }
}