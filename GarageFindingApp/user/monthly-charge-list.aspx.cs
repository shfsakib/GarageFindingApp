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
    public partial class monthly_charge_list : System.Web.UI.Page
    {
        private BaseClass baseClass;
        private MonthlyChargeModel monthlyChargeModel;
        private MonthlyChargeGateway monthlyChargeGateway;
        public monthly_charge_list()
        {
            baseClass = BaseClass.GetInstance();
            monthlyChargeModel = MonthlyChargeModel.GetInstance();
            monthlyChargeGateway = MonthlyChargeGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                baseClass.CheckTypeCookie(this, "Garage");

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

        protected void txtSearch_OnTextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                baseClass.LoadGrid(gridCharge, $@"SELECT MonthlyCharge.ChargeId, MonthlyCharge.GarageId, MonthlyCharge.Month, MonthlyCharge.BkashNo, MonthlyCharge.TransactionNo, MonthlyCharge.Amount, MonthlyCharge.PaymentTime, MonthlyCharge.Status, UserList.Email, 
                         UserList.GarageName
FROM            MonthlyCharge INNER JOIN
                         UserList ON MonthlyCharge.GarageId = UserList.UserId WHERE MonthlyCharge.Status='{ddlStatus.SelectedValue}' AND MonthlyCharge.Month='{txtSearch.Text}' AND MonthlyCharge.GarageId='{baseClass.UserIdCookie()}'");
            }
        }

        protected void gridCharge_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkRemove = (LinkButton)e.Row.FindControl("lnkRemove");
                if (ddlStatus.SelectedValue == "A")
                {
                    lnkRemove.Visible = false;
                }
            }
        }

        protected void gridCharge_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridCharge.PageIndex = e.NewPageIndex;
            LoadCharge();
        }

        protected void ddlStatus_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCharge();
        }

        protected void lnkRemove_OnClick(object sender, EventArgs e)
        {
            LinkButton lnkInactive = (LinkButton)sender;
            HiddenField chargeId = (HiddenField)lnkInactive.Parent.FindControl("HiddenField1");
            monthlyChargeModel.ChargeId = Convert.ToInt32(chargeId.Value);
            bool ans = monthlyChargeGateway.Delete(monthlyChargeModel);
            if (ans)
            {
                baseClass.PopAlert(this, "Removed successfully");
                LoadCharge();
            }
            else
                baseClass.PopAlert(this, "Failed to remove");

        }
    }
}