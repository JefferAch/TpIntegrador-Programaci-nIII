using Clinica;
using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Vistas
{
    public partial class ABMLMedicos : System.Web.UI.Page
    {
        ClinicaUsuario clinica = new ClinicaUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl.Text = Session["Nombre"].ToString();
            if (!IsPostBack)
            {
                cargarTablaMedicos();
            }
        }

        private void cargarTablaMedicos()
        {
            DataTable tablaMedico = clinica.mostrarTablaMedico();
            gvMedicos.DataSource = tablaMedico;
            gvMedicos.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            txtboxBuscar.Text = "";
            cargar();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            cargar();
        }
        protected void cargar()
        {
            {
                string filtrarBuscar = txtboxBuscar.Text.Trim();
                int quefiltrar = int.Parse((ddlFiltroMedicos.SelectedValue.ToString()));
                int comoOrdenar = int.Parse((ddlOrdenarMedicos.SelectedValue.ToString()));
                DataTable tabla = clinica.FiltrarMedicos(filtrarBuscar, quefiltrar, comoOrdenar);

                gvMedicos.DataSource = tabla;
                gvMedicos.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarMedico.aspx");
        }

        protected void gvMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvMedicos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string eliminarMedico = ((Label)gvMedicos.Rows[e.RowIndex].FindControl("lb_it_Leg")).Text;

            clinica.eliminarMedico(Convert.ToInt32(eliminarMedico));

            cargarTablaMedicos();
        }

        protected void gvMedicos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string legajo = ((Label)gvMedicos.Rows[e.RowIndex].FindControl("lb_it_Leg")).Text;
            string nombre = ((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txt_eit_Nombre")).Text;
            string apellido = ((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txt_eit_Apellido")).Text;
            string correo = ((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txt_eit_Correo")).Text;
            string telefono = ((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txt_eit_Telefono")).Text;
            string especialidad = ((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txt_eit_Especialidad")).Text;
            string diasAtencion = ((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txt_eit_Dias_dis")).Text;
            string horario = ((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txt_eit_Horario")).Text;
            string dni = ((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txt_eit_DNI")).Text;
            string sexo = ((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txt_eit_Sexo")).Text;
            string nacionalidad = ((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txt_eit_Nacionalidad")).Text;
            string nacimiento = ((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txt_eit_Birthdate")).Text;
            string direccion = ((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txt_eit_Direccion")).Text;

            string[] horarioPartes = horario.Split('-');
            string horInicio = horarioPartes[0].Trim();
            string horFinal = horarioPartes[1].Trim();
            TimeSpan horarioInicio = TimeSpan.Parse(horInicio);
            TimeSpan horarioFinal = TimeSpan.Parse(horFinal);

            Medico medico = new Medico(Convert.ToInt32(legajo), nombre, apellido, correo, telefono, horarioInicio, horarioFinal, Convert.ToInt32(dni), Convert.ToChar(sexo), nacionalidad, Convert.ToDateTime(nacimiento), direccion);

            DaoClinica dao = new DaoClinica();
            dao.ActualizarMedico(medico);
            gvMedicos.EditIndex = -1;
            cargarTablaMedicos();
        }

        protected void gvMedicos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMedicos.EditIndex = e.NewEditIndex;
            cargarTablaMedicos();
        }

        protected void gvMedicos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMedicos.EditIndex = -1;
            cargarTablaMedicos();
        }

        protected void gvMedicos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMedicos.PageIndex = e.NewPageIndex;
            if (string.IsNullOrWhiteSpace(txtboxBuscar.Text))
            {
                cargarTablaMedicos();
            }
            else
            {
                cargar();
            }
        }
    }
}