using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2_Practica.UsuarioAdmin
{
    public partial class Usuario : System.Web.UI.Page
    {
        IPC2_Practica.BD.BaseDeDatos data = new IPC2_Practica.BD.BaseDeDatos();
        string prod, tipo, mate, desc, costU, costA, unid, col;

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
                    Session["Admin"] = null;
                    Response.Redirect("../Login.aspx");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string path = Path.GetFileName(FileUpload1.FileName);
            path = path.Replace(",","");
            FileUpload1.SaveAs(Server.MapPath("~/ExcelA/") + path);
            String excelp = Server.MapPath("~/ExcelA/") + path;
            OleDbConnection conexcel = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + excelp + "; Extended Properties=Excel 8.0; Persist Security Info = False");
            conexcel.Open();
            OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", conexcel);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                prod = dr[0].ToString();
                tipo = dr[1].ToString();
                mate = dr[2].ToString();
                desc = dr[3].ToString();
                costU = dr[4].ToString();
                costA = dr[5].ToString();
                unid = dr[6].ToString();
                col = dr[7].ToString();                
                GuardarDatos(prod, tipo, mate, desc, costU, costA, unid, col);
            }
            Label1.Text = "Datos Ingresados correctamente";
        }

        public void GuardarDatos(String prod, String tipo, String mate, String desc, String cost, String costA, String u, String c)
        {
            String query1 = ("create table ##Carga(producto varchar(50),tipo varchar(50),material varchar(50),descripcion varchar(50),costo varchar(50),costoA varchar(50),unidad varchar(50),color varchar(50));");
            String query = ("insert into ##Carga(producto,tipo,material,descripcion,costo,costoA,unidad,color) values (" + prod + "','" + tipo + "','" + mate + "','" + desc + "','" + cost + "','" + costA + "','" + u + "','" + c + "');");            
            SqlConnection connect = new SqlConnection(); //conexion con la base de datos.
            connect.ConnectionString = ConfigurationManager.ConnectionStrings["ConexionSql"].ConnectionString;

            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query1;
                cmd.Connection = connect;
                cmd.ExecuteNonQuery();
                connect.Close();
            }
            catch (Exception)
            {
                connect.Close();
            }
            
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connect;
                cmd.ExecuteNonQuery();
                connect.Close();
            }
            catch (Exception)
            {
                connect.Close();
            }
        }

    }
}