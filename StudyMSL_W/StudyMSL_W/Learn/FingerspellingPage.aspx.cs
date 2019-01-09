using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudyMSL_W.Learn
{
    public partial class FingerspellingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btncFingerspelling1_OnClicked(object sender, EventArgs e)
        {
            Session["sessionLearn"] = "F01";
            Response.Redirect("~/learn/learningpage.aspx", false);
        }

        protected void btncFingerspelling2_OnClicked(object sender, EventArgs e)
        {
            Session["sessionLearn"] = "F02";
            Response.Redirect("~/learn/learningpage.aspx", false);
        }
    }
}