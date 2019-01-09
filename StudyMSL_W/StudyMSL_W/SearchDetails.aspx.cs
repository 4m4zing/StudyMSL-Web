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

namespace StudyMSL_W
{
    public partial class SearchDetails : System.Web.UI.Page
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
            GetLearn(Session["sessionContent"].ToString());
            imgResult.ImageUrl = learnlist[0].image_dir;
            lblName.Text = learnlist[0].image_name;
            lblDesc.Text = "English: " + learnlist[0].image_desc;
            lblNameMalay.Text = learnlist[0].image_name_malay;
            lblDescMalay.Text = "Malay: " + learnlist[0].image_desc_malay;
        }

        private List<learn> GetLearn(string id)
        {
            string ext = "learns/" + id;
            var httpClient = new HttpClient();
            HttpResponseMessage response = httpClient.GetAsync(WebServiceUrl + ext).Result;
            learnlist = JsonConvert.DeserializeObject<List<learn>>(response.Content.ReadAsStringAsync().Result);
            return learnlist;
        }
    }
}