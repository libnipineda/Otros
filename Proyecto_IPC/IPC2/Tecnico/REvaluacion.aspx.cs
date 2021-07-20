using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2.Tecnico
{
    public partial class REvaluacion : System.Web.UI.Page
    {
        IPC2.Base_De_Datos.Data data = new IPC2.Base_De_Datos.Data();
        string codigoE, codigoT;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Tipo();
            DataTable temp = data.ObtenerEmpresa(TextBox1.Text);
            if (temp != null)
            {
                Panel1.Visible = true;          
                GridView1.DataSource = temp;
                GridView1.DataBind();
                Servicios();                
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error interno, intentelo de nuevo');</script>");
                Panel1.Visible = false;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Servicios();
            int valor = data.ActualizarEva(TextBox2.Text, codigoE.ToString());
            if (valor == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error interno, intentelo de nuevo');</script>");
            }
            if (valor == 1)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se pudo registrar la evaluacion');</script>");
            }
            if (valor == 2)
            {
                Response.Redirect("HomeT.aspx");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Servicios();
            int valor = data.ActualizarEva(TextBox2.Text, codigoE.ToString());
            if (valor == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error interno, intentelo de nuevo');</script>");
            }
            if (valor == 1)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se pudo registrar la evaluacion');</script>");
            }
            if (valor == 2)
            {
                Response.Redirect("HomeT.aspx");
            }
        }

        public void Tipo()
        {
            DataTable aux = data.BuscarE(TextBox1.Text);
            if (aux != null)
            {
                try
                {
                    codigoE = aux.Rows[0]["idEmpresa"].ToString();
                    codigoT = aux.Rows[0]["codTipoE"].ToString();
                }
                catch (Exception)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Upss tenemos un problema, intentelo de nuevo');</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Upss tenemos un problema, intentelo de nuevo');</script>");
            }
        }

        public void Servicios()
        {
            if (codigoT == "1")
            {
                DataTable temp = data.ConsultaS(codigoE.ToString());
                if (temp != null)
                {
                    try
                    {
                        CheckBoxList1.DataSource = temp;
                        CheckBoxList1.DataBind();
                    }
                    catch (Exception)
                    {
                      Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Upss tenemos un problema, no encontramos los servicios de dicha empresa');</script>");
                    }
                }
            }
            if (codigoT == "2")
            {
                DataTable temp = data.ConsultaC(codigoE.ToString());
                if (temp != null)
                {
                    try
                    {
                        CheckBoxList1.DataSource = temp;
                        CheckBoxList1.DataBind();
                    }
                    catch (Exception)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Upss tenemos un problema, no encontramos los menus de dicha empresa');</script>");
                    }
                }
            }
            if (codigoT == "3")
            {
                DataTable temp = data.ConsultaM(codigoE.ToString());
                if (temp != null)
                {
                    try
                    {
                        CheckBoxList1.DataSource = temp;
                        CheckBoxList1.DataBind();
                    }
                    catch (Exception)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Upss tenemos un problema, no encontramos los datos de dicha empresa');</script>");
                    }
                }
            }
        }
    }
}