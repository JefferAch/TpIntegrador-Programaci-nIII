using Clinica;
using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class ABMLPaciente : System.Web.UI.Page
    {
        ClinicaUsuario clinica = new ClinicaUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarTablaPaciente();
            }
        }

        private void cargarTablaPaciente()
        {
            string nombreUsuario = Session["Nombre"].ToString();
            lbl_Usuario.Text = nombreUsuario;
            DataTable tablaTurnos = clinica.mostrarTablaPaciente();
            gvPacientes.DataSource = tablaTurnos;
            gvPacientes.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AgregarPaciente.aspx");
        }

        protected void gvPacientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPacientes.EditIndex = -1;
            cargarTablaPaciente();
        }

        protected void gvPacientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPacientes.EditIndex = e.NewEditIndex;
            cargarTablaPaciente();

            string provinciaPaciente = gvPacientes.DataKeys[e.NewEditIndex]["Id_Provincia"].ToString();
            string localidadPaciente = gvPacientes.DataKeys[e.NewEditIndex]["Id_Localidad"].ToString();

            DropDownList ddlProvincia = (DropDownList)gvPacientes.Rows[e.NewEditIndex].FindControl("ddlProvinciaEdit");

            DaoClinica dao = new DaoClinica();

            ddlProvincia.DataSource = dao.getProvincias();
            ddlProvincia.DataTextField = "Nombre_Provincia";
            ddlProvincia.DataValueField = "Id_Provincia";
            ddlProvincia.DataBind();

            ddlProvincia.SelectedValue = provinciaPaciente;

            DropDownList ddlLocalidad = (DropDownList)gvPacientes.Rows[e.NewEditIndex].FindControl("ddlLocalidadEdit");

            ddlLocalidad.DataSource = dao.getLocalidades(int.Parse(provinciaPaciente));
            ddlLocalidad.DataTextField = "Nombre_Localidad";
            ddlLocalidad.DataValueField = "Id_Localidad";
            ddlLocalidad.DataBind();

            ddlLocalidad.SelectedValue = localidadPaciente;
        }

        protected void gvPacientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label lblDni = (Label)gvPacientes.Rows[e.RowIndex].FindControl("lblDniEdit");
            string Estado = ((Label)gvPacientes.Rows[e.RowIndex].FindControl("lb_it_Estado")).Text;
            bool estado = bool.Parse(Estado);
            string dni = lblDni.Text;

            TextBox txtNombre = (TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txt1");
            TextBox txtApellido = (TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txt2");
            TextBox txtTelefono = (TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txt6");
            TextBox txtEmail = (TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txt4");
            TextBox txtDireccion = (TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txt5");
            TextBox txtSexo = (TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txt3");
            TextBox txtNacionalidad = (TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txt7");
            string txtFechaNacimiento = ((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txt_eit_Birthdate")).Text;
            int localidad = int.Parse(((DropDownList)gvPacientes.Rows[e.RowIndex].FindControl("ddlLocalidadEdit")).SelectedValue);
            int provincia = int.Parse(((DropDownList)gvPacientes.Rows[e.RowIndex].FindControl("ddlProvinciaEdit")).SelectedValue);

            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string telefono = txtTelefono.Text;
            string email = txtEmail.Text;
            string direccion = txtDireccion.Text;
            string sexo = txtSexo.Text;
            string nacionalidad = txtNacionalidad.Text;


            Paciente paciente = new Paciente(dni, nombre, apellido, Convert.ToChar(sexo), nacionalidad, Convert.ToDateTime(txtFechaNacimiento), direccion, telefono, email, localidad, provincia, estado);
            clinica.actualizarPaciente(paciente);
            gvPacientes.EditIndex = -1;
            cargarTablaPaciente();
            lblMensaje.Text = "Paciente actualizado correctamente.";
            lblMensaje.ForeColor = System.Drawing.Color.Green;
        }

        protected void gvPacientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string eliminarPaciente = ((Label)gvPacientes.Rows[e.RowIndex].FindControl("lb_it_DNI")).Text;

            clinica.eliminarPaciente(Convert.ToInt32(eliminarPaciente));

            cargarTablaPaciente();
        }

        protected void gvPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPacientes.PageIndex = e.NewPageIndex;
            cargarTablaPaciente();
        }


        protected void ddlProvinciaEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlProvincia = (DropDownList)sender;
            DropDownList ddlLocalidad = (DropDownList)ddlProvincia.NamingContainer.FindControl("ddlLocalidadEdit");

            DaoClinica dao = new DaoClinica();
            int idProvincia = int.Parse(ddlProvincia.SelectedValue);

            ddlLocalidad.DataSource = dao.getLocalidades(idProvincia);
            ddlLocalidad.DataTextField = "Nombre_Localidad";
            ddlLocalidad.DataValueField = "Id_Localidad";
            ddlLocalidad.DataBind();

            ddlLocalidad.Items.Insert(0, new ListItem("Seleccione una localidad", "0"));
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            txtboxBuscar.Text = "";
            cargar();
        }
        protected void cargar()
        {
            {
                string filtrarBuscar = txtboxBuscar.Text.Trim();
                int quefiltrar = int.Parse((ddlFiltroPacientes.SelectedValue.ToString()));
                int comoOrdenar = int.Parse((ddlOrdenarPacientes.SelectedValue.ToString()));
                DataTable tabla = clinica.FiltrarPacientes(filtrarBuscar, quefiltrar, comoOrdenar);

                gvPacientes.DataSource = tabla;
                gvPacientes.DataBind();
            }
        }

        protected void gvPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            cargar();
        }
    }
}