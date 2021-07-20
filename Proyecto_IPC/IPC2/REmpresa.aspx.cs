using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2
{
    public partial class REmpresa : System.Web.UI.Page
    {
        IPC2.Base_De_Datos.Data DB = new IPC2.Base_De_Datos.Data();
        string valor;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Admin"] = null;
            Session["Agente"] = null;
            Session["Tecnico"] = null;
        }                    
                
        protected void Button1_Click(object sender, EventArgs e)
        { //Agrega el servicio que la empresa otorga            
            if(RadioButton1.Checked)
            {
                valor = "1";
            }
            if (RadioButton2.Checked)
            {
                valor = "2";
            }
            if (RadioButton3.Checked)
            {
                valor = "3";
            }

            int bandera = DB.InsertarE(TextBox1.Text.ToString(), TextBox2.Text.ToString(), TextBox3.Text.ToString(), TextBox4.Text.ToString(), Int32.Parse(valor));
            if (bandera == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No se pudo registrar la empresa');</script>");
            }
            else if (bandera == 1)
            {
                Response.Redirect("REmpresa.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Error interno, intentelo de nuevo');</script>");
            }
            else if (bandera == 2)
            {
                Response.Redirect("Servicio.aspx");
            }
        }        
        
    }
}