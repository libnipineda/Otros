using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2.Agente_Turismo
{
    public partial class GEvaluacion : System.Web.UI.Page
    {
        IPC2.Base_De_Datos.Data datos = new IPC2.Base_De_Datos.Data();
        string codigoU, codigoE, codigoTipo,codigoTU;

        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable aux = datos.AgenteE(TextBox1.Text.ToString(),TextBox2.Text.ToString());
            if (aux != null)
            {
                try
                {
                    Panel1.Visible = true;
                    GridView1.DataSource = aux;
                    GridView1.DataBind();
                    codigoU = aux.Rows[0]["usuario.idUsuario"].ToString();
                    codigoTU = aux.Rows[0]["usuario.codTipoU"].ToString();
                    codigoE = aux.Rows[0]["empresa.idEmpresa"].ToString();
                    codigoTipo = aux.Rows[0]["empresa.codTipoE"].ToString();
                    Identificar();
                }
                catch (Exception)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error interno, intente de nuevo');</script>");
                }                
            }
            else
            {                
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No hay coincidencias intente de nuevo');</script>");
                Panel1.Visible = false;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string a = "0", b = "0";

            if (Empresa.Text.Equals("Hotel"))
            {               
                int informacion = datos.InsertarEva(TextBox3.Text.ToString(),codigoU,codigoE,a,codigoTipo,b);
                if (informacion == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se pudo registrar la evaluacion');</script>");
                }
                if (informacion == 1)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error interno, intentelo de nuevo');</script>");
                }
                if (informacion == 2)
                {
                    Response.Redirect("HomeA.aspx");
                }
            }
            if (Empresa.Text.Equals("Restaurante"))
            {                
                int aux = datos.InsertarEva(TextBox3.Text.ToString(),codigoU,codigoE,codigoTipo,a,b);
                if (aux == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se pudo registrar la evaluacion');</script>");
                }
                if (aux == 1)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error interno, intentelo de nuevo');</script>");
                }
                if (aux == 2)
                {
                    Response.Redirect("HomeA.aspx");
                }
            }
            if (Empresa.Text.Equals("Museo"))
            {
                int aux1 = datos.InsertarEva(TextBox3.Text.ToString(),codigoU,codigoE,a,b,codigoTipo);
                if (aux1 == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se pudo registrar la evaluacion');</script>");
                }
                if (aux1 == 1)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error interno, intentelo de nuevo');</script>");
                }
                if (aux1 == 2)
                {
                    Response.Redirect("HomeA.aspx");
                }
            }
        }

        public void Identificar()
        {
            if (codigoTipo == "1")
            {
                Empresa.Text = "Hotel";
            }
            if(codigoTipo == "2")
            {
                Empresa.Text = "Restaurante";
            }
            if (codigoTipo == "3")
            {
                Empresa.Text = "Museo";
            }
        }
    }
}