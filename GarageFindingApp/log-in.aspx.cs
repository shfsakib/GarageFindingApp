using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GarageFindingApp.DAL;

namespace GarageFindingApp
{
    public partial class log_in : System.Web.UI.Page
    {
        private BaseClass baseClass;

        public log_in()
        {
            baseClass = BaseClass.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtEmail.Focus();
            }
        }

        protected void btnLogin_OnServerClick(object sender, EventArgs e)
        {
            if (txtEmail.Value == "")
            {
                baseClass.PopAlert(this, "Email is required");
            }
            else if (!baseClass.EmailValidation(txtEmail.Value))
            {
                baseClass.PopAlert(this, "Enter valid email");
            }
            else if (txtPass.Value == "")
            {
                baseClass.PopAlert(this, "Password is required");
            }
        }
    }
}