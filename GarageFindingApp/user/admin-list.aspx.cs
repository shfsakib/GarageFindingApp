using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GarageFindingApp.DAL;
using GarageFindingApp.DAL.Gateway;
using GarageFindingApp.DAL.Model;

namespace GarageFindingApp.user
{
    public partial class admin_list : System.Web.UI.Page
    {
        private BaseClass baseClass;
        private AdminModel adminModel;
        private AdminGateway adminGateway;

        public admin_list()
        {
            baseClass = BaseClass.GetInstance();
            adminModel = AdminModel.GetInstance();
            adminGateway = AdminGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAdmin();
            }
        }
        private void LoadAdmin()
        {
            baseClass.LoadGrid(gridAdmin, $@"SELECT * FROM Admin WHERE Status='{ddlStatus.SelectedValue}' ORDER BY Id DESC");
        }
        protected void ddlStatus_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAdmin();
        }

        protected void txtSearch_OnTextChanged(object sender, EventArgs e)
        {
            baseClass.LoadGrid(gridAdmin, $@"SELECT * FROM Admin WHERE Status='{ddlStatus.SelectedValue}' AND Name +' | '+MobileNo='{txtSearch.Text}' ORDER BY Id DESC");

        }

        protected void gridUser_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton linkActive = (LinkButton)e.Row.FindControl("lbkActive");
                LinkButton linkInactive = (LinkButton)e.Row.FindControl("lnkInactive");
                if (ddlStatus.Text == "A")
                {
                    linkActive.Visible = false;
                    linkInactive.Visible = true;
                }
                else if (ddlStatus.Text == "I")
                {
                    linkActive.Visible = true;
                    linkInactive.Visible = false;
                }
            }
        }

        protected void gridUser_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridAdmin.PageIndex = e.NewPageIndex;
            LoadAdmin();
        }

        protected void lnkInactive_OnClick(object sender, EventArgs e)
        {
            LinkButton lnkInactive = (LinkButton)sender;
            HiddenField hiddenField = (HiddenField)lnkInactive.Parent.FindControl("HiddenField1");
            Label lblEmail = (Label)lnkInactive.Parent.FindControl("lblEmail");
            adminModel.Id = Convert.ToInt32(hiddenField.Value);
            adminModel.Status = "I";
            bool ans = adminGateway.Update(adminModel);
            if (ans)
            {
                bool ans2 = baseClass.SendEmail("carservicecenter02@gmail.com", lblEmail.Text, "Registration",
                    "<h1>Hello User,</h1><br/>Your account has been blocked by an Admin.Please contact with us as soon as possible.<br/><b>Thank you</b>",
                    "carservice12345");
                if (ans2)
                {
                    baseClass.PopAlert(this, "Admin inactivate successfully");
                    LoadAdmin();
                }
                else
                {
                    baseClass.PopAlert(this, "Admin inactivate successfully");
                    LoadAdmin();
                }
            }
            else
            {
                baseClass.PopAlert(this, "Admin inactivation failed");
            }
        }

        protected void lbkActive_OnClick(object sender, EventArgs e)
        {
            LinkButton lnkInactive = (LinkButton)sender;
            HiddenField hiddenField = (HiddenField)lnkInactive.Parent.FindControl("HiddenField1");
            Label lblEmail = (Label)lnkInactive.Parent.FindControl("lblEmail");
            adminModel.Id = Convert.ToInt32(hiddenField.Value);
            adminModel.Status = "A";
            bool ans = adminGateway.Update(adminModel);
            if (ans)
            {
                bool ans2 = baseClass.SendEmail("carservicecenter02@gmail.com", lblEmail.Text, "Registration",
                  "<h1>Hello User,</h1><br/>Your account has been activate by an Admin.<br/><b>Thank you</b>",
                  "carservice12345");
                if (ans2)
                {
                    baseClass.PopAlert(this, "Admin inactivate successfully");
                    LoadAdmin();
                }
                else
                {
                    baseClass.PopAlert(this, "Admin inactivate successfully");
                    LoadAdmin();
                }
            }
            else
            {
                baseClass.PopAlert(this, "Admin inactivation failed");
            }
        }
    }
}