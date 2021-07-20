using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2.Administrador
{
    public partial class Noticia : System.Web.UI.Page
    {
        IPC2.Base_De_Datos.Data data = new IPC2.Base_De_Datos.Data();
        string codigoS;
        string codigoE;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            DataTable tabla = data.BuscarS(textbox1.Text);
            if(tabla != null)
            {
                try
                {
                    codigoS = tabla.Rows[0]["idSitioT"].ToString();
                    Panel1.Visible = true;
                }
                catch (Exception)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se encontro el sitio turistico.');</script>");
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataTable datos = data.BuscarE(textbox1.Text);
            if (datos != null)
            {
                try
                {
                    codigoE = datos.Rows[0]["idEmpresa"].ToString();
                    Panel1.Visible = true;
                }
                catch (Exception)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se encontro la empresa.');</script>");
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile) // verifica que se haya seleccionado un archivo
            {
                //obtener la extension y el tamaño para delimintar si es necesario
                string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
                ext = ext.ToLower();
                //Tamaño en bytes
                int tam = FileUpload1.PostedFile.ContentLength;
                byte[] imagen = new byte[tam];
                //verificacion de extension y tamaño
                if (ext == ".png" || ext == ".jpg" && tam <= 1048576)
                {
                    FileUpload1.SaveAs(Server.MapPath("~/Subidos/" + FileUpload1.FileName));
                }
            }
            else
            {
                Response.Write("Seleccione un archivo a subir");
            }

            // insertar datos en la tabla noticia
            SqlConnection connection = Conexion();
            string info = "INSERT INTO noticia(comentario,titulo,cods) VALUES ('" + Textbox2.Text+"','"+Textbox3.Text+"','"+codigoS+"');";
            try
            {
                connection.Open();
                SqlCommand query = new SqlCommand(info, connection);
                query.ExecuteNonQuery();
                connection.Close();
                Response.Redirect("Home.aspx");
            }
            catch (Exception)
            {
                connection.Close();
                Response.Redirect("Noticia.aspx");
            }
        }

        public SqlConnection Conexion()
        {
            SqlConnection connect = new SqlConnection(); // conexion con la base de datos.
            connect.ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            return connect;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile) // verifica que se haya seleccionado un archivo
            {
                //obtener la extension y el tamaño para delimintar si es necesario
                string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
                ext = ext.ToLower();
                //Tamaño en bytes
                int tam = FileUpload1.PostedFile.ContentLength;
                byte[] imagen = new byte[tam];
                //verificacion de extension y tamaño
                if (ext == ".png" || ext == ".jpg" && tam <= 1048576)
                {
                    FileUpload1.SaveAs(Server.MapPath("~/Subidos/" + FileUpload1.FileName));
                }
            }
            else
            {
                Response.Write("Seleccione un archivo a subir");
            }

            // insertar datos en la tabla noticia
            SqlConnection connection = Conexion();
            string info = "INSERT INTO noticia(comentario,titulo,code) VALUES ('" + Textbox2.Text + "','" + Textbox3.Text + "','" + codigoE + "');";
            try
            {
                connection.Open();
                SqlCommand query = new SqlCommand(info, connection);
                query.ExecuteNonQuery();
                connection.Close();
                Response.Redirect("Home.aspx");
            }
            catch (Exception)
            {
                connection.Close();
                Response.Redirect("Noticia.aspx");
            }
        }
    }
}