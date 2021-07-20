using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2
{
    public partial class UAdmin : System.Web.UI.MasterPage
    {
        IPC2.Base_De_Datos.Data info = new IPC2.Base_De_Datos.Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Evaluar si ha iniciado sesion
            if (Session["Admin"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            else
            {
                String usuario = Session["Admin"].ToString();
                //Inicio sesion
                //Evalua que usuario tenga permiso
                int acceso = info.Permisos(usuario);
                if (acceso == 1)
                {
                    // Tiene permiso de estar en los modulos
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