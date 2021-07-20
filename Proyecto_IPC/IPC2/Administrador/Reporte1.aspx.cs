using CrystalDecisions.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2.Administrador
{
    public partial class Reporte1 : System.Web.UI.Page
    {        

        protected void Page_Load(object sender, EventArgs e)
        {
            CrystalReportViewer1.RefreshReport();
        }
    }
}