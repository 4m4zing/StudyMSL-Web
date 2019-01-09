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

namespace StudyMSL_W.Games
{
    public partial class MemoryMatchingGame : System.Web.UI.Page
    {
        string WebServiceUrl = ConfigurationManager.AppSettings["apiurl"];
        string ResourcesUrl = ConfigurationManager.AppSettings["resourcesurl"];
        string PlaceholderImageUrl = "~/uploads/resources/Icon_Question_Mark_256.png";
        bool taken1 = false, taken2 = false, taken3 = false, taken4 = false, taken5 = false, taken6 = false;
        Random rdm = new Random();
        bool[] matchedarray = new bool[6];
        string questiontype;
        string[] choicearray = new string[8];
        string[] choiceUrlarray = new string[8];

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
                questiontype = Session["sessionGame"].ToString();
                GetQuestion(questiontype);
                ViewState["questionno"] = 0;
                ViewState["score"] = 100;
                ViewState["step"] = 0;
                ViewState["clickcount"] = 0;
                ViewState["clicked1"] = 0;
                ViewState["clicked2"] = 0;
                for (int i = 0; i < 6; i++)
                {
                    matchedarray[i] = false;
                }
                ViewState["matchedarray"] = matchedarray;
                ThreeQuestion();
            }
            else
            {
                questiontype = Session["sessionGame"].ToString();
                questionlist = (List<question>)Session["questionlist"];
                choicearray = (string[])ViewState["choicearray"];
                choiceUrlarray = (string[])ViewState["choiceUrlarray"];
                matchedarray = (bool[])ViewState["matchedarray"];
            }
        }

        protected void imgbtnChoice1_OnClick(object sender, EventArgs e)
        {
            if (int.Parse(ViewState["clicked1"].ToString()) != 1 && int.Parse(ViewState["clicked2"].ToString()) != 1 && matchedarray[0] != true)
            {
                UpdateCard(1);
                DoAnswer(1);
            }
        }

        protected void imgbtnChoice2_OnClick(object sender, EventArgs e)
        {
            if (int.Parse(ViewState["clicked1"].ToString()) != 2 && int.Parse(ViewState["clicked2"].ToString()) != 2 && matchedarray[1] != true)
            {
                UpdateCard(2);
                DoAnswer(2);
            }
        }

        protected void imgbtnChoice3_OnClick(object sender, EventArgs e)
        {
            if (int.Parse(ViewState["clicked1"].ToString()) != 3 && int.Parse(ViewState["clicked2"].ToString()) != 3 && matchedarray[2] != true)
            {
                UpdateCard(3);
                DoAnswer(3);
            }
        }

        protected void imgbtnChoice4_OnClick(object sender, EventArgs e)
        {
            if (int.Parse(ViewState["clicked1"].ToString()) != 4 && int.Parse(ViewState["clicked2"].ToString()) != 4 && matchedarray[3] != true)
            {
                UpdateCard(4);
                DoAnswer(4);
            }
        }

        protected void imgbtnChoice5_OnClick(object sender, EventArgs e)
        {
            if (int.Parse(ViewState["clicked1"].ToString()) != 5 && int.Parse(ViewState["clicked2"].ToString()) != 5 && matchedarray[4] != true)
            {
                UpdateCard(5);
                DoAnswer(5);
            }
        }

        protected void imgbtnChoice6_OnClick(object sender, EventArgs e)
        {
            if (int.Parse(ViewState["clicked1"].ToString()) != 6 && int.Parse(ViewState["clicked2"].ToString()) != 6 && matchedarray[5] != true)
            {
                UpdateCard(6);
                DoAnswer(6);
            }
        }

        private void ThreeQuestion()
        {
            taken1 = false;
            taken2 = false;
            taken3 = false;
            taken4 = false;
            taken5 = false;
            taken6 = false;

            int rdm1 = rdm.Next(1, 7);
            int rdm2 = rdm.Next(1, 7);
            int rdm3 = rdm.Next(1, 7);
            int rdm4 = rdm.Next(1, 7);
            int rdm5 = rdm.Next(1, 7);
            int rdm6 = rdm.Next(1, 7);

            int qindex1 = rdm.Next(0, questionlist.Count);
            RandomizeImage(rdm1, qindex1);
            RandomizeLabel(rdm4, qindex1, questiontype);
            questionlist.RemoveAt(qindex1);

            int qindex2 = rdm.Next(0, questionlist.Count);
            RandomizeImage(rdm2, qindex2);
            RandomizeLabel(rdm5, qindex2, questiontype);
            questionlist.RemoveAt(qindex2);

            int qindex3 = rdm.Next(0, questionlist.Count);
            RandomizeImage(rdm3, qindex3);
            RandomizeLabel(rdm6, qindex3, questiontype);
            questionlist.RemoveAt(qindex3);

            UpdateInitialResources();
        }

        private void RandomizeImage(int position, int qindex)
        {
            string ext = questionlist[qindex].answer.ToString();
            bool done = false;
            while (done != true)
            {
                if (position == 1)
                {
                    if (taken1 != true)
                    {
                        taken1 = true;
                        done = true;
                    }
                }
                else if (position == 2)
                {
                    if (taken2 != true)
                    {
                        taken2 = true;
                        done = true;
                    }
                }
                else if (position == 3)
                {
                    if (taken3 != true)
                    {
                        taken3 = true;
                        done = true;
                    }
                }
                else if (position == 4)
                {
                    if (taken4 != true)
                    {
                        taken4 = true;
                        done = true;
                    }
                }
                else if (position == 5)
                {
                    if (taken5 != true)
                    {
                        taken5 = true;
                        done = true;
                    }
                }
                else
                {
                    if (taken6 != true)
                    {
                        taken6 = true;
                        done = true;
                    }
                }

                if (done == true)
                {
                    choicearray[position - 1] = ext;
                    ViewState["choicearray"] = choicearray;
                    choiceUrlarray[position - 1] = questionlist[qindex].image_dir;
                    ViewState["choiceUrlarray"] = choiceUrlarray;
                    break;
                }
                else
                {
                    position = rdm.Next(1, 7);
                }
            }
        }

        private void RandomizeLabel(int position, int qindex, string type)
        {
            string full;
            string label = questionlist[qindex].answer.ToString();
            bool done = false;

            if (type == "alphabet")
            {
                var ext = "labels/lblAlphabet_" + label + ".jpg";
                full = ResourcesUrl + ext;
            }
            else
            {
                var ext = "labels/lblNumber_" + label + ".jpg";
                full = ResourcesUrl + ext;
            }

            while (done != true)
            {
                if (position == 1)
                {
                    if (taken1 != true)
                    {
                        taken1 = true;
                        done = true;
                    }
                }
                else if (position == 2)
                {
                    if (taken2 != true)
                    {
                        taken2 = true;
                        done = true;
                    }
                }
                else if (position == 3)
                {
                    if (taken3 != true)
                    {
                        taken3 = true;
                        done = true;
                    }
                }
                else if (position == 4)
                {
                    if (taken4 != true)
                    {
                        taken4 = true;
                        done = true;
                    }
                }
                else if (position == 5)
                {
                    if (taken5 != true)
                    {
                        taken5 = true;
                        done = true;
                    }
                }
                else
                {
                    if (taken6 != true)
                    {
                        taken6 = true;
                        done = true;
                    }
                }

                if (done == true)
                {
                    choicearray[position - 1] = label;
                    ViewState["choicearray"] = choicearray;
                    choiceUrlarray[position - 1] = full;
                    ViewState["choiceUrlarray"] = choiceUrlarray;
                    break;
                }
                else
                {
                    position = rdm.Next(1, 7);
                }
            }
        }

        private void DoAnswer(int whichClicked)
        {
            ViewState["step"] = int.Parse(ViewState["step"].ToString()) + 1;

            if (int.Parse(ViewState["clickcount"].ToString()) == 0)
            {
                ViewState["clickcount"] = int.Parse(ViewState["clickcount"].ToString()) + 1;
                ViewState["clicked1"] = whichClicked;
            }
            else if (int.Parse(ViewState["clickcount"].ToString()) == 1)
            {
                ViewState["clickcount"] = int.Parse(ViewState["clickcount"].ToString()) - 1;
                ViewState["clicked2"] = whichClicked;
                Compare();
                ViewState["clicked1"] = 0;
                ViewState["clicked2"] = 0;
                UpdateCard();
            }
            else
            {
            }
            UpdateResources();
        }

        private void Compare()
        {
            if (isCorrect(int.Parse(ViewState["clicked1"].ToString()), int.Parse(ViewState["clicked2"].ToString())))
            {
                //DependencyService.Get<ToastAlert>().ShortAlert("Matched!  +2 points");
                CheckDone(int.Parse(ViewState["clicked1"].ToString()));
                CheckDone(int.Parse(ViewState["clicked2"].ToString()));
                CheckComplete();
            }
            else
            {
                //DependencyService.Get<ToastAlert>().ShortAlert("Not Matched!  -5 points");
            }
        }

        private bool isCorrect(int inputAnswer1, int inputAnswer2)
        {
            string compare1 = choicearray[inputAnswer1 - 1];
            string compare2 = choicearray[inputAnswer2 - 1];

            if (compare1 == compare2)
            {
                //-->if answers matched
                ViewState["score"] = int.Parse(ViewState["score"].ToString()) + 2;
                return true;
            }
            ViewState["score"] = int.Parse(ViewState["score"].ToString()) - 5;
            return false;
        }

        private void CheckDone(int clicked)
        {
            matchedarray[clicked - 1] = true;
            ViewState["matchedarray"] = matchedarray;
        }

        private void CheckComplete()
        {
            if ((matchedarray[0]) && (matchedarray[1]) && (matchedarray[2]) && (matchedarray[3]) && (matchedarray[4]) && (matchedarray[5]))
            {
                //DisplayAlertScore();
                UpdateFinalResources();
            }
        }

        private void UpdateCard ()
        {
            if (matchedarray[0] != true)
            {
                imgbtnChoice1.ImageUrl = PlaceholderImageUrl;
            }
            if (matchedarray[1] != true)
            {
                imgbtnChoice2.ImageUrl = PlaceholderImageUrl;
            }
            if (matchedarray[2] != true)
            {
                imgbtnChoice3.ImageUrl = PlaceholderImageUrl;
            }
            if (matchedarray[3] != true)
            {
                imgbtnChoice4.ImageUrl = PlaceholderImageUrl;
            }
            if (matchedarray[4] != true)
            {
                imgbtnChoice5.ImageUrl = PlaceholderImageUrl;
            }
            if (matchedarray[5] != true)
            {
                imgbtnChoice6.ImageUrl = PlaceholderImageUrl;
            }

            ViewState["matchedarray"] = matchedarray;
        }

        private void UpdateCard(int clicked)
        {

            if (clicked == 1)
            {
                imgbtnChoice1.ImageUrl = choiceUrlarray[clicked-1];
            }
            if (clicked == 2)
            {
                imgbtnChoice2.ImageUrl = choiceUrlarray[clicked - 1];
            }
            if (clicked == 3)
            {
                imgbtnChoice3.ImageUrl = choiceUrlarray[clicked - 1];
            }
            if (clicked == 4)
            {
                imgbtnChoice4.ImageUrl = choiceUrlarray[clicked - 1];
            }
            if (clicked == 5)
            {
                imgbtnChoice5.ImageUrl = choiceUrlarray[clicked - 1];
            }
            if (clicked == 6)
            {
                imgbtnChoice6.ImageUrl = choiceUrlarray[clicked - 1];
            }
        }

        private void UpdateInitialResources()
        {
            lblQuestionType.Text = questiontype + "S";
            lblInstruction.Text = "Match the signs with their labels";
            lblScore.Text = ViewState["score"].ToString();
            lblSteps.Text = ViewState["step"].ToString();
            UpdateCard();
            //lblTime.Text = aindex.ToString();
        }

        private void UpdateResources()
        {
            lblScore.Text = ViewState["score"].ToString();
            lblSteps.Text = ViewState["step"].ToString();
        }

        private void UpdateFinalResources()
        {
            imgbtnChoice1.Enabled = false;
            imgbtnChoice2.Enabled = false;
            imgbtnChoice3.Enabled = false;
            imgbtnChoice4.Enabled = false;
            imgbtnChoice5.Enabled = false;
            imgbtnChoice6.Enabled = false;
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