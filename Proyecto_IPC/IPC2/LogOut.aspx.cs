using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Admin"] = null;
            Session["Agente"] = null;
            Session["Tecnico"] = null;
            Session["User"] = null;
            Response.Redirect("index.html");
        }
    }
}