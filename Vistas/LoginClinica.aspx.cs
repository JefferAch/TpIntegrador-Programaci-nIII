using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using Clinica;
using Entidades;


namespace Vistas
{
    public partial class LoginClinica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            ClinicaUsuario clinica = new ClinicaUsuario();
            string name = txtUsuario.Text;
            string password = txtPassword.Text;
            byte tipo_usuario = Convert.ToByte(RadioButtonList1.SelectedValue);
            if (clinica.verificarUsuario(name, password, tipo_usuario))
            {
                if (RadioButtonList1.SelectedValue == "0")
                {
                    Session["Nombre"] = name;
                    Response.Redirect("IniciadoAdmin.aspx");
                     
                }
                else
                {
                    Session["Nombre"] = name;
                    Response.Redirect("TurnoMedico.aspx");
                    //Console.WriteLine("SE HA INGRESADO AL USUARIO A SU CUENTA");
                }
                   
            }
            else
            {
                lblERROR.Text = "USUARIO INCORRECTO, VERIFIQUE EL USUARIO O CONTRASENIA";
            }

        }

        protected void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

    }
}