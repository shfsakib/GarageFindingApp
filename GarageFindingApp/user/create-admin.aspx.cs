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
    public partial class create_admin : System.Web.UI.Page
    {
        private BaseClass baseClass;
        private AdminModel adminModel;
        private AdminGateway adminGateway;

        public create_admin()
        {
            baseClass = BaseClass.GetInstance();
            adminModel = AdminModel.GetInstance();
            adminGateway = AdminGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                baseClass.AdminType(this, "Super Admin", "Admin");

                txtName.Focus();
            }
        }

        protected void createButton_OnClick(object sender, EventArgs e)
        {
            adminModel.Name = txtName.Value;
            adminModel.Email = txtEmail.Value;
            adminModel.MobileNo = txtMobileNo.Value;
            adminModel.Gender = ddlGender.Text;
            adminModel.Dob = txtDob.Text;
            if (fileImage.HasFile)
            {
                string imagePath = Server.MapPath("/Photos/") + "admin" + fileImage.FileName;
                fileImage.PostedFile.SaveAs(imagePath);
                adminModel.Picture = "/Photos/" + "admin" + fileImage.FileName;
            }
            else
            {
                adminModel.Picture = "";
            }
            adminModel.Password = txtNewPass.Value;
            adminModel.Type = ddlType.Text;
            adminModel.Status = "A";
            adminModel.InTime = baseClass.Date();
            bool ans = adminGateway.Insert(adminModel);
            if (ans)
            {
                Refresh();
                baseClass.PopAlert(this, "Admin created successfully");
            }
            else
            {
                baseClass.PopAlert(this, "Failed to create admin");
            }
        }

        private void Refresh()
        {
            txtName.Value = txtEmail.Value = txtMobileNo.Value = txtDob.Text = "";
            ddlGender.SelectedIndex = ddlType.SelectedIndex = -1;
        }
    }
}