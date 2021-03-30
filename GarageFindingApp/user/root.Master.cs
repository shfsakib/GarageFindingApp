using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GarageFindingApp.DAL;

namespace GarageFindingApp.user
{
    public partial class root : System.Web.UI.MasterPage
    {
        private BaseClass baseClass;

        public root()
        {
            baseClass=BaseClass.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string GetImage(string link)
        {
            if (link=="")
            {
                return "../Link/garage.png";
            }
            else
            {
                return link;
            }
        }
        public string GetName(string link)
        {
            if (link == "")
            {
                return "Hello User";
            }
            else
            {
                return link;
            }
        }
        protected void lnkLogOut_OnClick(object sender, EventArgs e)
        {
            baseClass.Logout();
        }
    }
}