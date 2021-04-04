using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GarageFindingApp.DAL;

namespace GarageFindingApp.user
{
    public partial class monthly_charge : System.Web.UI.Page
    {
        private BaseClass baseClass;
        Random _random = new Random();

        public monthly_charge()
        {
            baseClass = BaseClass.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (baseClass.TypeCookie() == "Garage")
                {
                    txtEmail.ReadOnly = true;
                    lblToken.Text= RandomString(8, false);
                    txtEmail.Text = baseClass.EmailCookie();
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

        }
    }
}