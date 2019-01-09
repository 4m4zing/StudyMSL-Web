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
    public partial class SentenceBuilderResults : System.Web.UI.Page
    {

        private List<learn> _learnlist;
        public List<learn> learnlist
        {
            get { return _learnlist; }
            set {
                _learnlist = value;
                Session["searchlist"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                learnlist = (List<learn>)Session["sessionSentence"];
                ViewState["index"] = 0;

                if(learnlist.Count() == 0)
                {
                    Response.Write("<script>alert('The sentence cannot be built. Please try again with different word combination.');window.location='SentenceBuilder.aspx';</script>");
                }
                else
                {
                    loadResources();
                }
            }
            else
            {
                learnlist = (List<learn>)Session["sessionSentence"];
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
            lblNameMalay.Text = learnlist[int.Parse(ViewState["index"].ToString())].image_name_malay.ToString();
            lblDesc.Text = learnlist[int.Parse(ViewState["index"].ToString())].image_desc.ToString();

            if (learnlist[int.Parse(ViewState["index"].ToString())].image_desc_malay == null)
            {
                lblDescMalay.Text = "";
            }
            else
            {
                lblDescMalay.Text = learnlist[int.Parse(ViewState["index"].ToString())].image_desc_malay.ToString();
            }
        }
    }
}