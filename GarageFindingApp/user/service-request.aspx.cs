using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GarageFindingApp.DAL;
using GarageFindingApp.DAL.Gateway;
using GarageFindingApp.DAL.Model;

namespace GarageFindingApp.user
{
    public partial class service_request : System.Web.UI.Page
    {
        private BaseClass baseClass;
        private BookServiceModel bookServiceModel;
        private BookServiceGateway bookServiceGateway;
        public service_request()
        {
            baseClass = BaseClass.GetInstance();
            bookServiceModel = BookServiceModel.GetInstance();
            bookServiceGateway = BookServiceGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load();
            }
        }

        private void Load()
        {
            baseClass.LoadGrid(gridbook, $@"SELECT        BookService.BookId, BookService.GarageId, BookService.CustId, BookService.BookingDate, BookService.BookingTime, BookService.BkashNo, BookService.TransactionNo, BookService.Amount, BookService.Status, 
                         BookService.Intime, BookService.TokenId, A.GarageName AS GarageName, UserList.Name AS CustName, A.Picture AS GaragePic, UserList.Picture AS CustPicture
FROM            BookService INNER JOIN
                         UserList AS A ON BookService.GarageId = A.UserId INNER JOIN
                         UserList ON BookService.CustId = UserList.UserId WHERE BookService.CustId='{baseClass.UserIdCookie()}' AND (BookService.Status='R' OR BookService.Status='A') ORDER BY BookService.BookId DESC");
        }
        protected void gridbook_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkRemove = (LinkButton)e.Row.FindControl("lnkRemove");
                LinkButton lnkRating = (LinkButton)e.Row.FindControl("lnkRating");
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                HiddenField status = (HiddenField)e.Row.FindControl("status");

                if (status.Value == "I")
                {
                    lblStatus.Text = "Pending";
                    lblStatus.ForeColor = Color.Red;
                    lnkRemove.Visible = true;
                    lnkRating.Visible = false;

                }
                else if (status.Value == "A")
                {
                    lblStatus.Text = "Accepted";
                    lblStatus.ForeColor = Color.Green;
                    lnkRemove.Visible = false;
                    lnkRating.Visible = true;
                }
                else if (status.Value == "R")
                {
                    lblStatus.Text = "Rejected";
                    lblStatus.ForeColor = Color.Red;
                    lnkRemove.Visible = false;
                    lnkRating.Visible = false;
                }
            }
        }

        protected void gridbook_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridbook.PageIndex = e.NewPageIndex;
            Load();
        }

        protected void lnkRemove_OnClick(object sender, EventArgs e)
        {
            LinkButton lnkInactive = (LinkButton)sender;
            HiddenField BookId = (HiddenField)lnkInactive.Parent.FindControl("BookId");
            bookServiceModel.BookId = Convert.ToInt32(BookId.Value);
            bool ans = bookServiceGateway.Delete(bookServiceModel);
            if (ans)
            {
                baseClass.PopAlert(this, "Remove successfully");
                Load();
            }
        }

        protected void txtDate_OnTextChanged(object sender, EventArgs e)
        {
            Search();
        }

        protected void chkPending_OnCheckedChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            if (chkPending.Checked)
            {
                if (txtDate.Text == "")
                {
                    baseClass.LoadGrid(gridbook, $@"SELECT        BookService.BookId, BookService.GarageId, BookService.CustId, BookService.BookingDate, BookService.BookingTime, BookService.BkashNo, BookService.TransactionNo, BookService.Amount, BookService.Status, 
                         BookService.Intime, BookService.TokenId, A.GarageName AS GarageName, UserList.Name AS CustName, A.Picture AS GaragePic, UserList.Picture AS CustPicture
FROM            BookService INNER JOIN
                         UserList AS A ON BookService.GarageId = A.UserId INNER JOIN
                         UserList ON BookService.CustId = UserList.UserId WHERE BookService.CustId='{baseClass.UserIdCookie()}' AND BookService.Status='I' ORDER BY BookService.BookId DESC");
                }
                else
                {
                    baseClass.LoadGrid(gridbook, $@"SELECT        BookService.BookId, BookService.GarageId, BookService.CustId, BookService.BookingDate, BookService.BookingTime, BookService.BkashNo, BookService.TransactionNo, BookService.Amount, BookService.Status, 
                         BookService.Intime, BookService.TokenId, A.GarageName AS GarageName, UserList.Name AS CustName, A.Picture AS GaragePic, UserList.Picture AS CustPicture
FROM            BookService INNER JOIN
                         UserList AS A ON BookService.GarageId = A.UserId INNER JOIN
                         UserList ON BookService.CustId = UserList.UserId WHERE BookService.CustId='{baseClass.UserIdCookie()}' AND BookService.Status='I' AND BookService.BookingDate='{txtDate.Text}' ORDER BY BookService.BookId DESC");
                }
            }
            else
            {
                if (txtDate.Text == "")
                {
                    baseClass.LoadGrid(gridbook, $@"SELECT        BookService.BookId, BookService.GarageId, BookService.CustId, BookService.BookingDate, BookService.BookingTime, BookService.BkashNo, BookService.TransactionNo, BookService.Amount, BookService.Status, 
                         BookService.Intime, BookService.TokenId, A.GarageName AS GarageName, UserList.Name AS CustName, A.Picture AS GaragePic, UserList.Picture AS CustPicture
FROM            BookService INNER JOIN
                         UserList AS A ON BookService.GarageId = A.UserId INNER JOIN
                         UserList ON BookService.CustId = UserList.UserId WHERE BookService.CustId='{baseClass.UserIdCookie()}' AND (BookService.Status='R' OR BookService.Status='A') ORDER BY BookService.BookId DESC");
                }
                else
                {
                    baseClass.LoadGrid(gridbook, $@"SELECT        BookService.BookId, BookService.GarageId, BookService.CustId, BookService.BookingDate, BookService.BookingTime, BookService.BkashNo, BookService.TransactionNo, BookService.Amount, BookService.Status, 
                         BookService.Intime, BookService.TokenId, A.GarageName AS GarageName, UserList.Name AS CustName, A.Picture AS GaragePic, UserList.Picture AS CustPicture
FROM            BookService INNER JOIN
                         UserList AS A ON BookService.GarageId = A.UserId INNER JOIN
                         UserList ON BookService.CustId = UserList.UserId WHERE BookService.CustId='{baseClass.UserIdCookie()}' AND (BookService.Status='R' OR BookService.Status='A') AND BookService.BookingDate='{txtDate.Text}' ORDER BY BookService.BookId DESC");
                }
            }
        }

        protected void lnkRating_OnClick(object sender, EventArgs e)
        {
            LinkButton lnkRate = (LinkButton)sender;
            HiddenField garageId = (HiddenField)lnkRate.Parent.FindControl("GarageId");
            if (baseClass.UserIdCookie() == null)
            {
                baseClass.PopAlert(this, "You must log in first to submit review");
            }
            else
            {
                Response.Redirect("/user/rate-garage.aspx?id=" + garageId.Value + "");
            }
        }
    }
}