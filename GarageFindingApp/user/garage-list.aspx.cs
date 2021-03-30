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
    public partial class GarageList : System.Web.UI.Page
    {
        private BaseClass baseClass;
        private UserListModel userListModel;
        private UserListGateway userListGateway;

        public GarageList()
        {
            baseClass = BaseClass.GetInstance();
            userListModel = UserListModel.GetInstance();
            userListGateway = UserListGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load();
            }
        }
        private void Load()
        {
            string query = @"SELECT        UserList.UserId, UserList.Name, UserList.Email, UserList.UserType, UserList.MobileNo, UserList.Gender, UserList.GarageName, UserList.Dob, UserList.Thana AS ThanaId, UserList.District, UserList.Location, 
                         UserList.Password, UserList.Address, UserList.Picture, UserList.Status, UserList.Intime, UserList.Lat, UserList.Long, District.District AS DistrictName, Upazila.Thana, Location.LocationName
FROM            Upazila INNER JOIN
                         Location ON Upazila.Id = Location.ThanaId INNER JOIN
                         District ON Upazila.DistrictId = District.Id INNER JOIN
                         UserList ON District.Id = UserList.District AND Upazila.Id = UserList.Thana AND Location.Id = UserList.Location WHERE UserList.UserType='Garage' AND  UserList.Status='" + ddlStatus.SelectedValue + "'";
            baseClass.LoadGrid(gridUser, query);
        }
        protected void ddlStatus_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Load();
        }

        protected void txtSearch_OnTextChanged(object sender, EventArgs e)
        {
            string query = @"SELECT        UserList.UserId, UserList.Name, UserList.Email, UserList.UserType, UserList.MobileNo, UserList.Gender, UserList.GarageName, UserList.Dob, UserList.Thana AS ThanaId, UserList.District, UserList.Location, 
                         UserList.Password, UserList.Address, UserList.Picture, UserList.Status, UserList.Intime, UserList.Lat, UserList.Long, District.District AS DistrictName, Upazila.Thana, Location.LocationName
FROM            Upazila INNER JOIN
                         Location ON Upazila.Id = Location.ThanaId INNER JOIN
                         District ON Upazila.DistrictId = District.Id INNER JOIN
                         UserList ON District.Id = UserList.District AND Upazila.Id = UserList.Thana AND Location.Id = UserList.Location WHERE UserType='Garage' AND Status='" + ddlStatus.SelectedValue + "' AND UserList.Name +' | '+UserList.MobileNo LIKE '" + txtSearch.Text + "%'";
            baseClass.LoadGrid(gridUser, query);
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
                else if (ddlStatus.Text == "P")
                {
                    linkActive.Visible = true;
                    linkInactive.Visible = false;
                }
            }
        }

        protected void gridUser_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridUser.PageIndex = e.NewPageIndex;
            Load();
        }

        protected void lnkInactive_OnClick(object sender, EventArgs e)
        {
            LinkButton lnkInactive = (LinkButton)sender;
            HiddenField hiddenField = (HiddenField)lnkInactive.Parent.FindControl("HiddenField1");
            Label lblEmail = (Label)lnkInactive.Parent.FindControl("lblEmail");
            userListModel.UserId = Convert.ToInt32(hiddenField.Value);
            userListModel.Status = "I";
            bool ans = userListGateway.UpdateStatus(userListModel);
            if (ans)
            {
                bool ans1 = baseClass.SendEmail("carservicecenter02@gmail.com", lblEmail.Text, "Registration",
                     "<h1>Hello User,</h1><br/>Your account has been blocked by Admin.Please contact with us as soon as possible.<br/><b>Thank you</b>",
                     "carservice12345");
                if (ans1)
                {
                    baseClass.PopAlert(this, "User inactivate successfully");
                    Load();
                }

            }
            else
            {
                baseClass.PopAlert(this, "User inactivation failed");
            }
        }

        protected void lbkActive_OnClick(object sender, EventArgs e)
        {
            LinkButton lnkInactive = (LinkButton)sender;
            HiddenField hiddenField = (HiddenField)lnkInactive.Parent.FindControl("HiddenField1");
            Label lblEmail = (Label)lnkInactive.Parent.FindControl("lblEmail");
            userListModel.UserId = Convert.ToInt32(hiddenField.Value);
            userListModel.Status = "A";
            bool ans = userListGateway.UpdateStatus(userListModel);
            if (ans)
            {
                bool ans1 = baseClass.SendEmail("carservicecenter02@gmail.com", lblEmail.Text, "Registration",
                   "<h1>Hello User,</h1><br/>Your account has been activate by Admin.<br/><b>Thank you</b>",
                   "carservice12345");
                if (ans1)
                {
                    baseClass.PopAlert(this, "User activate successfully");
                    Load();
                }

            }
            else
            {
                baseClass.PopAlert(this, "User activation failed");
            }
        }
    }
}