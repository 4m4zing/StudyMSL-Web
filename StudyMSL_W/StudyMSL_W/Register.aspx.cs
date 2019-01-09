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

namespace StudyMSL_W
{
    public partial class Register : System.Web.UI.Page
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
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtEmail.Text) 
                || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
                Response.Write("<script>alert('Please fill in all fields');</script>");
            }
            else
            {
                GetLogin();
                if (txtPassword.Text == txtConfirmPassword.Text)
                {
                    login newLogin = new login();
                    newLogin.email = txtEmail.Text;
                    newLogin.pword = txtConfirmPassword.Text;
                    newLogin.uname = txtUsername.Text;
                    var message = await PostAsyncLogin(newLogin);
                    if (message == true)
                    {
                        Response.Write("<script>alert('" + txtName.Text.ToUpper() + ", your new account has been created');window.location='Login.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Your chosen username is unavailable');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Your password is not matched');</script>");
                }
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
    }
}