using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2_Practica
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            IPC2_Practica.BD.BaseDeDatos bd = new IPC2_Practica.BD.BaseDeDatos();
            int res = bd.Login(TextBox1.Text,TextBox2.Text); //Enviar valores

            if (res == -2)
            {
                Response.Redirect("Login.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error de conexion, intentalo de nuevo');</script>");                
            }
            else if (res == -1)
            {
                Response.Redirect("Login.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No coinciden el usuario o la contraseñas');</script>");                
            }
            else if (res == 1)
            {
                Session["Admin"] = TextBox1.Text; // variable de sesion la cual guarda el nombre del usuario
                Response.Redirect("UsuarioAdmin/Usuario.aspx");
            }
        }
    }
}