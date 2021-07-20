using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2
{
    public partial class CrearU : System.Web.UI.Page
    {
        IPC2.Base_De_Datos.Data data = new IPC2.Base_De_Datos.Data();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            int tipo = 4;
            if (TextBox5.Text.Equals(TextBox6.Text))
            {
                int aux = data.CrearU(TextBox1.Text,TextBox2.Text,TextBox3.Text,TextBox4.Text,TextBox6.Text,tipo);
                if (aux == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error interno, intenta de nuevo');</script>");
                }
                if (aux == 1)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Upss no podemos registrar dicho usuario, intenta de nuevo');</script>");
                }
                if (aux == 2)
                {
                    Response.Redirect("index.html");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No coinciden la contraseña, intenta de nuevo');</script>");
            }
        }
    }
}