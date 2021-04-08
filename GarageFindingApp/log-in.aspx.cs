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
    public partial class log_in : System.Web.UI.Page
    {
        private BaseClass baseClass;
        private UserListModel userListModel;
        private UserListGateway userListGateway;
        private HttpCookie cookie = HttpContext.Current.Request.Cookies["GarageInfo"];
        public log_in()
        {
            baseClass = BaseClass.GetInstance();
            userListModel = UserListModel.GetInstance();
            userListGateway = UserListGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (cookie != null)
                {
                    if (cookie["Type"] == "Customer")
                    {
                        Response.Redirect("/user/Default.aspx");
                    }
                    else if (cookie["Type"] == "Garage")
                    {
                        Response.Redirect("/user/add-service.aspx");
                    }
                    else if (cookie["Type"] == "Admin" || cookie["Type"] == "Super Admin")
                    {
                        Response.Redirect("/User/add-location.aspx");
                    }
                   
                }
                
                txtEmail.Focus();
            }
        }

        protected void btnLogin_OnServerClick(object sender, EventArgs e)
        {
            if (txtEmail.Value == "")
            {
                baseClass.PopAlert(this, "Email is required");
            }
            else if (!baseClass.EmailValidation(txtEmail.Value))
            {
                baseClass.PopAlert(this, "Enter valid email");
            }
            else if (txtPass.Value == "")
            {
                baseClass.PopAlert(this, "Password is required");
            }
            else
            {
                string password =
                    baseClass.IsExist(
                        $"SELECT Password FROM UserList WHERE Email='{txtEmail.Value}' AND Password='{txtPass.Value}' AND Status='A' COLLATE Latin1_General_CS_AI");
                string passwordAdmin =
                    baseClass.IsExist(
                        $"SELECT Password FROM Admin WHERE Email='{txtEmail.Value}' AND Password='{txtPass.Value}' AND Status='A' COLLATE Latin1_General_CS_AI");
                if (password == txtPass.Value.Trim())
                {
                    HttpCookie cookie = BaseClass.CreateCookie();
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                    cookie["Name"] = baseClass.IsExist($"SELECT Name FROM UserList WHERE Email='{txtEmail.Value}'");
                    cookie["Type"] = baseClass.IsExist($"SELECT UserType FROM UserList WHERE Email='{txtEmail.Value}'");
                    cookie["UserId"] = baseClass.IsExist($"SELECT UserId FROM UserList WHERE Email='{txtEmail.Value}'");
                    cookie["Email"] = baseClass.IsExist($"SELECT Email FROM UserList WHERE Email='{txtEmail.Value}'");
                    cookie["Picture"] = baseClass.IsExist($"SELECT Picture FROM UserList WHERE Email='{txtEmail.Value}'");
                    cookie["Mobile"] = baseClass.IsExist($"SELECT MobileNo FROM UserList WHERE Email='{txtEmail.Value}'");
                    cookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(cookie);
                    if (cookie["Type"] == "Customer")
                    {
                        Response.Redirect("/user/Default.aspx");
                    }
                    else if (cookie["Type"] == "Garage")
                    {
                        Response.Redirect("/user/add-service.aspx");
                    }
                }
                else if (passwordAdmin == txtPass.Value.Trim())
                {
                    HttpCookie cookie = BaseClass.CreateCookie();
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                    cookie["Name"] = baseClass.IsExist($"SELECT Name FROM Admin WHERE Email='{txtEmail.Value}'");
                    cookie["Type"] = baseClass.IsExist($"SELECT Type FROM Admin WHERE Email='{txtEmail.Value}'");
                    cookie["UserId"] = baseClass.IsExist($"SELECT AdminId FROM Admin WHERE Email='{txtEmail.Value}'");
                    cookie["Email"] = baseClass.IsExist($"SELECT Email FROM Admin WHERE Email='{txtEmail.Value}'");
                    cookie["Picture"] = baseClass.IsExist($"SELECT Picture FROM Admin WHERE Email='{txtEmail.Value}'");
                    cookie["Mobile"] = baseClass.IsExist($"SELECT MobileNo FROM Admin WHERE Email='{txtEmail.Value}'");
                    cookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(cookie);
                    if (cookie["Type"] == "Admin" || cookie["Type"] == "Super Admin")
                    {
                        Response.Redirect("/User/add-location.aspx");
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "alert('Email & Password mismatch')", true);
                }
            }
        }

        protected void lnkForgot_OnClick(object sender, EventArgs e)
        {
            if (txtEmail.Value == "")
            {
                baseClass.PopAlert(this, "Type your email first, then click on forgot password");
            }
            else
            {
                string pass = baseClass.IsExist($"SELECT Password FROM UserList WHERE Email='{txtEmail.Value}'");
                if (pass == "")
                {
                    baseClass.PopAlert(this, "Email id does not exist");

                }
                else
                {
                    bool ans = baseClass.SendEmail("Carservicecenter02@gmail.com", txtEmail.Value, "Password", "<h3>Hello User,</h3><br/>Your Password is: " + pass, "carservice12345");
                    if (ans)
                    {
                        baseClass.PopAlert(this, "Password has been sent to your email address.");
                    }
                }

            }
        }
    }
}