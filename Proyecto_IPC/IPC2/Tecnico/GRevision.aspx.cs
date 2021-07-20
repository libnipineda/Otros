using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2.Tecnico
{
    public partial class GRevision : System.Web.UI.Page
    {
        IPC2.Base_De_Datos.Data datos = new IPC2.Base_De_Datos.Data();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable aux = datos.Revision(TextBox1.Text);
            if (aux != null)
            {
                GridView1.Visible = true;
                GridView1.DataSource = aux;
                GridView1.DataBind();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Dicha empresa aun no se encuentra inscrita.');</script>");
                GridView1.Visible = false;
            }
        }        
    }
}