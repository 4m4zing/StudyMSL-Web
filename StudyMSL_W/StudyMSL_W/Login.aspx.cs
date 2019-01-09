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

namespace StudyMSL_W
{
    public partial class Login : System.Web.UI.Page
    {
        string WebServiceUrl = ConfigurationManager.AppSettings["apiurl"];

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["userId"] = null;
            Session["userName"] = null;
        }

        protected async void btnSignIn_Click(object sender, EventArgs e)
        {
            var getMessage = await getAsyncLoginBool(txtUsername.Text, txtPass.Text);

            if (getMessage)
            {
                var getLogin = await GetAsyncLogin(txtUsername.Text);
                Session["userId"] = getLogin.user_id;
                string sessionUserId = Session["userId"].ToString();
                Session["userName"] = getLogin.uname;
                Response.Redirect("~/user/index.aspx", false);
            }

            if (txtUsername.Text == "admin")
            {
                Session["userName"] = "Admin";
                Response.Redirect("~/admin/index.aspx", false);
            }
        }

        public async Task<login> GetAsyncLogin(string u)
        {
            string ext = "logins/" + u;
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(WebServiceUrl + ext);
            var taskModels = JsonConvert.DeserializeObject<login>(json);

            return taskModels;
        }

        public async Task<bool> getAsyncLoginBool(string u, string p)
        {
            string ext = "logins/" + u + ";" + p;
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(WebServiceUrl + ext);

            return response.IsSuccessStatusCode;
        }

        protected void btnGuest_Click(object sender, EventArgs e)
        {
            Session["userName"] = "Guest";
            Response.Redirect("~/guest/index.aspx", false);
        }
    }
}