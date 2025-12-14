using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class IniciadoAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string nombreUsuario = Session["Nombre"].ToString();
            lblUsuario.Text = nombreUsuario;
        }

        protected void btnABMLPac_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABMLPaciente.aspx");
        }

        protected void btnABMLMedicos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABMLMedicos.aspx");
        }

        protected void btnTurno_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsignarTurno.aspx");
        }
    }
}