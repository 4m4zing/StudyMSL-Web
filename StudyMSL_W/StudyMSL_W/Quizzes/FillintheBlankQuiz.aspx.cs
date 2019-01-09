using Newtonsoft.Json;
using StudyMSL_W.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudyMSL_W.Quizzes
{
    public partial class FillintheBlankQuiz : System.Web.UI.Page
    {
        string WebServiceUrl = ConfigurationManager.AppSettings["apiurl"];
        int questionno;
        Random rdm = new Random();

        private List<question> _questionlist;
        public List<question> questionlist
        {
            get { return _questionlist; }
            set
            {
                _questionlist = value;
                Session["questionlist"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var questiontype = Session["sessionQuiz"].ToString();
                GetQuestion(questiontype);
                ViewState["questionno"] = 0;
                ViewState["score"] = 0;
                ViewState["answer"] = "";
                NextQuestion();
            }
            else
            {
                questionlist = (List<question>)Session["questionlist"];
            }
        }

        protected void btnCheckAnswer_OnClick(object sender, EventArgs e)
        {
            CheckAnswer(txtAnswer.Text.ToUpper());
            NextQuestion();
        }

        private void NextQuestion()
        {
            if (int.Parse(ViewState["questionno"].ToString()) < 10)
            {
                ViewState["questionno"] = int.Parse(ViewState["questionno"].ToString()) + 1;

                int qindex = rdm.Next(0, questionlist.Count);
                question selectedItem = questionlist[qindex];
                UpdateResources(selectedItem);
                questionlist.RemoveAt(qindex);
            }
            else
            {
                UpdateFinalResources();
            }
        }

        private void UpdateResources(question selecteditem)
        {
            questionno = int.Parse(ViewState["questionno"].ToString());
            lblQuestionType.Text = selecteditem.question_type.ToString() + "S";
            lblInstruction.Text = selecteditem.question1.ToString();
            lblQuestion.Text = questionno.ToString();
            lblScore.Text = ViewState["score"].ToString();
            imgQuestion.ImageUrl = selecteditem.image_dir.ToString();
            ViewState["answer"] = selecteditem.answer.ToString();
            //lblTime.Text = aindex.ToString();
            txtAnswer.Text = "";
        }

        private void UpdateFinalResources()
        {
            lblScore.Text = ViewState["score"].ToString();
            btnAnswer.Enabled = false;
        }

        private bool CheckAnswer(string useranswer)
        {
            if (useranswer == ViewState["answer"].ToString())
            {
                ViewState["score"] = int.Parse(ViewState["score"].ToString()) + 1;
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<question> GetQuestion(string id)
        {
            string ext = "questions/" + id;
            var httpClient = new HttpClient();
            HttpResponseMessage response = httpClient.GetAsync(WebServiceUrl + ext).Result;
            questionlist = JsonConvert.DeserializeObject<List<question>>(response.Content.ReadAsStringAsync().Result);

            return questionlist;
        }
    }
}