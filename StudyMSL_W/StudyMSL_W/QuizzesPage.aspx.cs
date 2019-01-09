using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudyMSL_W
{
    public partial class QuizzesPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btncAlphabetMCQ_OnClicked(object sender, EventArgs e)
        {
            Session["sessionQuiz"] = "alphabet";
            Response.Redirect("~/quizzes/multiplechoicequiz.aspx", false);
        }

        protected void btncAlphabetFITB_OnClicked(object sender, EventArgs e)
        {
            Session["sessionQuiz"] = "alphabet";
            Response.Redirect("~/quizzes/fillintheblankquiz.aspx", false);
        }

        protected void btncNumberMCQ_OnClicked(object sender, EventArgs e)
        {
            Session["sessionQuiz"] = "number";
            Response.Redirect("~/quizzes/multiplechoicequiz.aspx", false);
        }

        protected void btncNumberFITB_OnClicked(object sender, EventArgs e)
        {
            Session["sessionQuiz"] = "number";
            Response.Redirect("~/quizzes/fillintheblankquiz.aspx", false);
        }

        protected void btncWordMCQ_OnClicked(object sender, EventArgs e)
        {
            Session["sessionQuiz"] = "word";
            Response.Redirect("~/quizzes/multiplechoicequiz.aspx", false);
        }

        protected void btncWordFITB_OnClicked(object sender, EventArgs e)
        {
            Session["sessionQuiz"] = "word";
            Response.Redirect("~/quizzes/fillintheblankquiz.aspx", false);
        }
    }
}