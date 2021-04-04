using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GarageFindingApp.DAL;
using GarageFindingApp.DAL.Gateway;
using GarageFindingApp.DAL.Model;

namespace GarageFindingApp
{
    public partial class sign_up : System.Web.UI.Page
    {
        private BaseClass baseClass;
        private UserListModel userListModel;
        private UserListGateway userListGateway;

        public sign_up()
        {
            baseClass = BaseClass.GetInstance();
            userListModel = UserListModel.GetInstance();
            userListGateway = UserListGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtName.Focus();
                baseClass.BindDropDown(ddlDistrict, "District", "SELECT District NAME, Id FROM District ORDER BY NAME ASC");
            }
        }
       
        protected void ddltype_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddltype.Text == "Customer")
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

        private bool IsEmailExist()
        {
            bool ans = false;
            string x = baseClass.IsExist($"SELECT Email FROM UserList WHERE Email='{txtEmail.Value}'");
            if (x != "")
            {
                ans = true;
            }
            return ans;
        }
        private bool IsMobileExist()
        {
            bool ans = false;
            string x = baseClass.IsExist($"SELECT MobileNo FROM UserList WHERE MobileNo='{txtMobile.Value}'");
            if (x != "")
            {
                ans = true;
            }
            return ans;
        }
        protected void OnServerClick(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Value == "")
                {
                    baseClass.PopAlert(this, "Name is required");
                }
                else if (txtEmail.Value == "")
                {
                    baseClass.PopAlert(this, "Email is required");

                }
                else if (!baseClass.EmailValidation(txtEmail.Value))
                {
                    baseClass.PopAlert(this, "Enter valid email");
                }
                else if (IsEmailExist())
                {
                    baseClass.PopAlert(this, "Email already exist");
                }
                else if (IsMobileExist())
                {
                    baseClass.PopAlert(this, "Mobile no already exist");
                }
                else if (txtMobile.Value == "")
                {
                    baseClass.PopAlert(this, "Mobile no is required");

                }
                else if (ddltype.Text == "--User Type--")
                {
                    baseClass.PopAlert(this, "User type is required");

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
                else if (txtNewPass.Value == "")
                {
                    baseClass.PopAlert(this, "Password is required");

                }
                else if (txtNewPass.Value != txtConfirmPass.Value)
                {
                    baseClass.PopAlert(this, "Password mismatch ✖");
                }
                else if (ddltype.Text == "Customer")
                {
                    if (ddlGender.Text == "--Select--")
                    {
                        baseClass.PopAlert(this, "Gender is required");
                    }
                    else if (txtDob.Value == "")
                    {
                        baseClass.PopAlert(this, "Date of Birth is required");
                    }
                    else
                    {
                        SaveUser();

                    }
                }
                else if (ddltype.Text == "Garage")
                {
                    if (txtGarageName.Value == "")
                    {
                        baseClass.PopAlert(this, "Garage name is required");
                    }
                    else
                    {
                        SaveUser();
                    }
                }

            }
            catch (Exception ex)
            {

            }


        }

        private void SaveUser()
        {
            userListModel.UserId = Convert.ToInt32(baseClass.GenerateId("SELECT MAX(UserId) FROM UserList"));
            userListModel.Name = txtName.Value;
            userListModel.Email = txtEmail.Value;
            userListModel.MobileNo = txtMobile.Value;
            userListModel.UserType = ddltype.Text;
            userListModel.Gender = ddlGender.Text;
            userListModel.Dob = txtDob.Value;
            userListModel.GarageName = txtGarageName.Value;
            userListModel.District = Convert.ToInt32(ddlDistrict.SelectedValue);
            userListModel.Thana = Convert.ToInt32(ddlThana.SelectedValue);
            userListModel.Location = Convert.ToInt32(ddlLocation.SelectedValue);
            userListModel.Address = txtAddress.Text;
            userListModel.Password = txtNewPass.Value;
            userListModel.Lat = lat.Text;
            userListModel.Long = longL.Text;
            if (fileImage.HasFile)
            {
                string imagePath = Server.MapPath("/Photos/") + userListModel.UserId + ".png";
                fileImage.PostedFile.SaveAs(imagePath);
                userListModel.Picture = "/Photos/" + userListModel.UserId + ".png";
            }
            else
            {
                userListModel.Picture = "";
            }
            if (ddltype.Text == "Customer")
            {
                userListModel.Status = "A";
            }
            else
            {
                userListModel.Status = "P";
            }
            userListModel.Intime = baseClass.Date();
            bool ans = userListGateway.Insert(userListModel);
            if (ans)
            {

                if (ddltype.Text == "Customer")
                {
                    bool ans1 = baseClass.SendEmail("carservicecenter02@gmail.com", txtEmail.Value, "Registration",
                    "<h1>Hello User,</h1><br/>Your account has been registered successfully.<br/><b>Thank you</b>",
                    "carservice12345");
                    if (ans1)
                    {
                        baseClass.PopAlert(this, "Registered Successfully ✔");
                    }
                    else
                    {
                        baseClass.PopAlert(this, "Registered Successfully ✔");
                    }

                }
                else
                {
                    bool ans1 = baseClass.SendEmail("Carservicecenter02@gmail.com", txtEmail.Value, "Registration",
                    "<h1>Hello User,</h1><br/>Your account has been registered successfully, Please wait for admin approval. We will contact with you soon.<br/><b>Thank you</b>",
                    "carservice12345");
                    if (ans1)
                    {
                        baseClass.PopAlert(this, "Registered Successful, Wait for admin approval");
                    }
                    else
                        baseClass.PopAlert(this, "Registered Successful, Wait for admin approval");

                }
                Refresh();
            }
            else
            {
                baseClass.PopAlert(this, "Registration failed");
            }

        }

        private void Refresh()
        {
            txtName.Value = txtEmail.Value = txtMobile.Value = txtDob.Value = txtGarageName.Value = txtAddress.Text = "";
            ddltype.SelectedIndex = ddlDistrict.SelectedIndex = ddlThana.SelectedIndex = ddlGender.SelectedIndex = ddlLocation.SelectedIndex = -1;
        }
        protected void ddlDistrict_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            baseClass.BindDropDown(ddlThana, "Thana", $"SELECT Thana NAME, Id FROM upazila WHERE DistrictId='{ddlDistrict.SelectedValue}' ORDER BY NAME ASC");
            ddlThana.Focus();
        }

        protected void ddlThana_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            baseClass.BindDropDown(ddlLocation, "Location", $"SELECT LocationName NAME, Id FROM Location WHERE ThanaId='{ddlThana.SelectedValue}' ORDER BY NAME ASC");
            ddlLocation.Focus();
        }
    }
}