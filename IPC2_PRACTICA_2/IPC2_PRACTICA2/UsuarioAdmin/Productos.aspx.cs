using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2_Practica.UAdmin
{
    public partial class Productos : System.Web.UI.Page
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

        protected void Button1_Click(object sender, EventArgs e)
        {   
            //Declaracion de variables
            string a,b,c;
            
            a = RadioButtonList1.SelectedValue.ToString();
            DataTable info = data.BuscarTipoProd(a);            
            b = RadioButtonList2.SelectedValue.ToString();
            DataTable info1 = data.BuscarMaterial(b);            
            c = RadioButtonList3.SelectedValue.ToString();
            DataTable info2 = data.BuscarColor(c);

            // Obtener valores de los radiobutton
            if (info != null) //RadioButton1
            {
                //tipo.Text = info.Rows[0]["idTipo"].ToString();
                txttipo = info.Rows[0]["idTipo"].ToString();
            }
            else
            {
                Response.Redirect("Productos.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No coinciden datos, intente de nuevo');</script>");                
            }
            if (info1 != null) //RadioButton2
            {
                //material.Text = info1.Rows[0]["idMaterial"].ToString();
                txtmaterial = info1.Rows[0]["idMaterial"].ToString();
            }
            else
            {
                Response.Redirect("Productos.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No coinciden datos, intente de nuevo');</script>");                
            }
            if (info2 != null)
            {
                //color.Text = info2.Rows[0]["idColor"].ToString();
                txtcolor = info2.Rows[0]["idColor"].ToString();
            }
            else
            {
                Response.Redirect("Productos.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No coinciden datos, intente de nuevo');</script>");                
            }
            // INSERTAR DATOS EN LA TABLA PRODUCTOS

            int enviar = data.RegistrarProd(TextBox1.Text,TextBox2.Text,Double.Parse(TextBox3.Text),Int32.Parse(txttipo),txtmaterial,txtcolor);
            if (enviar == 0)
            {
                Response.Redirect("Productos.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se pudo registrar el producto');</script>");                
            }
            else if (enviar == 1)
            {
                Response.Redirect("Productos.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error interno, intentelo de nuevo');</script>");                
            }
            else if (enviar == 2)
            {
                Response.Redirect("Usuario.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Producto registrado correctamente');</script>");                
            }
        }    
    }
}