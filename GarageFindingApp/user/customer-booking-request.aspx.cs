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
    public partial class customer_booking_request : System.Web.UI.Page
    {
        private BaseClass baseClass;
        private BookServiceModel bookServiceModel;
        private BookServiceGateway bookServiceGateway;
        public customer_booking_request()
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
                         UserList ON BookService.CustId = UserList.UserId WHERE BookService.GarageId='{baseClass.UserIdCookie()}' AND BookService.Status!='R' AND BookService.Status='I' ORDER BY BookService.BookId DESC");
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
                         UserList ON BookService.CustId = UserList.UserId WHERE BookService.GarageId='{baseClass.UserIdCookie()}' AND (BookService.Status='R' OR BookService.Status='A') ORDER BY BookService.BookId DESC");
                }
                else
                {
                    baseClass.LoadGrid(gridbook, $@"SELECT        BookService.BookId, BookService.GarageId, BookService.CustId, BookService.BookingDate, BookService.BookingTime, BookService.BkashNo, BookService.TransactionNo, BookService.Amount, BookService.Status, 
                         BookService.Intime, BookService.TokenId, A.GarageName AS GarageName, UserList.Name AS CustName, A.Picture AS GaragePic, UserList.Picture AS CustPicture
FROM            BookService INNER JOIN
                         UserList AS A ON BookService.GarageId = A.UserId INNER JOIN
                         UserList ON BookService.CustId = UserList.UserId WHERE BookService.GarageId='{baseClass.UserIdCookie()}' AND (BookService.Status='R' OR BookService.Status='A') AND BookService.BookingDate='{txtDate.Text}' ORDER BY BookService.BookId DESC");
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
                         UserList ON BookService.CustId = UserList.UserId WHERE BookService.GarageId='{baseClass.UserIdCookie()}' AND BookService.Status='I' ORDER BY BookService.BookId DESC");
                }
                else
                {
                    baseClass.LoadGrid(gridbook, $@"SELECT        BookService.BookId, BookService.GarageId, BookService.CustId, BookService.BookingDate, BookService.BookingTime, BookService.BkashNo, BookService.TransactionNo, BookService.Amount, BookService.Status, 
                         BookService.Intime, BookService.TokenId, A.GarageName AS GarageName, UserList.Name AS CustName, A.Picture AS GaragePic, UserList.Picture AS CustPicture
FROM            BookService INNER JOIN
                         UserList AS A ON BookService.GarageId = A.UserId INNER JOIN
                         UserList ON BookService.CustId = UserList.UserId WHERE BookService.GarageId='{baseClass.UserIdCookie()}' AND BookService.Status='I' AND BookService.BookingDate='{txtDate.Text}' ORDER BY BookService.BookId DESC");
                }
            }
        }

        protected void gridbook_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkRemove = (LinkButton)e.Row.FindControl("lnkRemove");
                LinkButton lnkAccept = (LinkButton)e.Row.FindControl("lnkAccept");
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                HiddenField status = (HiddenField)e.Row.FindControl("status");

                if (status.Value == "I")
                {
                    lblStatus.Text = "Pending";
                    lblStatus.ForeColor = Color.Red;
                    lnkRemove.Visible = true;
                    lnkAccept.Visible = true;

                }
                else if (status.Value == "A")
                {
                    lblStatus.Text = "Accepted";
                    lblStatus.ForeColor = Color.Green;
                    lnkRemove.Visible = false;
                    lnkAccept.Visible = false;
                }
                else if (status.Value == "R")
                {
                    lblStatus.Text = "Rejected";
                    lblStatus.ForeColor = Color.Red;
                    lnkRemove.Visible = false;
                    lnkAccept.Visible = false;
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
            HiddenField CustId = (HiddenField)lnkInactive.Parent.FindControl("CustId");
            string email = baseClass.IsExist($"SELECT Email FROM UserList WHERE UserId='{CustId.Value}'");
            bookServiceModel.BookId = Convert.ToInt32(BookId.Value);
            bookServiceModel.Status = "R";
            bool ans = bookServiceGateway.Update(bookServiceModel);
            if (ans)
            {
                bool ans1 = baseClass.SendEmail("carservicecenter02@gmail.com", baseClass.EmailCookie(),
                    "Booking Service Request",
                    "<h1>Hello Garage Owner,</h1><br/>You have rejected a booking request from " + email +
                    ".<br/><b>Thank you</b>",
                    "carservice12345");
                if (ans1)
                {
                    bool ans2 = baseClass.SendEmail("carservicecenter02@gmail.com", email, "Booking Service Request",
                        "<h1>Hello User,</h1><br/>Your booking service request to " + baseClass.EmailCookie() +
                        " has been rejected by garage. We are sorry for this,Please collect your advance from garage. For more info contact us.<br/><b>Thank you</b>",
                        "carservice12345");
                    if (ans2)
                    {
                        baseClass.PopAlert(this, "Rejected successfully");
                        Load();
                    }
                    else
                    {
                        Load(); baseClass.PopAlert(this, "Failed to sent email");
                    }

                }
                else
                    baseClass.PopAlert(this, "Failed to sent email");

            }
            else
            {
                baseClass.PopAlert(this, "Failed to reject request");
            }
        }

        protected void lnkAccept_OnClick(object sender, EventArgs e)
        {
            LinkButton lnkInactive = (LinkButton)sender;
            HiddenField BookId = (HiddenField)lnkInactive.Parent.FindControl("BookId");
            HiddenField CustId = (HiddenField)lnkInactive.Parent.FindControl("CustId");
            string email = baseClass.IsExist($"SELECT Email FROM UserList WHERE UserId='{CustId.Value}'");
            bookServiceModel.BookId = Convert.ToInt32(BookId.Value);
            bookServiceModel.Status = "A";
            bool ans = bookServiceGateway.Update(bookServiceModel);
            if (ans)
            {
                bool ans1 = baseClass.SendEmail("carservicecenter02@gmail.com", baseClass.EmailCookie(),
                    "Booking Service Request",
                    "<h1>Hello Garage Owner,</h1><br/>You have accepted a booking request from " + email +
                    ".<br/><b>Thank you</b>",
                    "carservice12345");
                if (ans1)
                {
                    bool ans2 = baseClass.SendEmail("carservicecenter02@gmail.com", email, "Booking Service Request",
                        "<h1>Hello User,</h1><br/>Your booking service request to " + baseClass.EmailCookie() +
                        " has been accepted by garage. For more info contact us.<br/><b>Thank you</b>",
                        "carservice12345");
                    if (ans2)
                    {
                        baseClass.PopAlert(this, "Accepted successfully");
                        Load();
                    }
                    else
                    {
                        Load();
                        baseClass.PopAlert(this, "Failed to sent email");
                    }
                        
                }
                else
                    baseClass.PopAlert(this, "Failed to sent email");

            }
            else
            {
                baseClass.PopAlert(this, "Failed to accept request");
            }
        }
    }
}