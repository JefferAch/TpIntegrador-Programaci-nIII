using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class InformeAsistencias : System.Web.UI.Page
    {
        ClinicaUsuario clinica = new ClinicaUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
             lblUsuario.Text = Session["Nombre"].ToString();
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            DateTime desde = Convert.ToDateTime(txtDesde.Text);
            DateTime hasta = Convert.ToDateTime(txtHasta.Text);

            DataTable tabla = clinica.ObtenerInformeAsistencias(desde, hasta);
            gvAsistencias.DataSource = tabla;
            gvAsistencias.DataBind();
            CalcularResumen(tabla);
        }

       private void CalcularResumen(DataTable tabla)
       {
         int total = tabla.Rows.Count;
         if (total == 0)
         {
             lblPorcentajes.Text = "No hay datos para el rango de fecha seleccionado.";
             return;
         }
         int presentes = 0;
         int ausentes = 0;

         foreach (DataRow turno in tabla.Rows)
         {
             int estado = Convert.ToInt32(turno["Estado_Turno"]);

             if (estado == 1)
                 presentes++;
             else if (estado == 2)
                 ausentes++;

            int pAtendidos = presentes * 100 / total;
            int pAusentes = ausentes * 100 / total;
            lblPorcentajes.Text = $"{pAtendidos}% Presentes " + $" {pAusentes}%  Ausentes";
       }
       }
    }
}
