using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2
{
    public partial class Login : System.Web.UI.Page
    {
        IPC2.Base_De_Datos.Data DB = new IPC2.Base_De_Datos.Data();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            int res = DB.Login(TextBox1.Text, TextBox2.Text);
            if (res == -2)
            {             
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error de conexion, intentalo de nuevo');</script>");
            }
            if (res == -1)
            {                
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No coinciden el usuario o la contraseñas');</script>");
            }
            if (res == 1)
            {
                Session["Admin"] = TextBox1.Text; // variable de sesion la cual guarda el nombre del usuario                                
                Response.Redirect("Administrador/Home.aspx");
            }
            if (res == 2)
            {
                Session["Agente"] = TextBox1.Text;
                Response.Redirect("Agente Turismo/HomeA.aspx");
            }
            if (res == 3)
            {
                Session["Tecnico"] = TextBox1.Text;
                Response.Redirect("Tecnico/HomeT.aspx");
            }
            if (res == 4)
            {
                Session["User"] = TextBox1.Text;
                Response.Redirect("Usuario/HomeU.aspx");
            }
        }
    }
}