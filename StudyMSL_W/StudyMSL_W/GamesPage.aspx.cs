using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudyMSL_W
{
    public partial class GamesPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btncAlphabetMemory_OnClicked(object sender, EventArgs e)
        {
            Session["sessionGame"] = "alphabet";
            Response.Redirect("~/games/memorymatchinggame.aspx", false);
        }

        protected void btncAlphabetSpelling_OnClicked(object sender, EventArgs e)
        {
            Session["sessionGame"] = "alphabet";
            Response.Redirect("~/games/picturespellinggame.aspx", false);
        }

        protected void btncNumberMemory_OnClicked(object sender, EventArgs e)
        {
            Session["sessionGame"] = "number";
            Response.Redirect("~/games/memorymatchinggame.aspx", false);
        }

        protected void btncNumberSpelling_OnClicked(object sender, EventArgs e)
        {
            Session["sessionGame"] = "number";
            Response.Redirect("~/games/picturespellinggame.aspx", false);
        }
    }
}