using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GarageFindingApp.DAL;
using GarageFindingApp.DAL.Gateway;
using GarageFindingApp.DAL.Model;

namespace GarageFindingApp.user
{
    public partial class book_service : System.Web.UI.Page
    {
        Random _random = new Random();
        private BaseClass baseClass;
        private BookServiceModel bookServiceModel;
        private BookServiceGateway bookServiceGateway;
        public book_service()
        {
            baseClass = BaseClass.GetInstance();
            bookServiceModel = BookServiceModel.GetInstance();
            bookServiceGateway = BookServiceGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("/user/Default.aspx");
                }
                lblToken.Text = RandomString(8, false);
                txtGarageName.Value =
                    baseClass.IsExist($"SELECT GARAGENAME FROM USERLIST WHERE UserId='{Request.QueryString["id"]}'");
            }
        }
        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        protected void btnBook_OnClick(object sender, EventArgs e)
        {
            if (txtDate.Value == "")
            {
                baseClass.PopAlert(this, "Booking date is required");
            }
            else if (txtTime.Value == "")
            {
                baseClass.PopAlert(this, "Booking Time is required");
            }
            else if (txtBkashNo.Value == "")
            {
                baseClass.PopAlert(this, "Bkash no is required");
            }
            else if (txtTransNo.Value == "")
            {
                baseClass.PopAlert(this, "Transaction no is required");
            }
            else if (txtAmount.Value == "")
            {
                baseClass.PopAlert(this, "Amount is required");
            }
            else if (IsBookExist(Request.QueryString["id"].ToString(), baseClass.UserIdCookie(), txtDate.Value))
            {
                baseClass.PopAlert(this, "You have already booked for service on " + txtDate.Value + ".");
            }
            else
            {
                lblwarning.Text = "Please wait request is sending to garage account.";
                lblwarning.ForeColor = Color.Red;
                bookServiceModel.BookId = Convert.ToInt32(baseClass.GenerateId("SELECT MAX(BookId) FROM BookService"));
                bookServiceModel.GarageId = Convert.ToInt32(Request.QueryString["id"].ToString());
                bookServiceModel.CustId = Convert.ToInt32(baseClass.UserIdCookie());
                bookServiceModel.BookingDate = txtDate.Value;
                bookServiceModel.BookingTime = baseClass.TimeConvert(txtTime.Value);
                bookServiceModel.BkashNo = txtBkashNo.Value;
                bookServiceModel.TransactionNo = txtTransNo.Value;
                bookServiceModel.Amount = Convert.ToDouble(txtAmount.Value);
                bookServiceModel.TokenId = lblToken.Text;
                bookServiceModel.Status = "I";
                bookServiceModel.Intime = baseClass.Date();
                string garageEmail =
                    baseClass.IsExist($"SELECT Email FROM USERLIST WHERE UserId='{Request.QueryString["id"]}'");
               
                bool ans = bookServiceGateway.BookService(bookServiceModel);
                if (ans)
                {
                    
                    bool ans1 = baseClass.SendEmail("carservicecenter02@gmail.com", garageEmail, "Booking Service Request",
                 "<h1>Hello Garage Owner,</h1><br/>You have a car service booking request for " + txtDate.Value + " " + txtTime.Value + ".<br/> Reference Id:" + bookServiceModel.TokenId + ",<br/>Bkash No.: " + bookServiceModel.BkashNo + "<br/>Transaction No.:" + txtTransNo.Value + ",<br/>Amount:" + bookServiceModel.Amount + ".<br/>Please check this request as soon as possible.<br/><b>Thank you</b>",
                 "carservice12345");
                    if (ans1)
                    {
                        bool ans2 = baseClass.SendEmail("carservicecenter02@gmail.com", baseClass.EmailCookie(), "Booking Service Request",
                "<h1>Hello User,</h1><br/>You have sent a car service booking request for " + txtDate.Value + " " + txtTime.Value + ".<br/> Reference Id:" + bookServiceModel.TokenId + ",<br/>Bkash No.: " + bookServiceModel.BkashNo + "<br/>Transaction No.:" + txtTransNo.Value + ",<br/>Amount:" + bookServiceModel.Amount + ".<br/>Please wait for garage approval.<br/><b>Thank you</b>",
                "carservice12345");
                        if (ans2)
                        {
                            lblwarning.Text = "";
                            ScriptManager.RegisterStartupScript(this,Page.GetType(),"script", "alert('Book request sent to garage. Please wait for garage approval.');setTimeout(function(){location.replace('/user/Default.aspx');},1500);", true);

                        }
                        else
                            baseClass.PopAlert(this, "Failed to sent notification to user through email.Please check your email security settings.");

                    }
                    else
                        baseClass.PopAlert(this, "Failed to sent notification to user through email.Please check your email security settings.");

                }
                else
                {
                    baseClass.PopAlert(this, "Failed to book service.");
                }
            }
        }

        private bool IsBookExist(string garageId, string custId, string bookingDate)
        {
            bool ans = false;
            string x =
                baseClass.IsExist(
                    $"SELECT BookId FROM BookService WHERE GarageId='{garageId}' AND CustId='{custId}' AND BookingDate='{bookingDate}' AND Status!='R'");
            if (x != "")
            {
                ans = true;
            }
            return ans;
        }

        
    }
}