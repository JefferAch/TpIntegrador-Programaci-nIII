using Entidades;
using Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clinica;

namespace Vistas
{
    public partial class AgregarMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarProvincias();
                CargarEspecialidades();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lblExito.Visible = false;
            DaoClinica checkeoDatos = new DaoClinica();
            
            trimTextos();
            
            if (!Page.IsValid || revisarStringsVacios())
            {
                lblErrorVacios.Visible = true;
                return;
            }

            lblErrorVacios.Visible = false;
            Medico nuevoMed = new Medico();



            Usuario nuevoUser = new Usuario();

            nuevoUser.name = txtUserMedico.Text.Trim();

            nuevoUser.password = txtContraMedico.Text.Trim();
            nuevoUser.tipoUsuario = '1';

            if (checkeoDatos.ExisteUsuario(txtUserMedico.Text.Trim()))
            {
                lblErrorVacios.Text = "Ya existe un usuario con ese nombre.";
                lblErrorVacios.Visible = true;
                return;
            }

            int IdUsuario = checkeoDatos.AgregarUsuario(nuevoUser);



            nuevoMed.LegajoMedico = int.Parse(txtLegajo.Text.Trim());
            nuevoMed.DniMedico = int.Parse(txtDni.Text.Trim());
            nuevoMed.NombreMedico = txtNombre.Text.Trim();
            nuevoMed.ApellidoMedico = txtApellido.Text.Trim();
            nuevoMed.HoraInicial = TimeSpan.Parse(txtHoraInicio.Text);
            nuevoMed.HoraFinal = TimeSpan.Parse(txtHoraFinal.Text);
            nuevoMed.Birthdate = DateTime.Parse(txtNacimiento.Text);
            nuevoMed.Sexo = char.Parse(rblGenero.SelectedValue);
            nuevoMed.IdProvincia = int.Parse(ddlProvincia.SelectedValue);
            nuevoMed.IdLocalidad = int.Parse(ddlLocalidad.SelectedValue);
            nuevoMed.CodEspecialidad = int.Parse(ddlEspecialidad.SelectedValue);
            nuevoMed.Direccion = txtDireccion.Text.Trim();
            nuevoMed.Correo = txtMail.Text.Trim();
            nuevoMed.NacionalidadMed = txtNacionalidad.Text.Trim();
            nuevoMed.TelefonoMedico = txtTelefono.Text.Trim();
            nuevoMed.IdUsuario = IdUsuario;

            if (checkeoDatos.ExisteMedico(nuevoMed))
            {
                lblErrorVacios.Text = "Ya existe un médico con ese legajo.";
                lblErrorVacios.Visible = true;
                return;
            }

            if (checkeoDatos.ExisteDni(nuevoMed.DniMedico))
            {
                lblErrorVacios.Text = "Ya existe un médico con ese DNI.";
                lblErrorVacios.Visible = true;
                return;
            }



            ClinicaUsuario agregar = new ClinicaUsuario();

            agregar.agregarMedico(nuevoMed);

            foreach (ListItem dia in cblDias.Items)
            {
                if (dia.Selected)
                {
                    int idDia = int.Parse(dia.Value);
                    checkeoDatos.AgregarDias(nuevoMed.LegajoMedico, idDia);
                }
            }
            lblExito.Visible = true;

        }

        public void trimTextos()
        {
            txtNombre.Text.Trim();
            txtApellido.Text.Trim();
            txtDni.Text.Trim();
            txtMail.Text.Trim();
            txtTelefono.Text.Trim();
            txtNacionalidad.Text.Trim();
            txtLegajo.Text.Trim();
            txtUserMedico.Text.Trim();
            txtContraMedico.Text.Trim();
        }
        public bool revisarStringsVacios()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDni.Text) ||
                string.IsNullOrWhiteSpace(txtMail.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtNacionalidad.Text) ||
                string.IsNullOrWhiteSpace(txtLegajo.Text) ||
                string.IsNullOrWhiteSpace(txtUserMedico.Text) ||
                string.IsNullOrWhiteSpace(txtContraMedico.Text))
            {
                return true;
            }
            else return false;
        }

        protected void cvalDias_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool seleccionado = false;
            foreach (ListItem dia in cblDias.Items)
            {
                if (dia.Selected)
                {
                    seleccionado = true;
                    break;
                }
            }
            args.IsValid = seleccionado;
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarLocalidades(int.Parse(ddlProvincia.SelectedValue));
        }

        public void CargarProvincias()
        {
            DaoClinica dao = new DaoClinica();
            ddlProvincia.DataSource = dao.getProvincias();
            ddlProvincia.DataTextField = "Nombre_Provincia";
            ddlProvincia.DataValueField = "Id_Provincia";
            ddlProvincia.DataBind();

            ddlProvincia.Items.Insert(0, new ListItem("Seleccione una provincia", "0"));
        }

        public void CargarEspecialidades()
        {
            DaoClinica dao = new DaoClinica();
            ddlEspecialidad.DataSource = dao.getEspecialidades();
            ddlEspecialidad.DataTextField = "Descripcion_Especialidad";
            ddlEspecialidad.DataValueField = "Cod_Especialidad";
            ddlEspecialidad.DataBind();

            ddlEspecialidad.Items.Insert(0, new ListItem("Seleccione una especialidad", "0"));
        }

        public void CargarLocalidades(int idProvincia)
        {
            DaoClinica dao = new DaoClinica();
            ddlLocalidad.DataSource = dao.getLocalidades(idProvincia);
            ddlLocalidad.DataTextField = "Nombre_Localidad";
            ddlLocalidad.DataValueField = "Id_Localidad";
            ddlLocalidad.DataBind();

            ddlLocalidad.Items.Insert(0, new ListItem("Seleccione una localidad", "0"));
        }
    }

}