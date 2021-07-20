using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2.Tecnico
{
    public partial class CRecorrido : System.Web.UI.Page
    {
        IPC2.Base_De_Datos.Data datos = new IPC2.Base_De_Datos.Data();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Verificar();
        }

        public void Verificar()
        {
            DataTable aux = datos.BuscarE(TextBox4.Text);
            if (aux != null)
            {
                int info = datos.Recorrido(TextBox1.Text,TextBox2.Text,TextBox3.Text);
                if (info == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error interno.');</script>");
                }
                if (info == 1)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Intenta de nuevo, refresca la pagina.');</script>");
                }
                if (info == 2)
                {
                    int temp = datos.Recorrido(TextBox1.Text.ToString(),TextBox2.Text.ToString(),TextBox3.Text.ToString());
                    if (temp == 0)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Problemas con la conexion de la base de datos.');</script>");
                    }
                    if (temp == 1)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error al registrar los datos a la base de datos.');</script>");
                    }
                    if (temp == 2)
                    {
                        Response.Redirect("HomeT.aspx");
                    }
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No existe dicha empresa.');</script>");
            }
        }
    }
}