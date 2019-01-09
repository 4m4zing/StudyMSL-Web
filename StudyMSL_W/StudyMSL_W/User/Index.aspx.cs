using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudyMSL_W.User
{
    public partial class Index : System.Web.UI.Page
    {
        string ResourcesUrl = ConfigurationManager.AppSettings["resourcesurl"];

        protected void Page_Load(object sender, EventArgs e)
        {
            //imgStudyMSL.ImageUrl = "http://localhost:55399/uploads/resources/Icon_StudyMSL_v4.png";
            //imgFingerspelling.ImageUrl = "http://localhost:55399/uploads/resources/Icon_Alphabet_200.png";
            //imgWord.ImageUrl = "http://localhost:55399/uploads/resources/Icon_Alphabet_200.png";
            //imgSentence.ImageUrl = "http://localhost:55399/uploads/resources/Icon_Alphabet_200.png";
            //imgGame.ImageUrl = "http://localhost:55399/uploads/resources/Icon_Games_128.png";
            //imgQuiz.ImageUrl = "http://localhost:55399/uploads/resources/Icon_GameQuiz_128.png";
            //imgSearch.ImageUrl = "http://localhost:55399/uploads/resources/Icon_Search_128.png";

            imgStudyMSL.ImageUrl = ResourcesUrl + "resources/Icon_StudyMSL_v4.png";
            imgFingerspelling.ImageUrl = ResourcesUrl + "resources/Icon_Alphabet_200.png";
            imgWord.ImageUrl = ResourcesUrl + "resources/Icon_Alphabet_200.png";
            imgSentence.ImageUrl = ResourcesUrl + "resources/Icon_Alphabet_200.png";
            imgGame.ImageUrl = ResourcesUrl + "resources/Icon_Games_128.png";
            imgQuiz.ImageUrl = ResourcesUrl + "resources/Icon_GameQuiz_128.png";
            imgSearch.ImageUrl = ResourcesUrl + "resources/Icon_Search_128.png";
        }
    }
}