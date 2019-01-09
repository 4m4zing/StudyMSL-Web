using Newtonsoft.Json;
using StudyMSL_W.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudyMSL_W.Learn
{
    public partial class SentenceBuilder : System.Web.UI.Page
    {
        string WebServiceUrl = ConfigurationManager.AppSettings["apiurl"];

        private List<learn> _learnlist;
        public List<learn> learnlist
        {
            get { return _learnlist; }
            set { _learnlist = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            GetLearn("W");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            List<learn> sessionLearnList = new List<learn>();
            var words = txtSentence.Text.Split(' ');
            if (DropDownList1.SelectedValue == "english")
            {
                //Cut here
                for (int i = 0; i < words.Length; i++)
                {
                    for (int j = 0; j < learnlist.Count; j++)
                    {
                        if (learnlist[j].image_name.ToUpper().Contains(words[i].ToUpper()))
                        {

                            learn newLearn = new learn();

                            newLearn.image_desc = learnlist[j].image_desc;
                            newLearn.image_desc_malay = learnlist[j].image_desc_malay;
                            newLearn.image_dir = learnlist[j].image_dir;
                            newLearn.image_id = learnlist[j].image_id;
                            newLearn.image_name = learnlist[j].image_name;
                            newLearn.image_name_malay = learnlist[j].image_name_malay;
                            newLearn.image_type = learnlist[j].image_type;
                            sessionLearnList.Add(newLearn);
                            break;
                        }
                        else
                        {
                        }
                    }
                } // end for loop words.length
                  //End cut here
            }
            else if (DropDownList1.SelectedValue == "malay")
            {
                //Cut here
                for (int i = 0; i < words.Length; i++)
                {
                    for (int j = 0; j < learnlist.Count; j++)
                    {
                        if (learnlist[j].image_name_malay.ToUpper().Contains(words[i].ToUpper()))
                        {

                            learn newLearn = new learn();

                            newLearn.image_desc = learnlist[j].image_desc;
                            newLearn.image_desc_malay = learnlist[j].image_desc_malay;
                            newLearn.image_dir = learnlist[j].image_dir;
                            newLearn.image_id = learnlist[j].image_id;
                            newLearn.image_name = learnlist[j].image_name;
                            newLearn.image_name_malay = learnlist[j].image_name_malay;
                            newLearn.image_type = learnlist[j].image_type;
                            sessionLearnList.Add(newLearn);
                            break;
                        }
                        else
                        {
                        }
                    }
                } // end for loop words.length
                  //End cut here
            }

            if (sessionLearnList == null)
            {
                Response.Write("No matching results");
            }
            else
            {
                Session["sessionSentence"] = sessionLearnList;
                Response.Redirect("~/learn/sentencebuilderresults.aspx");
            }
        }

        private List<learn> GetLearn(string id)
        {
            string ext = "learns/" + id;
            var httpClient = new HttpClient();
            HttpResponseMessage response = httpClient.GetAsync(WebServiceUrl + ext).Result;
            learnlist = JsonConvert.DeserializeObject<List<learn>>(response.Content.ReadAsStringAsync().Result);

            return learnlist;
        }

        private async Task<bool> GetAsyncLearnByNameExactBool(string keyword, string type)
        {
            string ext = "learns/searchbynameexact/" + keyword + ";" + type;
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(WebServiceUrl + ext);

            return response.IsSuccessStatusCode;
        }
    }
}