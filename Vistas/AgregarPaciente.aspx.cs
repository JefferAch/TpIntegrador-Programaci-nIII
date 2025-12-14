using Clinica;
using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class AgregarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProvincias();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && !revisarStringsVacios())
            {
                Paciente nuevoPaciente = new Paciente();
                nuevoPaciente.DNI = TextBox3.Text.Trim();
                nuevoPaciente.Nombre = TextBox1.Text.Trim();
                nuevoPaciente.Apellido = TextBox2.Text.Trim();
                nuevoPaciente.Sexo = char.Parse(rblGenero.SelectedValue);
                nuevoPaciente.Nacionalidad = txtNacionalidad.Text.Trim();
                nuevoPaciente.FechaNacimiento = DateTime.Parse(txtNacimiento.Text);
                nuevoPaciente.Direccion = txtDireccion.Text.Trim();
                nuevoPaciente.Telefono = TextBox5.Text.Trim();
                nuevoPaciente.Correo = TextBox4.Text.Trim();
                nuevoPaciente.ID_Localidad = int.Parse(DropDownList3.SelectedValue);
                nuevoPaciente.ID_Provincia = int.Parse(DropDownList2.SelectedValue);
                DaoClinica checkeoDatos = new DaoClinica();
                if (checkeoDatos.ExistePaciente(nuevoPaciente))
                {
                    lblError.Visible = true;
                    return;
                }
                ClinicaUsuario agregar = new ClinicaUsuario();

                agregar.agregarPaciente(nuevoPaciente);
                lbltxt.Text = "Paciente agregado con exito";
                lbltxt.ForeColor=System.Drawing.Color.Green;
            }
        }


        public void CargarProvincias()
        {
            DaoClinica dao = new DaoClinica();
            DropDownList2.DataSource = dao.getProvincias();
            DropDownList2.DataTextField = "Nombre_Provincia";
            DropDownList2.DataValueField = "Id_Provincia";
            DropDownList2.DataBind();

            DropDownList2.Items.Insert(0, new ListItem("Seleccione una provincia", "0"));
        }

        public void CargarLocalidades(int idProvincia)
        {
            DaoClinica dao = new DaoClinica();
            DropDownList3.DataSource = dao.getLocalidades(idProvincia);
            DropDownList3.DataTextField = "Nombre_Localidad";
            DropDownList3.DataValueField = "Id_Localidad";
            DropDownList3.DataBind();

            DropDownList3.Items.Insert(0, new ListItem("Seleccione una localidad", "0"));
        }



        public bool revisarStringsVacios()
        {
            if (string.IsNullOrWhiteSpace(TextBox1.Text) ||
                string.IsNullOrWhiteSpace(TextBox2.Text) ||
                string.IsNullOrWhiteSpace(TextBox3.Text) ||
                string.IsNullOrWhiteSpace(TextBox4.Text) ||
                string.IsNullOrWhiteSpace(TextBox5.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtNacionalidad.Text))
            {
                return true;
            }
            else return false;
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarLocalidades(int.Parse(DropDownList2.SelectedValue));
        }
    }
}