using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GarageFindingApp.DAL;

namespace GarageFindingApp.user
{
    public partial class profile : System.Web.UI.Page
    {
        private BaseClass baseClass;

        public profile()
        {
            baseClass = BaseClass.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("/user/Default.aspx");
                }
                LoadProfile();
            }
        }

        private void LoadProfile()
        {
            profileImage.ImageUrl =
                baseClass.IsExist($"Select Picture FROM UserList WHERE UserId='{Request.QueryString["id"].ToString()}'");
            nameLabel.Text =
                baseClass.IsExist($"Select Name FROM UserList WHERE UserId='{Request.QueryString["id"].ToString()}'");
            callButton.HRef = "tel:" + baseClass.IsExist($"Select MobileNo FROM UserList WHERE UserId='{Request.QueryString["id"].ToString()}'");
            mailButton.HRef = "mailto:" + baseClass.IsExist($"Select Email FROM UserList WHERE UserId='{Request.QueryString["id"].ToString()}'");
            string type = baseClass.IsExist($"Select UserType FROM UserList WHERE UserId='{Request.QueryString["id"].ToString()}'");
            if (type == "Garage")
            {
                gridService.Visible = true;
                lblService.Visible = true;
            }
            else
            {
                gridService.Visible = lblService.Visible = false;
            }

            baseClass.LoadGrid(gridService, $"SELECT * FROM SERVICE WHERE GarageId='{Request.QueryString["id"].ToString()}' ORDER BY SERVICENAME ASC");
        }
    }
}