using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class Turnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string nombreUsuario = Session["Nombre"].ToString();
                lblUsuario.Text = nombreUsuario;
            }
        }

        protected void btnInformeAsistencias_Click(object sender, EventArgs e)
        {
            Response.Redirect("InformeAsistencias.aspx");
        }

        protected void asignarturno_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsignarTurno.aspx");
        }
    }
}