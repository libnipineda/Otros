using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2.Tecnico
{
    public partial class NServicio : System.Web.UI.Page
    {
        IPC2.Base_De_Datos.Data data = new IPC2.Base_De_Datos.Data();
        string codigo, codigoE;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Informacion();            
            DataTable valor = data.ObtenerEmpresa(TextBox1.Text.ToString());
            if (valor != null)
            {
                try
                {
                    Panel1.Visible = true;
                    GridView1.DataSource = valor;
                    GridView1.DataBind();
                    Tipo();
                }
                catch (Exception)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Dicha empresa no se encuentra.');</script>");
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                }             
            }            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int aux = data.Servicio(TextBox2.Text.ToString(),codigoE);
            if (aux == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Intenta de nuevo.');</script>");
            }
            if (aux == 1)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error, no se encuentra la información.');</script>");
            }
            if (aux == 2)
            {
                Response.Redirect("HomeT.aspx");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int aux = data.Catalogo(TextBox3.Text.ToString(),codigoE);
            if (aux == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Intenta de nuevo.');</script>");
            }
            if (aux == 1)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error, no se encuentra la información.');</script>");
            }
            if (aux == 2)
            {
                Response.Redirect("HomeT.aspx");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string precio = "Q.20.00";

            int aux = data.Museo(TextBox4.Text.ToString(),TextBox5.Text.ToString(),precio,codigoE);
            if (aux == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Intenta de nuevo.');</script>");
            }
            if (aux == 1)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error, no se encuentra la información.');</script>");
            }
            if (aux == 2)
            {
                Response.Redirect("HomeT.aspx");
            }
        }

        public void Informacion()
        {
            DataTable table = data.BuscarE(TextBox1.Text.ToString());
            if (table != null)
            {
                try
                {
                    codigoE = table.Rows[0]["idEmpresa"].ToString();
                    codigo = table.Rows[0]["codTipoE"].ToString();
                }
                catch (Exception)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se encuentra dicha empresa .');</script>");
                }
            }
        }

        public void Tipo()
        {
            if (codigo == "1")
            {
                Panel2.Visible = true;
            }
            if (codigo == "2")
            {
                Panel3.Visible = true;
            }
            if (codigo == "3")
            {
                Panel4.Visible = true;
            }
        }
    }
}