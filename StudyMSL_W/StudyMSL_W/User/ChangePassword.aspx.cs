using Newtonsoft.Json;
using StudyMSL_W.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudyMSL_W.User
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        string WebServiceUrl = ConfigurationManager.AppSettings["apiurl"];

        private List<login> _loginlist;
        public List<login> loginlist
        {
            get { return _loginlist; }
            set { _loginlist = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected async void btnSubmit_Click(object sender, EventArgs e)
        {
            string userName = Session["userName"].ToString();

            login newLogin = await GetAsyncLogin(userName);
            int userId = newLogin.user_id;

            if (txtCurrentPass.Text == newLogin.pword)
            {
                if (txtSubmitNewPassword.Text == txtResubmitNewPassword.Text)
                {
                    newLogin.pword = txtSubmitNewPassword.Text;
                    var message = await PutAsyncLogin(userId, newLogin);
                    if (message == true)
                    {
                        Response.Write("<script>alert('Password is successfully changed. Please log in again using the new password');window.location='../Login.aspx';</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('The new password is not matched');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('The current password is not correct');</script>");
            }
        }

        private List<login> GetLogin()
        {
            string ext = "logins";
            var httpClient = new HttpClient();
            HttpResponseMessage response = httpClient.GetAsync(WebServiceUrl + ext).Result;
            loginlist = JsonConvert.DeserializeObject<List<login>>(response.Content.ReadAsStringAsync().Result);
            return loginlist;
        }

        public string Delete(int id)
        {
            string ext = "logins" + id;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.DeleteAsync(WebServiceUrl + ext).Result;
            return response.Content.ToString();
        }

        public async Task<bool> PostAsyncLogin(login login_)
        {
            string ext = "logins/";
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(login_);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await httpClient.PostAsync(WebServiceUrl + ext, httpContent);

            return result.IsSuccessStatusCode;
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

        public async Task<bool> PutAsyncLogin(int id, login login_)
        {
            string ext = "logins/" + id;
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(login_);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await httpClient.PutAsync(WebServiceUrl + ext, httpContent);

            return result.IsSuccessStatusCode;
        }
    }
}