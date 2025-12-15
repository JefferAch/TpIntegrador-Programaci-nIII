
using Clinica;
using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class InformeAsistencias : System.Web.UI.Page
    {
        ClinicaUsuario clinica = new ClinicaUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Nombre"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            lblUsuario.Text = Session["Nombre"].ToString();
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            DateTime desde, hasta;

            if (!TryParseFecha(txtDesde.Text, out desde) ||
                !TryParseFecha(txtHasta.Text, out hasta))
            {
                lblPorcentajes.Text = "Formato de fecha inválido.";
                gvAsistencias.DataSource = null;
                gvAsistencias.DataBind();
                return;
            }

            if (hasta < desde)
            {
                lblPorcentajes.Text = "La fecha 'hasta' no puede ser menor que 'desde'.";
                return;
            }

            DateTime desdeIni = desde.Date;
            DateTime hastaFin = hasta.Date.AddDays(1).AddTicks(-1);

            DataTable tabla = clinica.ObtenerInformeAsistencias(desdeIni, hastaFin);

            gvAsistencias.DataSource = tabla;
            gvAsistencias.DataBind();

            CalcularResumen(tabla);
        }

        private bool TryParseFecha(string input, out DateTime fecha)
        {
            input = (input ?? "").Trim();

            return DateTime.TryParseExact(
                       input, "yyyy-MM-dd",
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None,
                       out fecha)
                   ||
                   DateTime.TryParseExact(
                       input, "dd/MM/yyyy",
                       new CultureInfo("es-AR"),
                       DateTimeStyles.None,
                       out fecha);
        }

        private void CalcularResumen(DataTable tabla)
        {
            if (tabla == null || tabla.Rows.Count == 0)
            {
                lblPorcentajes.Text = "No hay datos para el rango de fecha seleccionado.";
                return;
            }

            int total = tabla.Rows.Count;
            int presentes = 0;
            int ausentes = 0;

            foreach (DataRow fila in tabla.Rows)
            {
                int estado = Convert.ToInt32(fila["Estado_Turno"]);

                if (estado == 1)
                    presentes++;
                else if (estado == 2)
                    ausentes++;
            }

            int pPresentes = presentes * 100 / total;
            int pAusentes = ausentes * 100 / total;

            lblPorcentajes.Text =
                pPresentes + "% Presentes - " +
                pAusentes + "% Ausentes";
        }

        protected void gvAsistencias_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            Label lblEstado = (Label)e.Row.FindControl("lblEstado");
            int estado = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Estado_Turno"));

            string textoEstado;
            switch (estado)
            {
                case 0: textoEstado = "Pendiente"; break;
                case 1: textoEstado = "Presente"; break;
                case 2: textoEstado = "Ausente"; break;
                default: textoEstado = "Desconocido"; break;
            }

            lblEstado.Text = textoEstado;
        }

    }
}