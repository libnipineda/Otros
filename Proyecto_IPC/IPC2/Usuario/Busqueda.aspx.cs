using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace IPC2.Usuario
{
    public partial class Busqueda : System.Web.UI.Page
    {
        IPC2.Base_De_Datos.Data data = new IPC2.Base_De_Datos.Data();
        string codigoR;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {            
            DataTable temp1 = data.Region(TextBox2.Text);
            if (temp1 != null)
            {
                try
                {                    
                    codigoR = temp1.Rows[0]["idRegion"].ToString();
                    Obtener();
                }
                catch (Exception)
                {
                    Response.Redirect("Busqueda.aspx");
                }                
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataTable temp = data.Region(TextBox2.Text);
            if (temp != null)
            {
                try
                {                    
                    codigoR = temp.Rows[0]["idRegion"].ToString();
                    Obtener1();
                }
                catch (Exception)
                {
                    Response.Redirect("Busqueda.aspx");
                }
            }
        }

        public void Obtener()
        {
            DataTable aux = data.BusquedaJoin(codigoR,TextBox1.Text);
            if (aux != null)
            {
                try
                {
                    Panel1.Visible = true;
                    GridView1.DataSource = aux;
                    GridView1.DataBind();
                }
                catch (Exception)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No hay coincidencias con sitios turisticos');</script>");
                }
            }            
        }

        public void Obtener1()
        {
            DataTable aux1 = data.BusquedaJoin1(codigoR, TextBox1.Text);
            if (aux1 != null)
            {
                try
                {
                    Panel1.Visible = true;
                    GridView1.DataSource = aux1;
                    GridView1.DataBind();
                }
                catch (Exception)
                {
                    Panel1.Visible = false;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No hay coincidencias con empresas');</script>");
                }
            }
        }
    }
}