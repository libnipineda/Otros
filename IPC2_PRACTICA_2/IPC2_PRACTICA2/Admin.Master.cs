using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2_Practica
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            IPC2_Practica.BD.BaseDeDatos data = new IPC2_Practica.BD.BaseDeDatos();
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
    }
}