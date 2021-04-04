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
    public partial class own_profile : System.Web.UI.Page
    {
        private BaseClass baseClass;
        private UserListModel userListModel;
        private UserListGateway userListGateway;

        public own_profile()
        {
            baseClass = BaseClass.GetInstance();
            userListModel = UserListModel.GetInstance();
            userListGateway = UserListGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.ToString() != "id")
                {
                    Response.Redirect("/user/Default.aspx");
                }
                LoadProfile();
            }
        }
        private void LoadProfile()
        {
            profileImage.ImageUrl =
                    baseClass.IsExist($"SELECT Picture FROM UserList WHERE UserId='{baseClass.UserIdCookie()}'");
            ;
            nameLabel.Text = txtName.Text =
                    baseClass.IsExist($"SELECT Name FROM UserList WHERE UserId='{baseClass.UserIdCookie()}'");

            lblEmail.Text = baseClass.EmailCookie();
            lblMobile.Text = txtMobile.Text =
                    baseClass.IsExist($"SELECT MobileNo FROM UserList WHERE UserId='{baseClass.UserIdCookie()}'");

            lblGender.Text =
                ddlGender.Text =
                    baseClass.IsExist($"SELECT Gender FROM UserList WHERE UserId='{baseClass.UserIdCookie()}'");

            lblDob.Text = txtDob.Text =
                    baseClass.IsExist($"SELECT Dob FROM UserList WHERE UserId='{baseClass.UserIdCookie()}'");
            lblGarageName.Text = txtGarageName.Text =
                    baseClass.IsExist($"SELECT GarageName FROM UserList WHERE UserId='{baseClass.UserIdCookie()}'");
            baseClass.BindDropDown(ddlDistrict, "District", "SELECT District NAME, Id FROM District ORDER BY NAME ASC");
            baseClass.BindDropDown(ddlThana, "Thana", "SELECT Thana NAME, Id FROM Upazila ORDER BY NAME ASC");
            baseClass.BindDropDown(ddlLocation, "Location", "SELECT  LocationName NAME, Id FROM Location ORDER BY NAME ASC");
            lbldistrict.Text =
                    baseClass.IsExist($@"SELECT     DISTINCT   District.District
FROM            District INNER JOIN
                         UserList ON District.Id = UserList.District WHERE UserId='{baseClass.UserIdCookie()}'");
            string district =
                baseClass.IsExist($"SELECT District FROM UserList WHERE UserId='{baseClass.UserIdCookie()}'");
            ddlDistrict.SelectedValue = district;
            lblThana.Text =
                  baseClass.IsExist($@"SELECT     DISTINCT   Upazila.Thana
FROM            Upazila INNER JOIN
                         UserList ON Upazila.Id = UserList.Thana WHERE UserId='{baseClass.UserIdCookie()}'");
            ddlThana.SelectedValue = baseClass.IsExist($@"SELECT Thana FROM UserList WHERE UserId='{baseClass.UserIdCookie()}'");
            lblLocation.Text = baseClass.IsExist($@"SELECT     DISTINCT  Location.LocationName
FROM            Location INNER JOIN
                         UserList ON Location.Id = UserList.Location WHERE UserId='{baseClass.UserIdCookie()}'");
            ddlLocation.SelectedValue = baseClass.IsExist($@"SELECT Location FROM UserList WHERE UserId='{baseClass.UserIdCookie()}'");
            lblAddress.Text = txtAddress.Text =
                    baseClass.IsExist($"SELECT Address FROM UserList WHERE UserId='{baseClass.UserIdCookie()}'");
            txtPass.Text = baseClass.IsExist($"SELECT Password FROM UserList WHERE UserId='{baseClass.UserIdCookie()}'");


            string type = baseClass.TypeCookie();
            if (type == "Garage")
            {
                gridService.Visible = garageDiv.Visible = true;
                lblService.Visible = true;
                userDiv.Visible = false;
                baseClass.LoadGrid(gridService, $"SELECT * FROM SERVICE WHERE GarageId='{baseClass.UserIdCookie()}' ORDER BY SERVICENAME ASC");

            }
            else
            {
                gridService.Visible = lblService.Visible = garageDiv.Visible = false;
            }

        }

        protected void btnEdit_OnServerClick(object sender, EventArgs e)
        {
            VisibleElements(false, true);
        }
        private bool IsMobileExist()
        {
            bool ans = false;
            string x = baseClass.IsExist($"SELECT MobileNo FROM UserList WHERE MobileNo='{txtMobile.Text}' AND UserId!='{baseClass.UserIdCookie()}'");
            if (x != "")
            {
                ans = true;
            }
            return ans;
        }
        protected void lnkUpdate_OnClick(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                baseClass.PopAlert(this, "Name is required");
            }

            else if (txtMobile.Text == "")
            {
                baseClass.PopAlert(this, "Mobile no is required");

            }
            else if (IsMobileExist())
            {
                baseClass.PopAlert(this, "Mobile no already exist");
            }
            else if (ddlDistrict.SelectedItem.ToString() == "--DISTRICT--")
            {
                baseClass.PopAlert(this, "District is required");

            }
            else if (ddlThana.SelectedItem.ToString() == "--THANA--")
            {
                baseClass.PopAlert(this, "Thana is required");

            }
            else if (ddlLocation.SelectedItem.ToString() == "--LOCATION--")
            {
                baseClass.PopAlert(this, "Location is required");
            }
            else if (txtAddress.Text == "")
            {
                baseClass.PopAlert(this, "Address is required");

            }
            else if (txtPass.Text == "")
            {
                baseClass.PopAlert(this, "Password is required");

            }
            else if (baseClass.TypeCookie() == "Customer")
            {
                if (ddlGender.Text == "--Select--")
                {
                    baseClass.PopAlert(this, "Gender is required");
                }
                else if (txtDob.Text == "")
                {
                    baseClass.PopAlert(this, "Date of Birth is required");
                }
                else
                {
                    SaveUser();

                }
            }
            else if (baseClass.TypeCookie() == "Garage")
            {
                if (txtGarageName.Text == "")
                {
                    baseClass.PopAlert(this, "Garage name is required");
                }
                else
                {
                    SaveUser();
                }
            }
        }
        private void SaveUser()
        {
            userListModel.UserId = Convert.ToInt32(baseClass.UserIdCookie());
            userListModel.Name = txtName.Text;
            userListModel.MobileNo = txtMobile.Text;
            userListModel.Gender = ddlGender.Text;
            userListModel.Dob = txtDob.Text;
            userListModel.GarageName = txtGarageName.Text;
            userListModel.District = Convert.ToInt32(ddlDistrict.SelectedValue);
            userListModel.Thana = Convert.ToInt32(ddlThana.SelectedValue);
            userListModel.Location = Convert.ToInt32(ddlLocation.SelectedValue);
            userListModel.Address = txtAddress.Text;
            userListModel.Password = txtPass.Text;
            userListModel.Lat = lat.Text;
            userListModel.Long = longL.Text;
            if (fileProfile.HasFile)
            {
                string imagePath = Server.MapPath("/Photos/") + baseClass.UserIdCookie() + ".png";
                fileProfile.PostedFile.SaveAs(imagePath);
                userListModel.Picture = "/Photos/" + baseClass.UserIdCookie() + ".png";
            }
            else
            {
                userListModel.Picture = baseClass.PictureCookie();
            }
            bool ans = userListGateway.UpdateProfile(userListModel);
            if (ans)
            {
                baseClass.PopAlert(this, "Updated successfully");
                VisibleElements(true, false);
                LoadProfile();
            }
            else
            {
                baseClass.PopAlert(this, "Update failed");
            }

        }

        private void VisibleElements(bool first, bool second)
        {
            fileProfile.Visible = txtName.Visible = txtMobile.Visible = ddlGender.Visible = txtDob.Visible = txtGarageName.Visible = ddlDistrict.Visible = ddlThana.Visible = ddlLocation.Visible = txtAddress.Visible = txtPass.Visible = lnkUpdate.Visible = second;
            nameLabel.Visible =
                lblMobile.Visible =
                    lblGender.Visible =
                        lblDob.Visible =
                            lblGarageName.Visible =
                                lbldistrict.Visible =
                                    lblThana.Visible =
                                        lblLocation.Visible = lblAddress.Visible = lblPass.Visible = btnEdit.Visible = first;

        }
    }
}