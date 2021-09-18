using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2_Practica.UsuarioAdmin
{
    public partial class UpdateProductos : System.Web.UI.Page
    {
        IPC2_Practica.BD.BaseDeDatos data = new IPC2_Practica.BD.BaseDeDatos();
        String txttipo, txtmaterial, txtcolor;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Declaracion de variables
            string a, b, c;

            a = RadioButtonList1.SelectedValue.ToString();
            DataTable info = data.BuscarTipoProd(a);
            b = RadioButtonList2.SelectedValue.ToString();
            DataTable info1 = data.BuscarMaterial(b);
            c = RadioButtonList3.SelectedValue.ToString();
            DataTable info2 = data.BuscarColor(c);

            // Obtener valores de los radiobutton
            if (info != null) //RadioButton1
            {                
                txttipo = info.Rows[0]["idTipo"].ToString();
            }
            else
            {
                Response.Redirect("UpdateProductos.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No coinciden datos, intente de nuevo');</script>");                
            }
            if (info1 != null) //RadioButton2
            {             
                txtmaterial = info1.Rows[0]["idMaterial"].ToString();
            }
            else
            {
                Response.Redirect("UpdateProductos.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No coinciden datos, intente de nuevo');</script>");                
            }
            if (info2 != null)
            {             
                txtcolor = info2.Rows[0]["idColor"].ToString();
            }
            else
            {
                Response.Redirect("UpdateProductos.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No coinciden datos, intente de nuevo');</script>");                
            }
            // ACTUALIZAR VALORES
            int enviar = data.ActualizarProd(TextBox1.Text,TextBox2.Text,Double.Parse(TextBox3.Text), Int32.Parse(txttipo), txtmaterial, txtcolor);
            if (enviar == 0)
            {
                Response.Redirect("UpdateProductos.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se pudo actualizar el producto');</script>");                
            }
            else if (enviar == 1)
            {
                Response.Redirect("UpdateProductos.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error interno, intentelo de nuevo');</script>");                
            }
            else if (enviar == 2)
            {
                Response.Redirect("Usuario.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Producto actualizado correctamente');</script>");                
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //ELIMINAR DATOS
            int eliminar = data.EliminarProd(TextBox1.Text);
            if (eliminar == 0)
            {
                Response.Redirect("UpdateProductos.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se pudo actualizar el producto');</script>");                
            }
            else if (eliminar == 1)
            {
                Response.Redirect("UpdateProductos.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error interno, intentelo de nuevo');</script>");                
            }
            else if (eliminar == 2)
            {
                Response.Redirect("Usuario.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Producto actualizado correctamente');</script>");                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable valores = data.buscarProd(TextBox1.Text);            

            if (valores != null)
            {
                GridView1.Visible = true;
                GridView1.DataSource = valores;
                GridView1.DataBind();
                Panel1.Visible = true;
                Button2.Visible = true;
                Button3.Visible = true;               
            }
            else
            {
                Response.Redirect("UpdateProductos.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No coinciden datos, intente de nuevo');</script>");                
            }
        }
    }
}