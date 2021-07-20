using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2.Agente_Turismo
{
    public partial class GRecibo : System.Web.UI.Page
    {
        IPC2.Base_De_Datos.Data info = new IPC2.Base_De_Datos.Data();
        string codigoE, codigoT;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable aux = info.ObtenerEmpresa(TextBox1.Text.ToString());
            if (aux != null)
            {
                Panel1.Visible = true;
                GridView1.DataSource = aux;
                GridView1.DataBind();
                Mostrar();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se pudo mostrar la información');</script>");
                Panel1.Visible = false;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int a = 0;
            int b = 0;
            string estado = "Sin pagar";
            if (codigoT == "1") // Hotel
            {
                int temp = info.Recibo(estado.ToString(),codigoT.ToString(),a.ToString(),b.ToString());
                if (temp == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error interno intena de nuevo');</script>");
                }
                if (temp == 1)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se registrar la información');</script>");
                }
                if (temp == 2)
                {
                    Response.Redirect("GEvaluacion.aspx");
                }
            }
            if (codigoT == "2")// Restaurante
            {
                int temp1 = info.Recibo(estado.ToString(),a.ToString(),codigoT.ToString(),b.ToString());
                if (temp1 == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error interno intena de nuevo');</script>");
                }
                if (temp1 == 1)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se registrar la información');</script>");
                }
                if (temp1 == 2)
                {
                    Response.Redirect("GEvaluacion.aspx");
                }
            }
            if (codigoT == "3")// Museo
            {
                int temp2 = info.Recibo(estado.ToString(),a.ToString(),b.ToString(),codigoT.ToString());
                if (temp2 == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error interno intena de nuevo');</script>");
                }
                if (temp2 == 1)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se registrar la información');</script>");
                }
                if (temp2 == 2)
                {
                    Response.Redirect("GEvaluacion.aspx");
                }
            }
        }

        public void Mostrar()
        {
            DataTable aux1 = info.BuscarE(TextBox1.Text.ToString());
            if (aux1 != null)
            {
                codigoE = aux1.Rows[0]["idEmpresa"].ToString();
                codigoT = aux1.Rows[0]["codTipoE"].ToString();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se pudo mostrar la información');</script>");
                Panel1.Visible = false;
            }
        }
    }
}