
using Clinica;
using Datos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
// Asegurate de tener los using correctos para tu capa de negocio/entidades

namespace Vistas
{
    public partial class WebClinica : System.Web.UI.Page
    {
        private readonly ClinicaUsuario clinica = new ClinicaUsuario();
        // private readonly ConexionClinica conexion = new ConexionClinica(); // No parece usarse aquí directamente

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
                // 1. CARGA INICIAL
                // Es fundamental cargar el DropDown de Médicos aquí la primera vez
                CargarMedicos();

                // Opcional: Si quieres que la grilla aparezca vacía al inicio, no llames a CargarTabla aquí.
                // Si quieres que muestre todo, llámalo.
                // CargarTabla(); 
            }
        }

        // Método auxiliar para llenar el combo de médicos (Asumo que tienes un método para esto)
        private void CargarMedicos()
        {
            // Ejemplo:
            // ddlMedicos.DataSource = clinica.ObtenerMedicos(); // Tu método para traer médicos
            // ddlMedicos.DataTextField = "Apellido_Nombre";
            // ddlMedicos.DataValueField = "Legajo_Medico";
            // ddlMedicos.DataBind();
            // ddlMedicos.Items.Insert(0, new ListItem("Seleccione un médico", "0"));
        }

        // 2. MÉTODO CENTRALIZADO PARA RECARGAR LA GRILLA
        // Este método lee los filtros actuales y recarga la tabla.
        private void CargarTabla()
        {
            // Validacion básica: Si no hay médico seleccionado y es requerido, limpiamos la grilla
            if (ddlMedicos.SelectedValue == "0" || string.IsNullOrEmpty(ddlMedicos.SelectedValue))
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                return;
            }

            try
            {
                int legajo = int.Parse(ddlMedicos.SelectedValue);
                int criterio = int.Parse(ddlFiltro.SelectedValue);
                string texto = txtFiltro.Text.Trim();

                // Reutilizamos tu lógica de negocio
                DataTable dt = clinica.FiltrarYOrdenarTurnos(legajo, criterio, texto);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                // Manejo de errores (opcional: mostrar en un label)
                // lblError.Text = "Error al cargar tabla: " + ex.Message;
            }
        }

        private void ActualizarTurno(int idTurno, int estado, string observaciones)
        {
            clinica.ActualizarTurno(idTurno, estado, observaciones);
        }

        // --- EVENTOS DEL GRIDVIEW ---

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            // IMPORTANTE: Recargar la tabla para que se muestre el modo edición
            CargarTabla();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            // IMPORTANTE: Recargar la tabla para volver al modo lectura
            CargarTabla();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // 1. Obtener ID
            int idTurno = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            // 2. Obtener Controles
            DropDownList ddlEstado = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlEstadoEdit");
            TextBox txtObs = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtObservacionEdit");

            // 3. Extraer Valores
            int estado = int.Parse(ddlEstado.SelectedValue);
            string observaciones = txtObs.Text?.Trim() ?? "";

            // 4. Actualizar en BD
            ActualizarTurno(idTurno, estado, observaciones);

            // 5. Salir del modo edición
            GridView1.EditIndex = -1;

            // 6. ¡CRUCIAL! Recargar datos frescos de la BD
            CargarTabla();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            // IMPORTANTE: Recargar la tabla para mostrar la nueva página
            CargarTabla();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;

            // Lógica de visualización (Labels)
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

            // Lógica de Edición (Dropdowns y TextBoxes)
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                DropDownList ddlEstado = (DropDownList)e.Row.FindControl("ddlEstadoEdit");
                TextBox txtObs = (TextBox)e.Row.FindControl("txtObservacionEdit");

                if (ddlEstado != null) ddlEstado.SelectedValue = estadoDb.ToString();
                if (txtObs != null) txtObs.Text = obsDb;
            }
        }

        // --- BOTONES ---

        protected void btnInformeAsistencias_Click(object sender, EventArgs e)
        {
            Response.Redirect("InformeAsistencias.aspx");
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            // Limpiamos filtros visuales
            txtFiltro.Text = "";
            ddlFiltro.SelectedIndex = 0;

            // Aquí deberías decidir: ¿Mostrar todos los de UN médico o todos los de la clínica?
            // Si es todos los de la clínica, necesitas lógica extra en CargarTabla o cambiar el SelectedValue del médico.

            CargarTabla();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            // Ahora este botón simplemente llama al método centralizado
            GridView1.PageIndex = 0; // Resetear a la página 1 al filtrar
            CargarTabla();
        }
    }
}