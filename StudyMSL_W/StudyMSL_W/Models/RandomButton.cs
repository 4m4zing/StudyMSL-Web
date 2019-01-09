using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyMSL_W.Models
{
    [Serializable]
    public class RandomButton
    {
        public String id;
        public String text;
        public String backgroundUrl;
        public String height = "274px";
        public String width = "376px";
        public String backgroundSize = "100px";
        public int buttonIndex;
        public String buttonType;
        public bool clicked;
        public string clickedButton;
    }
}