using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2.Administrador
{
    public partial class CrearU : System.Web.UI.Page
    {
        IPC2.Base_De_Datos.Data data = new Base_De_Datos.Data();
        int tipo = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Seleccion de tipo usuario
            if (RadioButton1.Checked)
                tipo = 2;
            else if (RadioButton2.Checked)
                tipo = 3;
            // Verifica que contraseñas coincidan e inserta datos en la BD.
            if (TextBox5.Text.Equals(TextBox6.Text))
            {
                int info = data.CrearU(TextBox1.Text,TextBox2.Text,TextBox3.Text,TextBox4.Text,TextBox6.Text,tipo);
                if (info == 0)
                {
                    Response.Redirect("CrearU.aspx");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se pudo registrar el usuario');</script>");
                }
                if (info == 1)
                {
                    Response.Redirect("CrearU.aspx");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error interno, intentelo de nuevo');</script>");
                }
                if (info == 2)
                {
                    Response.Redirect("Home.aspx");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Usuario registrado correctamente');</script>");
                }
            }
            else
            {
                Response.Redirect("CrearU.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error interno, intentelo de nuevo');</script>");
            }
        }        
    }
}