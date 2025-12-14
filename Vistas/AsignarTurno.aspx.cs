using Clinica;
using Datos;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ClinicaUsuario clinica = new ClinicaUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEspecialidades();
                CargarPacientes();
            }
        }

        private void CargarEspecialidades()
        {
            dropDownEspecialidades.DataSource = clinica.ObtenerEspecialidades();
            dropDownEspecialidades.DataTextField = "Descripcion_Especialidad";
            dropDownEspecialidades.DataValueField = "Cod_Especialidad";
            dropDownEspecialidades.DataBind();
            dropDownEspecialidades.Items.Insert(0, "--Seleccionar--");
        }

        private void CargarPacientes()
        {
            DropdownPaciente.DataSource = clinica.ObtenerPacientes();
            DropdownPaciente.DataTextField = "Nombre";
            DropdownPaciente.DataValueField = "DNI_Paciente";
            DropdownPaciente.DataBind();
            DropdownPaciente.Items.Insert(0, "--Seleccionar--");
        }

        protected void dropDownEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            int esp = int.Parse(dropDownEspecialidades.SelectedValue);
            DropdownEspecialistas.DataSource = clinica.ObtenerMedicosPorEspecialidad(esp);
            DropdownEspecialistas.DataTextField = "Nombre";
            DropdownEspecialistas.DataValueField = "Legajo_Medico";
            DropdownEspecialistas.DataBind();
            DropdownEspecialistas.Items.Insert(0, "--Seleccionar--");
        }

        protected void DropdownEspecialistas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int legajo = int.Parse(DropdownEspecialistas.SelectedValue);

            DataTable dias = clinica.ObtenerDiasMedico(legajo);

            foreach (ListItem item in cblDias.Items)
                item.Selected = false;

            foreach (DataRow row in dias.Rows)
            {
                int idDia = Convert.ToInt32(row["ID_Dia"]);
                cblDias.Items[idDia].Selected = true;
            }
        }

        protected void btnAsignarTurno_Click(object sender, EventArgs e)
        {
            int especialidad = int.Parse(dropDownEspecialidades.SelectedValue);
            int legajo = int.Parse(DropdownEspecialistas.SelectedValue);
            string dni = DropdownPaciente.SelectedValue;
            TimeSpan hora = TimeSpan.Parse(txtHoraInicio.Text);

            int idDia = cblDias.SelectedIndex;
            if (!cblDias.Items[idDia].Selected)
            {
                Response.Write("<script>alert('El médico no atiende ese día');</script>");
                return;
            }

            DataTable horario = clinica.ObtenerHorarioMedico(legajo);

            TimeSpan horaInicio = TimeSpan.Parse(horario.Rows[0]["HorarioInicio"].ToString());
            TimeSpan horaFinal = TimeSpan.Parse(horario.Rows[0]["HorarioFinal"].ToString());

            if (hora < horaInicio || hora > horaFinal)
            {
                Response.Write("<script>alert('La hora ingresada está fuera del horario de atención del médico');</script>");
                return;
            }

            DateTime diaTurno = CalcularFechaProximoDia(idDia);

            if (clinica.ExisteTurno(legajo, diaTurno, hora))
            {
                Response.Write("<script>alert('Ese turno ya está ocupado');</script>");
                return;
            }

            clinica.AgregarTurno(especialidad, diaTurno, hora, dni, legajo);

            Response.Write("<script>alert('Turno asignado con éxito');</script>");
        }

        private DateTime CalcularFechaProximoDia(int idDia)
        {
            DateTime today = DateTime.Today;
            int diferencia = (idDia - (int)today.DayOfWeek + 7) % 7;
            if (diferencia == 0) diferencia = 7;
            return today.AddDays(diferencia);
        }
    }
}
