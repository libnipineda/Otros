using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2.Usuario
{
    public partial class Nuevo : System.Web.UI.Page
    {
        IPC2.Base_De_Datos.Data info = new IPC2.Base_De_Datos.Data();
        string codigoS, codigoE, name;
        int like, fav;

        protected void Page_Load(object sender, EventArgs e)
        {
            String usuario = Session["User"].ToString();
            name = usuario;
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            codigoE = "0";
            DataTable temp = info.BuscarS(textbox1.Text);
            if (temp !=null)
            {
                try
                {
                    codigoS = temp.Rows[0]["idSitioT"].ToString();
                    panel1.Visible = true;
                    gridview1.DataSource = temp;
                    gridview1.DataBind();
                }
                catch (Exception)
                {
                    panel1.Visible = false;
                    Response.Redirect("Nuevo.aspx");
                }
            }
        }

        protected void button2_Click(object sender, EventArgs e)
        {
            like = 1;
            button2.Text = "1";
        }

        protected void button3_Click(object sender, EventArgs e)
        {
            fav = 1;
            button3.Text = "1";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {// boton comentario
            panel2.Visible = true;            
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Panel3.Visible = true;            
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            codigoS = "0";
            DataTable aux = info.BuscarE(textbox1.Text);
            if (aux != null)
            {
                try
                {
                    codigoE = aux.Rows[0]["idEmpresa"].ToString();
                    panel1.Visible = true;
                    gridview1.DataSource = aux;
                    gridview1.DataBind();
                }
                catch (Exception)
                {
                    panel1.Visible = false;
                    Response.Redirect("Nuevo.aspx");
                }
            }
        }

        protected void comentar_Click(object sender, EventArgs e)
        {
            SqlConnection connection = Conexion();
            if (codigoS == "0")
            {
                string query = "INSERT INTO informacion(gusta,favorito,comentario,codE) VALUES('" + like + "','" + fav + "','" + textbox2.Text + "','" + codigoE + "');";
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception)
                {
                    connection.Close();
                    panel2.Visible = false;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se pudo notificar.');</script>");
                }
            }
            if (codigoE == "0")
            {
                string datos = "INSERT INTO informacion(gusta,favorito,comentario,codS) VALUES('" + like + "','" + fav + "','" + textbox2.Text + "','" + codigoS + "');";
                try
                {
                    connection.Open();
                    SqlCommand valor = new SqlCommand(datos, connection);
                    valor.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception)
                {
                    connection.Close();
                    panel2.Visible = false;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se pudo notificar.');</script>");
                }
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            SqlConnection connection = Conexion();
            if (codigoS == "0")
            {
                string query = "INSERT INTO notificacion(comentario,usuario,codE) VALUES('" + TextBox3.Text + "','" + name + "','" + codigoE + "');";
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception)
                {
                    connection.Close();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se pudo notificar.');</script>");
                }
            }
            if (codigoE == "0")
            {
                string datos = "INSERT INTO notificacion(comentario,usuario,codS) VALUES('" + TextBox3.Text + "','" + name + "','" + codigoS + "');";
                try
                {
                    connection.Open();
                    SqlCommand valor = new SqlCommand(datos, connection);
                    valor.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception)
                {
                    connection.Close();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se pudo notificar.');</script>");
                }
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            SqlConnection connection = Conexion();
            if (codigoS == "0")
            {
                string query = "INSERT INTO compartir(comentario,usuario,codE) VALUES('" + TextBox3.Text + "','" + name + "','" + codigoE + "');";
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception)
                {
                    connection.Close();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se pudo compartir.');</script>");
                }
            }
            if (codigoE == "0")
            {
                string datos = "INSERT INTO compartir(comentario,usuario,codS) VALUES('" + TextBox3.Text + "','" + name + "','" + codigoS + "');";
                try
                {
                    connection.Open();
                    SqlCommand valor = new SqlCommand(datos, connection);
                    valor.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception)
                {
                    connection.Close();
                    Panel3.Visible = false;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se pudo compartir.');</script>");
                }
            }
        }       

        public SqlConnection Conexion()
        {
            SqlConnection connect = new SqlConnection(); // conexion con la base de datos.
            connect.ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            return connect;
        }          
    }
}