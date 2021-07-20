using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2.Usuario
{
    public partial class HomeU : System.Web.UI.Page
    {
        Base_De_Datos.Data info = new Base_De_Datos.Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            String usuario = Session["User"].ToString();
            DataTable datos = info.ObtenerU(usuario);
            if (datos != null)
            {                
                nombreU.Text = datos.Rows[0]["nombre"].ToString();
                correo.Text = datos.Rows[0]["email"].ToString();
                name.Text = datos.Rows[0]["nickname"].ToString();
            }
            else
            {
                Session["User"] = null;
                Response.Redirect("../Login.aspx");
            }

            DataTable aux = info.Noticia();
            if (aux != null)
            {
                try
                {
                    GridView1.DataSource = aux;
                    GridView1.DataBind();
                }
                catch (Exception)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No hay noticias para el dia de hoy');</script>");
                }
            }
        }
    }
}