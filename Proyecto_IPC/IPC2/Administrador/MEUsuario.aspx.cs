using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2.Administrador
{
    public partial class MEUsuario : System.Web.UI.Page
    {
        IPC2.Base_De_Datos.Data bd = new IPC2.Base_De_Datos.Data();        
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable valores = bd.DatosU(TextBox1.Text);
            if (valores == null)
            {
                Response.Redirect("MEUsuario.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se pudo encontrar el usuario');</script>");
                Panel1.Visible = false;
                Panel2.Visible = false;
            }
            else
            {
                Panel1.Visible = true;
                Panel2.Visible = true;
                GridView1.DataSource = valores;
                GridView1.DataBind();
                Aux.Text = valores.Rows[0]["idUsuario"].ToString();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {            
            string name = TextBox2.Text.ToString();
            string correo = TextBox3.Text.ToString();
            string num = TextBox4.Text.ToString();
            string user = TextBox5.Text.ToString();
            string pass = TextBox7.Text.ToString();
            int tipo = 0;
            // Seleccion de tipo usuario
            if (RadioButton1.Checked)
                tipo = 2;
            else if (RadioButton2.Checked)
                tipo = 3;
            // Verifica que contraseñas coincidan e inserta datos en la BD.
            if (TextBox6.Text.Equals(TextBox7.Text))
            {
                int info = bd.ActualizarU(Aux.Text, name, correo, num, user, pass, tipo);

                if (info == 0)
                {
                    Response.Redirect("MEUsuario.aspx");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se pudo actualizar el usuario');</script>");
                }
                if (info == 1)
                {
                    Response.Redirect("MEUsuario.aspx");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error interno, intentelo de nuevo');</script>");
                }
                if (info == 2)
                {
                    Response.Redirect("Home.aspx");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Usuario actualizado correctamente');</script>");
                }
            }
            else
            {
                Response.Redirect("MEUsuario.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error interno, intentelo de nuevo');</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int aux = bd.EliminarU(Aux.Text);
            if (aux == 0)
            {
                Response.Redirect("MEUsuario.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se pudo eliminar el usuario');</script>");
            }
            if (aux == 1)
            {
                Response.Redirect("MEUsuario.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error interno, intentelo de nuevo');</script>");
            }
            if (aux == 2)
            {
                Response.Redirect("Home.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Usuario eliminado correctamente');</script>");
            }
        }        
    }
}