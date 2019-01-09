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
    public partial class PictureSpellingGame : System.Web.UI.Page
    {
        string WebServiceUrl = ConfigurationManager.AppSettings["apiurl"];
        string ResourcesUrl = ConfigurationManager.AppSettings["resourcesurl"];
        bool taken1 = false, taken2 = false, taken3 = false, taken4 = false, taken5 = false, taken6 = false, taken7 = false, taken8 = false;
        int questionno;
        Random rdm = new Random();
        string answer, image_dir, questiontype;
        string[] choicearray = new string[8];
        string[] answerUrlarray = new string[8];

        private List<spellingquestion> _questionlist;
        public List<spellingquestion> questionlist
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
                ViewState["score"] = 0;
                ViewState["position"] = 1;
                ViewState["answer"] = "";
                ViewState["fullanswer"] = "";
                NextQuestion();
                ViewState["answerUrlarray"] = answerUrlarray;
            }
            else
            {
                questiontype = Session["sessionGame"].ToString();
                questionlist = (List<spellingquestion>)Session["questionlist"];
                choicearray = (string[])ViewState["choicearray"];
                answerUrlarray = (string[])ViewState["answerUrlarray"];
            }
        }

        protected void imgbtnChoice1_OnClick(object sender, EventArgs e)
        {
            DoAnswer(1);
        }

        protected void imgbtnChoice2_OnClick(object sender, EventArgs e)
        {
            DoAnswer(2);
        }

        protected void imgbtnChoice3_OnClick(object sender, EventArgs e)
        {
            DoAnswer(3);
        }

        protected void imgbtnChoice4_OnClick(object sender, EventArgs e)
        {
            DoAnswer(4);
        }

        protected void imgbtnChoice5_OnClick(object sender, EventArgs e)
        {
            DoAnswer(5);
        }

        protected void imgbtnChoice6_OnClick(object sender, EventArgs e)
        {
            DoAnswer(6);
        }

        protected void imgbtnChoice7_OnClick(object sender, EventArgs e)
        {
            DoAnswer(7);
        }

        protected void imgbtnChoice8_OnClick(object sender, EventArgs e)
        {
            DoAnswer(8);
        }

        protected void btnResetAnswer_OnClick(object sender, EventArgs e)
        {
            EmptyAnswer();
            //Response.Write("<script>alert('Test');</script>");
        }

        protected void btnCheckAnswer_OnClick(object sender, EventArgs e)
        {
            CheckAnswer();
            EmptyAnswer();
            NextQuestion();
        }

        private void DoAnswer(int button)
        {
            if (int.Parse(ViewState["position"].ToString()) <= 8)
            {
                var addition = choicearray[button-1];
                ViewState["fullanswer"] = ViewState["fullanswer"].ToString() + addition;
                SetAnswerImage(int.Parse(ViewState["position"].ToString()), addition, questiontype);
                ViewState["position"] = int.Parse(ViewState["position"].ToString()) + 1;
                //lblTest.Text = ViewState["fullanswer"].ToString();
            }
        }

        private void NextQuestion()
        {
            if (int.Parse(ViewState["questionno"].ToString()) < 4)
            {
                ViewState["questionno"] = int.Parse(ViewState["questionno"].ToString()) + 1;

                taken1 = false;
                taken2 = false;
                taken3 = false;
                taken4 = false;
                taken5 = false;
                taken6 = false;
                taken7 = false;
                taken8 = false;

                int qindex = rdm.Next(0, questionlist.Count);
                spellingquestion selectedItem = questionlist[qindex];

                image_dir = selectedItem.image_dir;
                answer = selectedItem.answer;

                int rdm1 = rdm.Next(1, 9);
                int rdm2 = rdm.Next(1, 9);
                int rdm3 = rdm.Next(1, 9);
                int rdm4 = rdm.Next(1, 9);
                int rdm5 = rdm.Next(1, 9);
                int rdm6 = rdm.Next(1, 9);
                int rdm7 = rdm.Next(1, 9);
                int rdm8 = rdm.Next(1, 9);

                RandomizeImageButton(rdm1, selectedItem.image1_dir, questiontype);
                RandomizeImageButton(rdm2, selectedItem.image2_dir, questiontype);
                RandomizeImageButton(rdm3, selectedItem.image3_dir, questiontype);
                RandomizeImageButton(rdm4, selectedItem.image4_dir, questiontype);
                RandomizeImageButton(rdm5, selectedItem.image5_dir, questiontype);
                RandomizeImageButton(rdm6, selectedItem.image6_dir, questiontype);
                RandomizeImageButton(rdm7, selectedItem.image7_dir, questiontype);
                RandomizeImageButton(rdm8, selectedItem.image8_dir, questiontype);
                UpdateResources(selectedItem);
                questionlist.RemoveAt(qindex);
            }
            else
            {
                UpdateFinalResources();
            }
        }

        private void RandomizeImageButton(int position, string image, string type)
        {
            string full;
            bool done = false;

            if (type == "alphabet")
            {
                var ext = "alphabets/Alphabet_" + image + ".jpg";
                full = ResourcesUrl + ext;
            }
            else
            {
                var ext = "numbers/Number_" + image + ".jpg";
                full = ResourcesUrl + ext;
            }

            while (done != true)
            {
                if (position == 1)
                {
                    if (taken1 != true)
                    {
                        imgbtnChoice1.ImageUrl = full;
                        taken1 = true;
                        done = true;
                    }
                }
                else if (position == 2)
                {
                    if (taken2 != true)
                    {
                        imgbtnChoice2.ImageUrl = full;
                        taken2 = true;
                        done = true;
                    }
                }
                else if (position == 3)
                {
                    if (taken3 != true)
                    {
                        imgbtnChoice3.ImageUrl = full;
                        taken3 = true;
                        done = true;
                    }
                }
                else if (position == 4)
                {
                    if (taken4 != true)
                    {
                        imgbtnChoice4.ImageUrl = full;
                        taken4 = true;
                        done = true;
                    }
                }
                else if (position == 5)
                {
                    if (taken5 != true)
                    {
                        imgbtnChoice5.ImageUrl = full;
                        taken5 = true;
                        done = true;
                    }
                }
                else if (position == 6)
                {
                    if (taken6 != true)
                    {
                        imgbtnChoice6.ImageUrl = full;
                        taken6 = true;
                        done = true;
                    }
                }
                else if (position == 7)
                {
                    if (taken7 != true)
                    {
                        imgbtnChoice7.ImageUrl = full;
                        taken7 = true;
                        done = true;
                    }
                }
                else
                {
                    if (taken8 != true)
                    {
                        imgbtnChoice8.ImageUrl = full;
                        taken8 = true;
                        done = true;
                    }
                }

                if (done == true)
                {
                    choicearray[position - 1] = image;
                    ViewState["choicearray"] = choicearray;
                    break;
                }
                else
                {
                    position = rdm.Next(1, 9);
                }
            }
        }

        private void SetAnswerImage(int position, string value, string type)
        {
            string ext;

            if (type == "alphabet")
            {
                ext = "alphabets/Alphabet_";
            }
            else
            {
                ext = "numbers/Number_";
            }

            if (position == 1)
            {
                answerUrlarray[0] = ResourcesUrl + ext + value + ".jpg";
                ViewState["answerUrlarray"] = answerUrlarray;
                imgAnswer1.ImageUrl = answerUrlarray[0];
            }
            else if (position == 2)
            {
                answerUrlarray[1] = ResourcesUrl + ext + value + ".jpg";
                ViewState["answerUrlarray"] = answerUrlarray;
                imgAnswer2.ImageUrl = answerUrlarray[1];

            }
            else if (position == 3)
            {
                answerUrlarray[2] = ResourcesUrl + ext + value + ".jpg";
                ViewState["answerUrlarray"] = answerUrlarray;
                imgAnswer3.ImageUrl = answerUrlarray[2];
            }
            else if (position == 4)
            {
                answerUrlarray[3] = ResourcesUrl + ext + value + ".jpg";
                ViewState["answerUrlarray"] = answerUrlarray;
                imgAnswer4.ImageUrl = answerUrlarray[3];
            }
            else if (position == 5)
            {
                answerUrlarray[4] = ResourcesUrl + ext + value + ".jpg";
                ViewState["answerUrlarray"] = answerUrlarray;
                imgAnswer5.ImageUrl = answerUrlarray[4];
            }
            else if (position == 6)
            {
                answerUrlarray[5] = ResourcesUrl + ext + value + ".jpg";
                ViewState["answerUrlarray"] = answerUrlarray;
                imgAnswer6.ImageUrl = answerUrlarray[5];
            }
            else if (position == 7)
            {
                answerUrlarray[6] = ResourcesUrl + ext + value + ".jpg";
                ViewState["answerUrlarray"] = answerUrlarray;
                imgAnswer7.ImageUrl = answerUrlarray[6];
            }
            else
            {
                answerUrlarray[7] = ResourcesUrl + ext + value + ".jpg";
                ViewState["answerUrlarray"] = answerUrlarray;
                imgAnswer8.ImageUrl = answerUrlarray[7];
            }
        }

        private void UpdateResources(spellingquestion selecteditem)
        {
            questionno = int.Parse(ViewState["questionno"].ToString());
            lblQuestionType.Text = selecteditem.question_type.ToString() + "S";
            lblInstruction.Text = "Spell the answer for the image below using fingerspelling";
            lblQuestion.Text = questionno.ToString();
            lblScore.Text = ViewState["score"].ToString();
            imgQuestion.ImageUrl = selecteditem.image_dir.ToString();
            ViewState["answer"] = selecteditem.answer;
            //lblTime.Text = aindex.ToString();
        }

        private void UpdateFinalResources()
        {
            lblScore.Text = ViewState["score"].ToString();
            imgbtnChoice1.Enabled = false;
            imgbtnChoice2.Enabled = false;
            imgbtnChoice3.Enabled = false;
            imgbtnChoice4.Enabled = false;
            imgbtnChoice5.Enabled = false;
            imgbtnChoice6.Enabled = false;
            imgbtnChoice7.Enabled = false;
            imgbtnChoice8.Enabled = false;
            btnResetAnswer.Enabled = false;
            btnCheckAnswer.Enabled = false;
        }

        private void EmptyAnswer()
        {
            imgAnswer1.ImageUrl = "";
            imgAnswer2.ImageUrl = "";
            imgAnswer3.ImageUrl = "";
            imgAnswer4.ImageUrl = "";
            imgAnswer5.ImageUrl = "";
            imgAnswer6.ImageUrl = "";
            imgAnswer7.ImageUrl = "";
            imgAnswer8.ImageUrl = "";
            ViewState["answerUrlarray"] = null;
            ViewState["answerUrlarray"] = new string[8];
            ViewState["position"] = 1;
            ViewState["fullanswer"] = "";
        }

        private bool CheckAnswer()
        {
            if (ViewState["fullanswer"].ToString() == ViewState["answer"].ToString())
            {
                ViewState["score"] = int.Parse(ViewState["score"].ToString()) + 1;
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<spellingquestion> GetQuestion(string id)
        {
            string ext = "spellingquestions/" + id;
            var httpClient = new HttpClient();
            HttpResponseMessage response = httpClient.GetAsync(WebServiceUrl + ext).Result;
            questionlist = JsonConvert.DeserializeObject<List<spellingquestion>>(response.Content.ReadAsStringAsync().Result);

            return questionlist;
        }
    }
}