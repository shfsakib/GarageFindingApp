using System;
using System.Collections.Generic;
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
    public partial class monthly_charge : System.Web.UI.Page
    {
        private BaseClass baseClass;
        Random _random = new Random();
        private MonthlyChargeModel monthlyChargeModel;
        private MonthlyChargeGateway monthlyChargeGateway;
        public monthly_charge()
        {
            baseClass = BaseClass.GetInstance();
            monthlyChargeModel = MonthlyChargeModel.GetInstance();
            monthlyChargeGateway = MonthlyChargeGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (baseClass.TypeCookie() == "Garage")
                {
                    txtEmail.ReadOnly = true;
                    lblToken.Text = RandomString(8, false);
                    txtEmail.Text = baseClass.EmailCookie();
                    lblId.Text = baseClass.UserIdCookie();
                }
                else
                {
                    paymentMsg.Visible = false;
                }

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
        protected void btnPay_OnClick(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                baseClass.PopAlert(this, "Email is required");
            }
            else if (txtMonth.Value == "")
            {
                baseClass.PopAlert(this, "Month is required");
            }
            else if (txtBkashNo.Value == "")
            {
                baseClass.PopAlert(this, "Bkash no is required");
            }
            else if (txtTrans.Value == "")
            {
                baseClass.PopAlert(this, "Transaction no is required");
            }
            else if (txtAmount.Text == "")
            {
                baseClass.PopAlert(this, "Amount is required");
            }
            else
            {
                lblId.Text = baseClass.IsExist($@"SELECT UserId FROM UserList WHERE Email='{txtEmail.Text}'");
                monthlyChargeModel.GarageId = Convert.ToInt32(lblId.Text);
                monthlyChargeModel.Month = txtMonth.Value;
                monthlyChargeModel.BkashNo = txtBkashNo.Value;
                monthlyChargeModel.TransactionNo = txtTrans.Value;
                monthlyChargeModel.Amount = Convert.ToInt32(txtAmount.Text);
                monthlyChargeModel.PaymentTime = baseClass.Date();
                monthlyChargeModel.Status = "I";
                bool ans = monthlyChargeGateway.Insert(monthlyChargeModel);
                if (ans)
                {
                    bool ans1 = baseClass.SendEmail("carservicecenter02@gmail.com", txtEmail.Text, "Service Charge",
               "<h1>Hello Garage Owner,</h1><br/>Your monthly payment request has been added successfully. Please wait for admin verification.<br/><b>Thank you</b>",
               "carservice12345");
                    if (ans1)
                    {
                        baseClass.PopAlert(this, "Payment added successfully");
                    }
                    else
                        baseClass.PopAlert(this, "Payment added successfully");
                    Refresh();
                }
                else
                {
                    baseClass.PopAlert(this, "Failed to add payment");
                }
            }
        }

        protected void txtEmail_OnTextChanged(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                lblId.Text = baseClass.IsExist($@"SELECT UserId FROM UserList WHERE Email='{txtEmail.Text}'");
            }
        }

        private void Refresh()
        {
            txtMonth.Value = txtBkashNo.Value = txtTrans.Value = txtAmount.Text = "";
            if (baseClass.TypeCookie() == "Garage")
            {
                txtEmail.Text = "";
            }
        }
    }
}