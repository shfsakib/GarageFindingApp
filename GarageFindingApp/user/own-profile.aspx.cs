using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GarageFindingApp.DAL;

namespace GarageFindingApp.user
{
    public partial class own_profile : System.Web.UI.Page
    {
        private BaseClass baseClass;

        public own_profile()
        {
            baseClass = BaseClass.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Request.QueryString["id"] == null)
                //{
                //    Response.Redirect("/user/Default.aspx");
                //}
                LoadProfile();
            }
        }
        private void LoadProfile()
        {
            profileImage.ImageUrl = baseClass.PictureCookie();
            nameLabel.Text = txtName.Text = baseClass.NameCookie();
            lblEmail.Text = baseClass.EmailCookie();
            lblMobile.Text =txtMobile.Text= baseClass.MobileCookie();
            lblGender.Text =
                ddlGender.Text =
                    baseClass.IsExist($"SELECT Gender FROM UserList WHERE UserId='{baseClass.UserIdCookie()}'");
            lblDob.Text=txtDob.Text=
                    baseClass.IsExist($"SELECT Dob FROM UserList WHERE UserId='{baseClass.UserIdCookie()}'");

            string type = baseClass.TypeCookie();
            if (type == "Garage")
            {
                gridService.Visible = garageDiv.Visible = true;
                lblService.Visible = true;
                userDiv.Visible = false;
                baseClass.LoadGrid(gridService, $"SELECT * FROM SERVICE WHERE GarageId='{Request.QueryString["id"].ToString()}' ORDER BY SERVICENAME ASC");

            }
            else
            {
                gridService.Visible = lblService.Visible = garageDiv.Visible = false;
            }

        }

    }
}