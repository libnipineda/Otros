using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace IPC2.Agente_Turismo
{
    public partial class AFotografia : System.Web.UI.Page
    {
        IPC2.Base_De_Datos.Data db = new IPC2.Base_De_Datos.Data();
        string codigo,nombre;
        int codRegion;        

        protected void Page_Load(object sender, EventArgs e)
        {
            nombre = Session["SitioT"].ToString();
            DataTable datos = db.BuscarS(nombre);
            if (datos != null)
            {
                name.Text = datos.Rows[0]["nombre"].ToString();
                codigo = datos.Rows[0]["idSitioT"].ToString();
            }
            else
            {
                Session["SitioT"] = null;
                Response.Redirect("RSitioT.aspx");                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {// parate para poder subir la imagen a la plataforma.
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

            // insertar datos en la tabla detalle
            int a = 0;
            int info = db.Detalle1(codRegion, Int32.Parse(codigo));
            if (info == 0)
            {
                Response.Redirect("AFotografia.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se pudo registrar la información en la base de datos');</script>");
            }
            if (info == 1)
            {
                Response.Redirect("AFotografia.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error interno, intentelo de nuevo');</script>");
            }
            if (info == 2)
            {
                Response.Redirect("HomeA.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Datos registrados correctamente');</script>");
            }

            // insertar datos en la tabla fotografia
            SqlConnection connection = Conexion();
            string instruccion = "INSERT INTO fotografia(imagen,descripcion,codEmpresa,codSitio) values(@foto,@des,@codE,@codS);";
            try
            {
                connection.Open();
                SqlCommand query = new SqlCommand(instruccion, connection);
                query.Parameters.Add("@foto", SqlDbType.VarBinary).Value = FileUpload1.FileBytes;
                query.Parameters.Add("@des", SqlDbType.VarChar, 45).Value = TextBox1.Text.ToString();
                query.Parameters.Add("@codE", SqlDbType.Int).Value = Int32.Parse(codigo.ToString());
                query.Parameters.Add("@codS", SqlDbType.Int).Value = a;
                query.ExecuteNonQuery();
                connection.Close();
                Response.Redirect("HomeA.aspx");
            }
            catch (Exception)
            {
                connection.Close();
                Response.Redirect("AFotografia.aspx");
            }
        }

        public void Pos()
        {
            if (DropDownList1.SelectedIndex == DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Norte")))
            {
                codRegion = 1;                
            }
            else if (DropDownList1.SelectedIndex == DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Sur")))
            {
                codRegion = 2;                
            }
            else if (DropDownList1.SelectedIndex == DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Este")))
            {
                codRegion = 3;                
            }
            else if (DropDownList1.SelectedIndex == DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Oeste")))
            {
                codRegion = 4;                
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