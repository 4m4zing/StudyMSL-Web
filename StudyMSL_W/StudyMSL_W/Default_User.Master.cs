using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudyMSL_W
{
    public partial class Default_User : System.Web.UI.MasterPage
    {
        private string username;


        protected void Page_Load(object sender, EventArgs e)
        {
            //username = "DEVELOPER";
            username = Session["userName"].ToString();
            lblUsername.Text = username.ToUpper();

            if (username == "Guest")
            {
                lblNotGuest.Visible = false;
            }
        }

        protected void aHome_OnClicked(object sender, EventArgs e)
        {
            if (username == "Guest")
            {
                Response.Redirect("~/guest/index.aspx", false);
            }
            else
            {
                Response.Redirect("~/user/index.aspx", false);
            }
        }
    }
}