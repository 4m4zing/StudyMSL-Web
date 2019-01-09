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

namespace StudyMSL_W.Learn
{
    public partial class LearningPage : System.Web.UI.Page
    {
        string WebServiceUrl = ConfigurationManager.AppSettings["apiurl"];
        
        private List<learn> _learnlist;
        public List<learn> learnlist
        {
            get { return _learnlist; }
            set {
                _learnlist = value;
                Session["learnlist"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var learntype = Session["sessionLearn"].ToString();
                GetLearn(learntype);
                ViewState["index"] = 0;
                loadResources();
            }
            else
            {
                learnlist = (List<learn>)Session["learnlist"];
            }
        }

        protected void btnPrevious_OnClick(object sender, EventArgs e)
        {
            if (int.Parse(ViewState["index"].ToString()) > 0)
            {
                ViewState["index"] = int.Parse(ViewState["index"].ToString()) - 1;
                loadResources();
            }

        }

        protected void btnNext_OnClick(object sender, EventArgs e)
        {
            if (int.Parse(ViewState["index"].ToString()) < learnlist.Count - 1)
            {
                ViewState["index"] = int.Parse(ViewState["index"].ToString()) + 1;
                loadResources();
            }
        }

        private void loadResources()
        {
            imgLearn.ImageUrl = learnlist[int.Parse(ViewState["index"].ToString())].image_dir.ToString();
            lblName.Text = learnlist[int.Parse(ViewState["index"].ToString())].image_name.ToString();
            lblDesc.Text = learnlist[int.Parse(ViewState["index"].ToString())].image_desc.ToString();

            if (learnlist[int.Parse(ViewState["index"].ToString())].image_name_malay == null)
            {
                lblNameMalay.Text = "";
            }
            else
            {
                lblNameMalay.Text = learnlist[int.Parse(ViewState["index"].ToString())].image_name_malay.ToString();
            }

            if (learnlist[int.Parse(ViewState["index"].ToString())].image_desc_malay == null)
            {
                lblDescMalay.Text = "";
            }
            else
            {
                lblDescMalay.Text = learnlist[int.Parse(ViewState["index"].ToString())].image_desc_malay.ToString();
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
    }
}