using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using GarageFindingApp.DAL;
using GarageFindingApp.DAL.Gateway;
using GarageFindingApp.DAL.Model;

namespace GarageFindingApp.user
{
    public partial class Default : System.Web.UI.Page
    {
        private BaseClass baseClass;
        private UserListModel userListModel;
        private UserListGateway userListGateway;
        private HttpCookie cookie = BaseClass.GetCookie();
        public Default()
        {
            baseClass = BaseClass.GetInstance();
            userListModel = UserListModel.GetInstance();
            userListGateway = UserListGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (cookie!=null)
                {
                    baseClass.CheckTypeCookie(this, "Customer");
                }
                

                Load();
                baseClass.BindDropDown(ddlThana, "thana", $"SELECT Thana NAME, Id FROM Upazila ORDER BY Name ASC");
            }
        }

        private void Load()
        {
            string query =
                @"SELECT    DISTINCT    UserList.UserId, UserList.Name, UserList.Email, UserList.MobileNo, UserList.UserType, UserList.Gender, UserList.Dob, UserList.GarageName, UserList.District DistrictId, UserList.Thana ThanaId, UserList.Location LocationId, UserList.Address, 
                         UserList.Password, UserList.Picture, UserList.Status, UserList.Intime, UserList.Lat, UserList.Long, (SELECT SUM(Rating.Rate)/COUNT(Rating.Rate) FROM Rating WHERE Rating.GarageId=UserList.UserId) AS Rate, Upazila.Thana AS Thana, Location.LocationName, District.District AS DistrictName
FROM           UserList  INNER JOIN
                         Upazila ON UserList.Thana = Upazila.Id INNER JOIN
                         District ON UserList.District= District.Id  LEFT JOIN
                         Rating ON Rating.GarageId = UserList.UserId INNER JOIN
                        Location ON Location.Id = UserList.Location WHERE UserList.UserType='Garage' AND UserList.Status='A' ORDER BY Rate ASC";
            baseClass.LoadGrid(gridGarage, query);
        }
        protected void gridGarage_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridGarage.PageIndex = e.NewPageIndex;
            Load();
        }
        public string Star(string rate)
        {
            if (rate == "" || rate == "5")
            {
                rate = "⭐⭐⭐⭐⭐";
            }
            else if (rate == "4")
            {
                rate = "⭐⭐⭐⭐";
            }
            else if (rate == "3")
            {
                rate = "⭐⭐⭐";
            }
            else if (rate == "2")
            {
                rate = "⭐⭐";
            }
            else if (rate == "1")
            {
                rate = "⭐";
            }
            return rate;
        }

        protected void lnkBook_OnClick(object sender, EventArgs e)
        {
            if (cookie==null)
            {
                baseClass.PopAlert(this,"Please log in first to book service");
            }
            else
            {
                LinkButton linkButton = (LinkButton) sender;
                HiddenField userId = (HiddenField) linkButton.Parent.FindControl("userId");
                Response.Redirect("/user/book-service.aspx?id="+userId.Value);

            }

        }

       
        protected void gridGarage_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblName = (Label)e.Row.FindControl("lblName");
                HtmlAnchor anchorName = (HtmlAnchor)e.Row.FindControl("anchorName");
                anchorName.InnerText = lblName.Text;
                lblName.Visible = false;
            }
        }

        protected void ddlThana_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            baseClass.BindDropDown(ddlLocation, "location", $"SELECT LocationName Name,Id FROM Location WHERE ThanaId='{ddlThana.SelectedValue}'");
            ddlLocation.Focus();
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            if (ddlThana.Text != "--THANA--" && ddlLocation.Text != "--LOCATION--" && txtSearch.Text != "")
            {
                baseClass.LoadGrid(gridGarage, $@"SELECT    DISTINCT    UserList.UserId, UserList.Name, UserList.Email, UserList.MobileNo, UserList.UserType, UserList.Gender, UserList.Dob, UserList.GarageName, UserList.District DistrictId, UserList.Thana ThanaId, UserList.Location LocationId, UserList.Address, 
                         UserList.Password, UserList.Picture, UserList.Status, UserList.Intime, UserList.Lat, UserList.Long, (SELECT SUM(Rating.Rate)/COUNT(Rating.Rate) FROM Rating WHERE Rating.GarageId=UserList.UserId) AS Rate, Upazila.Thana AS Thana, Location.LocationName, District.District AS DistrictName
FROM           UserList  INNER JOIN
                         Upazila ON UserList.Thana = Upazila.Id INNER JOIN
                         District ON UserList.District= District.Id  LEFT JOIN
                         Rating ON Rating.GarageId = UserList.UserId INNER JOIN
                        Location ON Location.Id = UserList.Location WHERE UserList.UserType='Garage' AND UserList.Status='A' AND UserList.Thana='{ddlThana.SelectedValue}' AND UserList.Location='{ddlLocation.SelectedValue}' AND GarageName +' | '+MobileNo LIKE '" + txtSearch.Text + "%' ORDER BY Rate ASC");
            }
            else if (ddlThana.Text != "--THANA--" && ddlLocation.Text != "--LOCATION--" && txtSearch.Text == "")
            {
                baseClass.LoadGrid(gridGarage, $@"SELECT   DISTINCT     UserList.UserId, UserList.Name, UserList.Email, UserList.MobileNo, UserList.UserType, UserList.Gender, UserList.Dob, UserList.GarageName, UserList.District DistrictId, UserList.Thana ThanaId, UserList.Location LocationId, UserList.Address, 
                         UserList.Password, UserList.Picture, UserList.Status, UserList.Intime, UserList.Lat, UserList.Long, (SELECT SUM(Rating.Rate)/COUNT(Rating.Rate) FROM Rating WHERE Rating.GarageId=UserList.UserId) AS Rate, Upazila.Thana AS Thana, Location.LocationName, District.District AS DistrictName
FROM           UserList  INNER JOIN
                         Upazila ON UserList.Thana = Upazila.Id INNER JOIN
                         District ON UserList.District= District.Id  LEFT JOIN
                         Rating ON Rating.GarageId = UserList.UserId INNER JOIN
                        Location ON Location.Id = UserList.Location WHERE UserList.UserType='Garage' AND UserList.Status='A' AND UserList.Thana='{ddlThana.SelectedValue}' AND UserList.Location='{ddlLocation.SelectedValue}' ORDER BY Rate ASC");

            }
            else if (ddlThana.Text != "--THANA--" && ddlLocation.Text == "--LOCATION--" && txtSearch.Text == "")
            {
                baseClass.LoadGrid(gridGarage, $@"SELECT   DISTINCT     UserList.UserId, UserList.Name, UserList.Email, UserList.MobileNo, UserList.UserType, UserList.Gender, UserList.Dob, UserList.GarageName, UserList.District DistrictId, UserList.Thana ThanaId, UserList.Location LocationId, UserList.Address, 
                         UserList.Password, UserList.Picture, UserList.Status, UserList.Intime, UserList.Lat, UserList.Long, (SELECT SUM(Rating.Rate)/COUNT(Rating.Rate) FROM Rating WHERE Rating.GarageId=UserList.UserId) AS Rate, Upazila.Thana AS Thana, Location.LocationName, District.District AS DistrictName
FROM           UserList  INNER JOIN
                         Upazila ON UserList.Thana = Upazila.Id INNER JOIN
                         District ON UserList.District= District.Id  LEFT JOIN
                         Rating ON Rating.GarageId = UserList.UserId INNER JOIN
                        Location ON Location.Id = UserList.Location WHERE UserList.UserType='Garage' AND UserList.Status='A' AND UserList.Thana='{ddlThana.SelectedValue}' ORDER BY Rate ASC");
            }
            else
            {
                Load();
            }
        }
    }
}