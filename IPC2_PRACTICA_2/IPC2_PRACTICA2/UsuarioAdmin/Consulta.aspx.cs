using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2_Practica.UsuarioAdmin
{
    public partial class Consulta : System.Web.UI.Page
    {
        IPC2_Practica.BD.BaseDeDatos data = new IPC2_Practica.BD.BaseDeDatos();
        String txtTipo, txtMaterial, txtColor;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Admin"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            else
            {
                String Usuario = Session["Admin"].ToString();
                /*Usuario ya logeado y evaluamos si tiene acceso a pagina*/
                int acceso = data.permisos(Usuario);
                if (acceso == 1)
                {
                    //Tiene permiso para estar en los modulos
                }
                else
                {
                    IPC2_Practica.BD.BaseDeDatos data = new IPC2_Practica.BD.BaseDeDatos();
                    Response.Redirect("../Login.aspx");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable valor = data.buscarProd(TextBox1.Text);
            if (valor != null)
            {
                GridView1.Visible = true;
                GridView1.DataSource = valor;
                GridView1.DataBind();
                Panel1.Visible = true;                
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No coinciden datos, intente de nuevo');</script>");
                Response.Redirect("UpdateProductos.aspx");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {            
            if (String.IsNullOrEmpty(TextBox2.Text))
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No hay datos, intente de nuevo');</script>");                
            }
            else
            {
                DataTable temp = data.BuscarTipoProd(TextBox2.Text);
                if (temp != null)
                {
                    txtTipo = temp.Rows[0]["idTipo"].ToString();
                    DataTable aux = data.Consulta1(Int32.Parse(txtTipo));
                    if (aux != null)
                    {
                        GridView2.Visible = true;
                        GridView2.DataSource = aux;
                        GridView2.DataBind();
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No coinciden datos, intente de nuevo');</script>");
                        Response.Redirect("Consulta.aspx");
                    }
                }
            }// Cierre del ciclo para obtener el tipo

            if (String.IsNullOrEmpty(TextBox3.Text))
            {
                
            }
            else
            {
                DataTable temp1 = data.BuscarMaterial(TextBox3.Text);
                if (temp1 != null)
                {
                    txtMaterial = temp1.Rows[0]["idMaterial"].ToString();
                    DataTable aux1 = data.Consulta2(txtMaterial);
                    if (aux1 != null)
                    {
                        GridView2.Visible = true;
                        GridView2.DataSource = aux1;
                        GridView2.DataBind();
                    }
                    else
                    {
                        Response.Redirect("Consulta.aspx");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No coinciden datos, intente de nuevo');</script>");                
                    }
                }
            }// Cierre del ciclo para obtener materiales

            if (String.IsNullOrEmpty(TextBox4.Text))
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No hay datos, intente de nuevo');</script>");
            }
            else
            {
                DataTable temp2 = data.BuscarColor(TextBox4.Text);
                if (temp2 != null)
                {
                    txtColor = temp2.Rows[0]["idColor"].ToString();
                    DataTable aux2 = data.Consulta3(txtColor);
                    if (aux2 != null)
                    {
                        GridView2.Visible = true;
                        GridView2.DataSource = aux2;
                        GridView2.DataBind();
                    }
                    else
                    {
                        Response.Redirect("Consulta.aspx");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No coinciden datos, intente de nuevo');</script>");
                    }
                }
            }// Cierre del ciclo para obtener colores
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
        }
    }
}