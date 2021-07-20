using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2
{
    public partial class Servicio : System.Web.UI.Page
    {
        IPC2.Base_De_Datos.Data bd = new IPC2.Base_De_Datos.Data();
        string codigo, region;        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {// boton para buscar empresa.
            DataTable valor = bd.BuscarE(TextBox1.Text);
            if (valor != null)
            {
                try
                {
                    codigo = valor.Rows[0]["idEmpresa"].ToString();
                    TipoE.Text = valor.Rows[0]["codTipoE"].ToString();
                    Panel1.Visible = true;
                    if (TipoE.Text.ToString().Equals("1"))
                    {
                        Panel2.Visible = true;
                        TipoE.Text = "Hotel";
                    }
                    else if (TipoE.Text.ToString().Equals("2"))
                    {
                        Panel3.Visible = true;
                        TipoE.Text = "Restaurante";
                    }
                    else if (TipoE.Text.ToString().Equals("3"))
                    {
                        Panel4.Visible = true;
                        TipoE.Text = "Museo";
                    }
                }
                catch (Exception)
                {                    
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se pudo encontrar la empresa');</script>");
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {// boton para agregar servicio de la empresa.
            try
            {
                Pos();
                Fotografia();
                InsertarS();
                int aux = bd.Detalle(Int32.Parse(region.ToString()),Int32.Parse(codigo.ToString()));
                if (aux == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Upps, tenemos un problema intenta de nuevo');</script>");
                }
                if (aux == 1)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error interno, intenta de nuevo');</script>");
                }
                if (aux == 2)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Registro efectuado con exito.');</script>");
                    Response.Redirect("index.html");
                }
            }
            catch (Exception)
            {                
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se pudo registrar los servicios del hotel');</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {// boton para agregar menus para el restaurante.
            try
            {
                Pos();
                Fotografia();
                int aux = bd.Detalle(Int32.Parse(region.ToString()), Int32.Parse(codigo.ToString()));
                if (aux == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Upps, tenemos un problema intenta de nuevo');</script>");
                }
                if (aux == 1)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error interno, intenta de nuevo');</script>");
                }
                if (aux == 2)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Registro efectuado con exito.');</script>");                    
                }
            }
            catch (Exception)
            {                
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se pudo registrar los menus del restaurante');</script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {//boton para agregar horarios para el museo.
            try
            {
                Pos();
                Fotografia();
                int aux = bd.Detalle(Int32.Parse(region.ToString()),Int32.Parse(codigo.ToString()));
                if (aux == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Upps, tenemos un problema intenta de nuevo');</script>");
                }
                if (aux == 1)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error interno, intenta de nuevo');</script>");
                }
                if (aux == 2)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Registro efectuado con exito.');</script>");
                    Response.Redirect("index.html");
                }
            }
            catch (Exception)
            {                
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se pudo registrar los horarios del museo');</script>");
            }
        }

        public void Pos()
            {
                if (DropDownList1.SelectedIndex == DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Norte")))
                {
                  region = "1";
                }
                else if (DropDownList1.SelectedIndex == DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Sur")))
                {
                  region = "2";
                }
                else if (DropDownList1.SelectedIndex == DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Este")))
                {
                  region = "3";
                }
                else if (DropDownList1.SelectedIndex == DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("Oeste")))
                {
                  region = "4";
                }
            }

        public void InsertarS()
        {
            int aux = bd.Servicio(TextBox3.Text.ToString(), codigo);
            if (aux == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Intenta de nuevo.');</script>");
            }
            if (aux == 1)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error, no se encuentra la información.');</script>");
            }
            if (aux == 2)
            {
                Response.Redirect("index.html");
            }
        }

        public void InsertarC()
        {
            int aux = bd.Catalogo(TextBox4.Text.ToString(), codigo);
            if (aux == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Intenta de nuevo.');</script>");
            }
            if (aux == 1)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error, no se encuentra la información.');</script>");
            }
            if (aux == 2)
            {
                Response.Redirect("index.html");
            }
        }

        public void InsertarM()
        {
            string precio = "Q.20.00";

            int aux = bd.Museo(TextBox5.Text.ToString(), TextBox6.Text.ToString(), precio, codigo);
            if (aux == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Intenta de nuevo.');</script>");
            }
            if (aux == 1)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error, no se encuentra la información.');</script>");
            }
            if (aux == 2)
            {
                Response.Redirect("index.html");
            }
        }

        public void Fotografia()
        {// boton para subir imagen
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
                Response.Redirect("AServicio.aspx");
            }

            //Insertar datos en la tabla fotografia            
            SqlConnection connection = Conexion();
            string instruccion = "INSERT INTO fotografia(imagen,descripcion,codEmpresa) values(@foto,@des,@codE);";
            try
            {
                connection.Open();
                SqlCommand query = new SqlCommand(instruccion, connection);
                query.Parameters.Add("@foto", SqlDbType.VarBinary).Value = FileUpload1.FileBytes;
                query.Parameters.Add("@des", SqlDbType.VarChar, 45).Value = TextBox1.Text.ToString();
                query.Parameters.Add("@codE", SqlDbType.Int).Value = Int32.Parse(codigo.ToString());                
                query.ExecuteNonQuery();
                connection.Close();
                Response.Redirect("HomeA.aspx");
            }
            catch (Exception ex)
            {
                connection.Close();
                Response.Redirect("AFotografia.aspx");
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