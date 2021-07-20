﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2
{
    public partial class UTecnico : System.Web.UI.MasterPage
    {
        IPC2.Base_De_Datos.Data info = new IPC2.Base_De_Datos.Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Evaluar si ha iniciado sesion
            if (Session["Tecnico"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            else
            {
                String usuario = Session["Tecnico"].ToString();
                //Inicio sesion
                //Evalua que usuario tenga permiso
                int acceso = info.Permisos(usuario);
                if (acceso == 3)
                {
                    // Tiene permiso de estar en los modulos
                }
                else
                {
                    Session["Tecnico"] = null;
                    Response.Redirect("../Login.aspx");
                }
            }
        }
    }
}