using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2.Usuario
{
    public partial class Consulta : System.Web.UI.Page
    {
        IPC2.Base_De_Datos.Data data = new IPC2.Base_De_Datos.Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable table = data.Informacion();
            if (table == null)
            {                
            }
            else
            {
                try
                {
                    Panel1.Visible = true;
                    GridView1.DataSource = table;
                    GridView1.DataBind();
                }
                catch (Exception)
                {
                    Panel1.Visible = false;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se encontro informacion de la consulta 1.');</script>");
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataTable tabla = data.Compartir();
            if (tabla != null)
            {
                try
                {
                    Panel2.Visible = true;
                    GridView2.DataSource = tabla;
                    GridView2.DataBind();
                }
                catch (Exception)
                {
                    Panel2.Visible = false;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se encontro informacion de la consulta 2.');</script>");
                }
            }            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            DataTable tabla = data.Notificacion();
            if (tabla != null)
            {
                try
                {
                    Panel3.Visible = true;
                    GridView3.DataSource = tabla;
                    GridView3.DataBind();
                }
                catch (Exception)
                {
                    Panel3.Visible = false;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se encontro informacion de la consulta 3.');</script>");
                }
            }            
        }
    }
}