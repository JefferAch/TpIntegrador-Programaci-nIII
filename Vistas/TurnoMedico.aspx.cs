
using Clinica;
using Datos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class WebClinica : System.Web.UI.Page
    {
        private readonly ClinicaUsuario clinica = new ClinicaUsuario();
        private readonly ConexionClinica conexion = new ConexionClinica();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Nombre"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            lblUsuario.Text = Session["Nombre"].ToString();

            if (!IsPostBack)
            {
                
            }
        }


        private void ActualizarTurno(int idTurno, int estado, string observaciones)
        {
            clinica.ActualizarTurno(idTurno, estado, observaciones);
        }



        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int idTurno = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            DropDownList ddlEstado = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlEstadoEdit");
            TextBox txtObs = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtObservacionEdit");

            int estado = int.Parse(ddlEstado.SelectedValue);
            string observaciones = txtObs.Text?.Trim() ?? "";

            ActualizarTurno(idTurno, estado, observaciones);

            GridView1.EditIndex = -1;
            
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
          
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;

            Label lblEstado = (Label)e.Row.FindControl("lb_it_Estado");
            Label lblObs = (Label)e.Row.FindControl("lb_it_Observacion");

            int estadoDb = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Estado_Turno"));

            object obsObj = DataBinder.Eval(e.Row.DataItem, "Observaciones");
            string obsDb = (obsObj == DBNull.Value) ? "" : obsObj.ToString();

            string estadoTexto;
            switch (estadoDb)
            {
                case 0: estadoTexto = "Pendiente"; break;
                case 1: estadoTexto = "Presente"; break;
                case 2: estadoTexto = "Ausente"; break;
                default: estadoTexto = "Desconocido"; break;
            }

            if (lblEstado != null) lblEstado.Text = estadoTexto;
            if (lblObs != null) lblObs.Text = obsDb;

            if ((e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
            {
                DropDownList ddlEstado = (DropDownList)e.Row.FindControl("ddlEstadoEdit");
                TextBox txtObs = (TextBox)e.Row.FindControl("txtObservacionEdit");

                if (ddlEstado != null) ddlEstado.SelectedValue = estadoDb.ToString();
                if (txtObs != null) txtObs.Text = obsDb;
            }
        }

        protected void btnInformeAsistencias_Click(object sender, EventArgs e)
        {
            Response.Redirect("InformeAsistencias.aspx");
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = "";
            ddlFiltro.SelectedIndex = 0; 
            
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
          
            if (ddlMedicos.SelectedValue == "0" || string.IsNullOrEmpty(ddlMedicos.SelectedValue))
            {
               
                GridView1.DataSource = null;
                GridView1.DataBind();
                return;
            }

            int legajo = int.Parse(ddlMedicos.SelectedValue);
            int criterio = int.Parse(ddlFiltro.SelectedValue);
            string texto = txtFiltro.Text.Trim(); 

           
            DataTable dt = clinica.FiltrarYOrdenarTurnos(legajo, criterio, texto);

           
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}