using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudyMSL_W
{
    public partial class LearnPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btncFingerspelling_OnClicked(object sender, EventArgs e)
        {
            Response.Redirect("~/learn/fingerspellingpage.aspx", false);
        }

        protected void btncWord_OnClicked(object sender, EventArgs e)
        {
            Response.Redirect("~/learn/wordpage.aspx", false);
        }

        protected void btncSentence_OnClicked(object sender, EventArgs e)
        {
            Response.Redirect("~/learn/sentencepage.aspx", false);
        }
    }
}