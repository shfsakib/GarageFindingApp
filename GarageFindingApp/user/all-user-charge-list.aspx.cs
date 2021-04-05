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
    public partial class all_user_charge_list : System.Web.UI.Page
    {
        private BaseClass baseClass;
        private MonthlyChargeModel monthlyChargeModel;
        private MonthlyChargeGateway monthlyChargeGateway;
        public all_user_charge_list()
        {
            baseClass = BaseClass.GetInstance();
            monthlyChargeModel = MonthlyChargeModel.GetInstance();
            monthlyChargeGateway = MonthlyChargeGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                baseClass.AdminType(this, "Super Admin", "Admin");

                LoadCharge();
            }
        }
        private void LoadCharge()
        {
            baseClass.LoadGrid(gridCharge, $@"SELECT        MonthlyCharge.ChargeId, MonthlyCharge.GarageId, MonthlyCharge.Month, MonthlyCharge.BkashNo, MonthlyCharge.TransactionNo, MonthlyCharge.Amount, MonthlyCharge.PaymentTime, MonthlyCharge.Status, UserList.Email, 
                         UserList.GarageName
FROM            MonthlyCharge INNER JOIN
                         UserList ON MonthlyCharge.GarageId = UserList.UserId WHERE MonthlyCharge.Status='{ddlStatus.SelectedValue}' AND MonthlyCharge.GarageId='{baseClass.UserIdCookie()}'");
        }
        protected void ddlStatus_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCharge();
        }

        protected void txtSearch_OnTextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                baseClass.LoadGrid(gridCharge, $@"SELECT        MonthlyCharge.ChargeId, MonthlyCharge.GarageId, MonthlyCharge.Month, MonthlyCharge.BkashNo, MonthlyCharge.TransactionNo, MonthlyCharge.Amount, MonthlyCharge.PaymentTime, MonthlyCharge.Status, UserList.Email, 
                         UserList.GarageName
FROM            MonthlyCharge INNER JOIN
                         UserList ON MonthlyCharge.GarageId = UserList.UserId WHERE MonthlyCharge.Status='{ddlStatus.SelectedValue}' AND MonthlyCharge.Month='{txtSearch.Text}' AND MonthlyCharge.GarageId='{baseClass.UserIdCookie()}'");
            }
        }
        protected void gridCharge_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridCharge.PageIndex = e.NewPageIndex;
            LoadCharge();
        }

        protected void lbkActive_OnClick(object sender, EventArgs e)
        {
            LinkButton lnkInactive = (LinkButton)sender;
            HiddenField chargeId = (HiddenField)lnkInactive.Parent.FindControl("HiddenField1");
            Label lblEmail = (Label)lnkInactive.Parent.FindControl("lblEmail");
            monthlyChargeModel.ChargeId = Convert.ToInt32(chargeId.Value);
            monthlyChargeModel.Status = "A";
            bool ans = monthlyChargeGateway.UpdateStatus(monthlyChargeModel);
            if (ans)
            {
                bool ans1 = baseClass.SendEmail("carservicecenter02@gmail.com", lblEmail.Text, "Service Charge",
              "<h1>Hello Garage Owner,</h1><br/>Your monthly payment request has been accepted by admin. Please contact us for more information.<br/><b>Thank you</b>",
              "carservice12345");
                if (ans1)
                {
                    baseClass.PopAlert(this, "Accepted successfully");
                    LoadCharge();
                }
                else
                {
                    baseClass.PopAlert(this, "Accepted successfully");
                    LoadCharge();

                }
            }
            else
                baseClass.PopAlert(this, "Failed to accept");
        }

        protected void lnkRemove_OnClick(object sender, EventArgs e)
        {
            LinkButton lnkInactive = (LinkButton)sender;
            HiddenField chargeId = (HiddenField)lnkInactive.Parent.FindControl("HiddenField1");
            Label lblEmail = (Label)lnkInactive.Parent.FindControl("lblEmail");
            monthlyChargeModel.ChargeId = Convert.ToInt32(chargeId.Value);
            bool ans = monthlyChargeGateway.Delete(monthlyChargeModel);
            if (ans)
            {
                bool ans1 = baseClass.SendEmail("carservicecenter02@gmail.com", lblEmail.Text, "Service Charge",
              "<h1>Hello Garage Owner,</h1><br/>Your monthly payment request has been rejected by admin. Please contact us for more information.<br/><b>Thank you</b>",
              "carservice12345");
                if (ans1)
                {
                    baseClass.PopAlert(this, "Removed successfully");
                    LoadCharge();
                }
                else
                {
                    baseClass.PopAlert(this, "Removed successfully");
                    LoadCharge();

                }
            }
            else
                baseClass.PopAlert(this, "Failed to remove");
        }

        protected void gridCharge_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkRemove = (LinkButton)e.Row.FindControl("lnkRemove");
                LinkButton lbkActive = (LinkButton)e.Row.FindControl("lbkActive");
                if (ddlStatus.SelectedValue == "A")
                {
                    lnkRemove.Visible =lbkActive.Visible= false;
                }
            }
        }
    }
}