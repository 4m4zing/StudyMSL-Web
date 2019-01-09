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
    public partial class Search : System.Web.UI.Page
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
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtSearch.Text))
            {
                Response.Write("<script>alert('Please fill in the search field');</script>");
            }
            else
            {
                GetLearnMalay(txtSearch.Text, ddlCategory.SelectedValue);
                LinkButton lbContentRedirect = (LinkButton)FindControl("lbContentRedirect");
                repSearch.DataSource = learnlist;
                repSearch.DataBind();
            }
        }

        protected void repSearch_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Session["sessionContent"] = e.CommandName;
            string sessionContent = Session["sessionContent"].ToString();
            Response.Redirect("~/searchdetails.aspx", false);
        }

        private List<learn> GetLearn(string name, string type)
        {
            string ext = "learns/searchbyname/" + name + ";" + type;
            var httpClient = new HttpClient();
            HttpResponseMessage response = httpClient.GetAsync(WebServiceUrl + ext).Result;
            learnlist = JsonConvert.DeserializeObject<List<learn>>(response.Content.ReadAsStringAsync().Result);
            return learnlist;
        }

        private List<learn> GetLearnMalay(string name, string type)
        {
            string ext = "learns/searchbyname/all/" + name + ";" + type;
            var httpClient = new HttpClient();
            HttpResponseMessage response = httpClient.GetAsync(WebServiceUrl + ext).Result;
            learnlist = JsonConvert.DeserializeObject<List<learn>>(response.Content.ReadAsStringAsync().Result);
            return learnlist;
        }
    }
}