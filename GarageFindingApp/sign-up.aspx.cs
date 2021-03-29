using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GarageFindingApp.DAL;

namespace GarageFindingApp
{
    public partial class sign_up : System.Web.UI.Page
    {
        private BaseClass baseClass;

        public sign_up()
        {
            baseClass=BaseClass.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtName.Focus();
            }
        }

        protected void ddltype_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddltype.Text== "Customer")
            {
                Customer.Visible = true;
                garage.Visible = false;
                ddlGender.Focus();
            }
            else
            {
                garage.Visible = true;
                Customer.Visible = false;
                txtGarageName.Focus();
            }
        }

        protected void OnServerClick(object sender, EventArgs e)
        {
            if (txtName.Value=="")
            {
                baseClass.PopAlert(this,"Name is required"); 
            }
            else if (txtEmail.Value=="")
            {
                baseClass.PopAlert(this,"Email is required"); 

            }
            else if (!baseClass.EmailValidation(txtEmail.Value))
            {
                baseClass.PopAlert(this,"Enter valid email"); 

            }
            else if (txtMobile.Value=="")
            {
                baseClass.PopAlert(this,"Mobile no is required"); 

            }
            else if (ddltype.Text=="--User Type--")
            {
                baseClass.PopAlert(this,"User type is required"); 

            }
            else if (ddlDistrict.Text=="--DISTRICT--")
            {
                baseClass.PopAlert(this,"District is required"); 

            }
            else if (ddlLocation.Text=="--LOCATION--")
            {
                baseClass.PopAlert(this,"Location is required"); 

            }
            else if (txtAddress.Text=="")
            {
                baseClass.PopAlert(this,"Address is required"); 

            }
            else if (txtNewPass.Value=="")
            {
                baseClass.PopAlert(this,"Password is required"); 

            }
            else if (txtNewPass.Value!=txtConfirmPass.Value)
            {
                baseClass.PopAlert(this, "Password mismatch ✖");
            }

        }
    }
}