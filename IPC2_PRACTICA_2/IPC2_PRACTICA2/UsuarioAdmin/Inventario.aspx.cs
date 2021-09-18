using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2_Practica.UsuarioAdmin
{
    public partial class Inventario : System.Web.UI.Page
    {
        IPC2_Practica.BD.BaseDeDatos data = new IPC2_Practica.BD.BaseDeDatos();
        String prod;

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
            int a = 1;

            DataTable valores = data.ObtenerIDProd(TextBox3.Text);
            if (valores != null)
            {
                prod = valores.Rows[0]["idProducto"].ToString();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No coinciden datos, intente de nuevo');</script>");
                Response.Redirect("Inventario.aspx");
            }
            // INSERTAR VALORES
            int enviar = data.RegistrarInv(Double.Parse(TextBox1.Text), Int32.Parse(TextBox2.Text),Int32.Parse(prod),a);
            if (enviar == 0)
            {                
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se pudo registrar el producto');</script>");
                Response.Redirect("Inventario.aspx");
            }
            else if (enviar == 1)
            {               
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error interno, intentelo de nuevo');</script>");
                Response.Redirect("Inventario.aspx");
            }
            else if (enviar == 2)
            {                
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Producto registrado correctamente');</script>");
                Response.Redirect("Usuario.aspx");
            }
        }
    }
}