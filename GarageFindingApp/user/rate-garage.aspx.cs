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
    public partial class rate_garage : System.Web.UI.Page
    {
        private BaseClass baseClass;
        private RatingModel ratingModel;
        private RatingGateway ratingGateway;

        public rate_garage()
        {
            baseClass = BaseClass.GetInstance();
            ratingModel = RatingModel.GetInstance();
            ratingGateway = RatingGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                baseClass.CheckTypeCookie(this, "Customer");

                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("/user/Default.aspx");
                }
                else
                {
                    txtGarage.Text =
                    baseClass.IsExist($"SELECT GarageName FROM UserList WHERE UserId='{Request.QueryString["id"]}'");
                }

            }
        }
        private bool IsRateExist(string rate)
        {
            bool result = false;
            string x = baseClass.IsExist($"SELECT RATE FROM Rating WHERE GarageId={Request.QueryString["id"].ToString()} AND UserId={baseClass.UserIdCookie()}");
            if (x != "")
                result = true;
            return result;
        }
        protected void btnRating_OnClick(object sender, EventArgs e)
        {
            if (Rating1.CurrentRating.ToString() == "")
            {
                baseClass.PopAlert(this,"You must give rating to submit review");
            }
            else if (Rating1.CurrentRating.ToString() == "0")
            {
                baseClass.PopAlert(this,"You must give rating to submit review");
            }
            else if (IsRateExist(Rating1.CurrentRating.ToString()))
            {
                ratingModel.GarageId = Convert.ToInt32(Request.QueryString["id"].ToString());
                ratingModel.UserId = Convert.ToInt32(baseClass.UserIdCookie());
                ratingModel.Rate = Rating1.CurrentRating;
                ratingModel.Review = txtReview.Text;
                bool ans2 = ratingGateway.UpdateRate(ratingModel);
                if (ans2)
                {
                    Response.Redirect("/user/Default.aspx");
                    Refresh();
                }
                else
                {
                    baseClass.PopAlert(this,"Rating submitted failed");
                }
            }
            else
            {
                ratingModel.GarageId = Convert.ToInt32(Request.QueryString["id"].ToString());
                ratingModel.UserId = Convert.ToInt32(baseClass.UserIdCookie());
                ratingModel.Rate = Rating1.CurrentRating;
                ratingModel.Review = txtReview.Text;
                ratingModel.InTime = baseClass.Date();
                bool ans = ratingGateway.InsertRating(ratingModel);
                if (ans)
                {
                    Response.Redirect("/user/Default.aspx");
                    Refresh();
                }
                else
                {
                    baseClass.PopAlert(this,"Rating submitted failed");

                }
            }
        }
        private void Refresh()
        {
            Rating1.CurrentRating = 0;
            txtReview.Text = "";
        }
    }
}