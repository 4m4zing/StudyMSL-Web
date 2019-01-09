using StudyMSL_W.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudyMSL_W.User
{
    public partial class ViewProgress : System.Web.UI.Page
    {
        private string userId;
        public string UserId
        {
            get
            {
                if (Session["userId"] != null)
                {
                    userId = Session["userId"].ToString();
                    return userId;
                }
                else
                {
                    return null;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null)
            {
                //Response.Redirect("index.aspx");
            }
            else
            {
                var sessionUserId = Session["userId"].ToString();
                //EntityDataSource1.Where = "it.[user_id] = '" + sessionUserId + "'";

                studymsl_dbEntities db = new studymsl_dbEntities();
                GridView1.DataSource = db.progresses.Where(a => a.user_id.Contains(sessionUserId)).ToList();
                GridView1.DataBind();
            }
        }
    }
}