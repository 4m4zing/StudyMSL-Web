using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudyMSL_W.Learn
{
    public partial class WordPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btncWord1_OnClicked(object sender, EventArgs e)
        {
            Session["sessionLearn"] = "W01";
            Response.Redirect("~/learn/learningpage.aspx", false);
        }

        protected void btncWord2_OnClicked(object sender, EventArgs e)
        {
            Session["sessionLearn"] = "W02";
            Response.Redirect("~/learn/learningpage.aspx", false);
        }

        protected void btncWord3_OnClicked(object sender, EventArgs e)
        {
            Session["sessionLearn"] = "W03";
            Response.Redirect("~/learn/learningpage.aspx", false);
        }

        protected void btncWord4_OnClicked(object sender, EventArgs e)
        {
            Session["sessionLearn"] = "W04";
            Response.Redirect("~/learn/learningpage.aspx", false);
        }

        protected void btncWord5_OnClicked(object sender, EventArgs e)
        {
            Session["sessionLearn"] = "W05";
            Response.Redirect("~/learn/learningpage.aspx", false);
        }

        protected void btncWord6_OnClicked(object sender, EventArgs e)
        {
            Session["sessionLearn"] = "W06";
            Response.Redirect("~/learn/learningpage.aspx", false);
        }

        protected void btncWord7_OnClicked(object sender, EventArgs e)
        {
            Session["sessionLearn"] = "W07";
            Response.Redirect("~/learn/learningpage.aspx", false);
        }

        protected void btncWord8_OnClicked(object sender, EventArgs e)
        {
            Session["sessionLearn"] = "W08";
            Response.Redirect("~/learn/learningpage.aspx", false);
        }

        protected void btncWord14_OnClicked(object sender, EventArgs e)
        {
            Session["sessionLearn"] = "W14";
            Response.Redirect("~/learn/learningpage.aspx", false);
        }

        protected void btncWordU_OnClicked(object sender, EventArgs e)
        {
            Session["sessionLearn"] = "WU";
            Response.Redirect("~/learn/learningpage.aspx", false);
        }
    }
}