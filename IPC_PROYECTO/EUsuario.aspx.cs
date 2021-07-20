using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace _IPC2_Fase2.Admin
{
    public partial class EUsuario : System.Web.UI.Page
    {
        _IPC2_Fase2.BD.BD datab = new _IPC2_Fase2.BD.BD();
        SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-FVT6A2E;Initial Catalog=IPC;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text;
            DataTable valores = datab.buscarU(name);
            if (valores == null)
            {
                Response.Redirect("MUsuario.aspx");
                Estado.Text = "No hay coinicidencias con el usuario";
                Button2.Visible = false;
                Button3.Visible = false;
            }
            else
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Select idUsuario from usuario where nickname ='" + name + "'", conexion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Codigo.Text = dt.Rows[0]["idUsuario"].ToString();
                }
                GridView1.Visible = true;
                GridView1.DataSource = valores;
                GridView1.DataBind();
                Panel1.Visible = true;
                Button2.Visible = true; Button3.Visible = true;
                Estado.Text = "Usuario encontrado";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            conexion.Open();
            try
            {
                SqlCommand actualizacion = new SqlCommand("update usuario  set carnet = '" + TextBox2.Text + "',nombre = '" + TextBox3.Text + "',apellido = '" + TextBox4.Text + "',fnac = '"
                + TextBox5.Text + "',email = '" + TextBox6.Text + "',nickname = '" + TextBox7.Text + "', contraseña = '" + TextBox8.Text + "', palabraC = '" + TextBox9.Text + "' where idUsuario = '" + Codigo.Text + "'", conexion);
                actualizacion.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
            Response.Redirect("EditarU.aspx");            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {            
            conexion.Open();
            string a = TextBox1.Text;
            SqlCommand eliminar = new SqlCommand("delete from usuario where nickname = '" + a + "';", conexion);
            eliminar.ExecuteNonQuery();
            conexion.Close();
            Response.Redirect("EUsuario.aspx");
        }
    }
}