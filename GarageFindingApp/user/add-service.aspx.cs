using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using GarageFindingApp.DAL;
using GarageFindingApp.DAL.Gateway;
using GarageFindingApp.DAL.Model;

namespace GarageFindingApp.user
{
    public partial class add_service : System.Web.UI.Page
    {
        private BaseClass baseClass;
        private ServiceModel serviceModel;
        private ServiceGateway serviceGateway;

        public add_service()
        {
            baseClass = BaseClass.GetInstance();
            serviceModel = ServiceModel.GetInstance();
            serviceGateway = ServiceGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               baseClass.CheckTypeCookie(this,"Garage");
               LoadService();
            }
        }
        private void LoadService()
        {
            baseClass.LoadGrid(serviceGridView, @"SELECT * FROM Service ORDER BY Id DESC");

        }
        protected void serviceGridView_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            serviceGridView.PageIndex = e.NewPageIndex;
            LoadService();
        }
        private bool IsServiceExist(string name, string garageId, string id)
        {
            bool ans = false;
            string x = baseClass.IsExist($"SELECT ServiceName FROM Service WHERE ServiceName='{name}' AND GarageId!='{garageId}' AND Id!='{id}'");
            if (x != "")
            {
                ans = true;
            }
            return ans;
        }
        protected void serviceGridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                HtmlInputText serviceFooterTextBox = (HtmlInputText)serviceGridView.HeaderRow.FindControl("serviceFooterTextBox");
                HtmlInputText priceFooterTextBox = (HtmlInputText)serviceGridView.HeaderRow.FindControl("priceFooterTextBox");
                HiddenField idHiddenField = (HiddenField)serviceGridView.HeaderRow.FindControl("idHiddenField");
                if (serviceFooterTextBox.Value.Trim() == "")
                    baseClass.PopAlert(this, "service Name is Required");
                else if (IsServiceExist(serviceFooterTextBox.Value.Trim(), baseClass.UserIdCookie(), idHiddenField.Value))
                    baseClass.PopAlert(this, "service Name Already Exist");
                else if (priceFooterTextBox.Value.Trim() == "")
                    baseClass.PopAlert(this, "Price is required");
                else
                {
                    serviceModel.ServiceName = serviceFooterTextBox.Value.Trim();
                    serviceModel.Intime = baseClass.Date();
                    serviceModel.Price = Convert.ToDouble(priceFooterTextBox.Value.Trim());
                    serviceModel.GarageId = Convert.ToInt32(baseClass.UserIdCookie());
                    bool a = serviceGateway.Insert(serviceModel);
                    if (a)
                    {
                        LoadService();
                        baseClass.PopAlert(this, "Successfully inserted");
                    }
                    else
                    {
                        baseClass.PopAlert(this, "Insert Failed");
                    }
                }
            }
        }

        protected void serviceGridView_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            serviceGridView.EditIndex = e.NewEditIndex;
            LoadService();
        }

        protected void serviceGridView_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            HtmlInputText serviceTextBox = (HtmlInputText)serviceGridView.Rows[e.RowIndex].FindControl("serviceTextBox");
            HiddenField idHiddenField = (HiddenField)serviceGridView.Rows[e.RowIndex].FindControl("idHiddenFieldEdit");
            HtmlInputText priceTextBox = (HtmlInputText)serviceGridView.Rows[e.RowIndex].FindControl("priceTextBox");

            if (serviceTextBox.Value.Trim() == "")
                baseClass.PopAlert(this, "service Name Required");
            else if (IsServiceExist(serviceTextBox.Value.Trim(), baseClass.UserIdCookie(), idHiddenField.Value))
                baseClass.PopAlert(this, "service Name Already Exist");
            else if (priceTextBox.Value.Trim() == "")
                baseClass.PopAlert(this, "Price is required");
            else
            { 
                serviceModel.ServiceName = serviceTextBox.Value.Trim();
                serviceModel.Price = Convert.ToDouble(priceTextBox.Value.Trim());
                serviceModel.Id = Convert.ToInt32(idHiddenField.Value);
                bool a = serviceGateway.Update(serviceModel);
                if (a)
                {
                    baseClass.PopAlert(this, "Updated successfuly");
                    serviceGridView.EditIndex = -1;
                    LoadService();
                }
                else
                {
                    baseClass.PopAlert(this, "Update Failed");
                }
            }
        }

        protected void serviceGridView_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            serviceGridView.EditIndex = -1;
            LoadService();
        }

        protected void serviceGridView_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)serviceGridView.Rows[e.RowIndex];
            HiddenField idHiddenField = (HiddenField)row.FindControl("idHidden"); 
            serviceModel.Id = Convert.ToInt32(idHiddenField.Value);
            bool a = serviceGateway.Delete(serviceModel);
            if (a)
            {
                baseClass.PopAlert(this, "Deleted successfuly");
                serviceGridView.EditIndex = -1;
                LoadService();
            }
            else
            {
                baseClass.PopAlert(this, "Deletion Failed");
            }
        }
    }
}