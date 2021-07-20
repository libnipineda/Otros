using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2.Agente_Turismo
{
    public partial class HomeA : System.Web.UI.Page
    {
        Base_De_Datos.Data info = new Base_De_Datos.Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            String usuario = Session["Agente"].ToString();
            DataTable datosu = info.ObtenerU(usuario);
            if (datosu != null)
            {
                nombreU.Text = datosu.Rows[0]["nombre"].ToString();
                correo.Text = datosu.Rows[0]["email"].ToString();
                user.Text = datosu.Rows[0]["nickname"].ToString();
            }
            else
            {
                Session["Agente"] = null;
                Response.Redirect("../Login.aspx");
            }
        }
    }
}