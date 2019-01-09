using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudyMSL_W
{
    public partial class Default_Admin : System.Web.UI.MasterPage
    {
        private string username;

        protected void Page_Load(object sender, EventArgs e)
        {
            username = Session["userName"].ToString();
            lblUsername.Text = username.ToUpper();
        }

        protected void aHome_OnClicked(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/index.aspx", false);
        }
    }
}