using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudyMSL_W.Learn
{
    public partial class SentencePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btncSentence1_OnClicked(object sender, EventArgs e)
        {
            Response.Redirect("~/learn/sentencebuilder.aspx", false);
        }
    }
}