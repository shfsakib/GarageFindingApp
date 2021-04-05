using System;
using System.Collections.Generic;
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
    public partial class AddLocation : System.Web.UI.Page
    {
        private BaseClass baseClass;
        private LocationModel locationModel;
        private LocationGateway locationGateway;

        public AddLocation()
        {
            baseClass = BaseClass.GetInstance();
            locationModel = LocationModel.GetInstance();
            locationGateway = LocationGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                baseClass.AdminType(this,"Super Admin","Admin");
                LoadLocation();

            }
        }
        private void LoadLocation()
        {
            baseClass.LoadGrid(locationGridView, @"SELECT        Location.Id, Location.LocationName, Location.ThanaId, Location.Intime, Upazila.Thana
FROM            Location INNER JOIN
                         Upazila ON Location.ThanaId = Upazila.Id
ORDER BY Location.Id DESC");

        }
        protected void locationGridView_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            locationGridView.PageIndex = e.NewPageIndex;
            LoadLocation();
        }
        private bool IsLocationExist(string name, string thanaId, string id)
        {
            bool ans = false;
            string x = baseClass.IsExist($"SELECT LocationName FROM Location WHERE LocationName='{name}' AND ThanaId='{thanaId}' AND Id!='{id}'");
            if (x != "")
            {
                ans = true;
            }
            return ans;
        }
        protected void locationGridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                HtmlInputText locationFooterTextBox = (HtmlInputText)locationGridView.HeaderRow.FindControl("locationFooterTextBox");
                HiddenField idHiddenField = (HiddenField)locationGridView.HeaderRow.FindControl("idHiddenField");
                DropDownList ddlThanaFooter = (DropDownList)locationGridView.HeaderRow.FindControl("ddlThanaFooter");
                if (locationFooterTextBox.Value.Trim() == "")
                    baseClass.PopAlert(this, "location Name is Required");
                else if (IsLocationExist(locationFooterTextBox.Value.Trim(), ddlThanaFooter.SelectedValue, idHiddenField.Value))
                    baseClass.PopAlert(this, "location Name Already Exist");
                else if (ddlThanaFooter.Text.Trim() == "--THANA--")
                    baseClass.PopAlert(this, "Thana is required");
                else
                {
                    locationModel.LocationName = locationFooterTextBox.Value.Trim();
                    locationModel.Intime = baseClass.Date();
                    locationModel.ThanaId = Convert.ToInt32(ddlThanaFooter.SelectedValue.Trim());
                    bool a = locationGateway.Insert(locationModel);
                    if (a)
                    {
                        LoadLocation();
                        baseClass.PopAlert(this, "Successfully inserted");
                    }
                    else
                    {
                        baseClass.PopAlert(this, "Insert Failed");
                    }
                }
            }
        }

        protected void locationGridView_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            locationGridView.EditIndex = e.NewEditIndex;
            LoadLocation();
        }

        protected void locationGridView_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            HtmlInputText locationTextBox = (HtmlInputText)locationGridView.Rows[e.RowIndex].FindControl("locationTextBox");
            HiddenField idHiddenField = (HiddenField)locationGridView.Rows[e.RowIndex].FindControl("idHiddenFieldEdit");
            DropDownList ddlThana = (DropDownList)locationGridView.Rows[e.RowIndex].FindControl("ddlThana");
            if (locationTextBox.Value.Trim() == "")
                baseClass.PopAlert(this, "location Name Required");
            else if (IsLocationExist(locationTextBox.Value.Trim(), ddlThana.SelectedValue, idHiddenField.Value))
                baseClass.PopAlert(this, "location Name Already Exist");
            else if (ddlThana.Text.Trim() == "--THANA--")
                baseClass.PopAlert(this, "Thana is Required");
            else
            {
                locationModel.LocationName = locationTextBox.Value.Trim();
                locationModel.Id = Convert.ToInt32(idHiddenField.Value);
                locationModel.ThanaId = Convert.ToInt32(ddlThana.SelectedValue.Trim());
                bool a = locationGateway.Update(locationModel);
                if (a)
                {
                    baseClass.PopAlert(this, "Updated successfuly");
                    locationGridView.EditIndex = -1;
                    LoadLocation();
                }
                else
                {
                    baseClass.PopAlert(this, "Update Failed");
                }
            }
        }

        protected void locationGridView_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            locationGridView.EditIndex = -1;
            LoadLocation();
        }

        protected void locationGridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                DropDownList ddlThanaFooter = (DropDownList)e.Row.FindControl("ddlThanaFooter");
                DropDownList ddlThana = (DropDownList)e.Row.FindControl("ddlThana");
                baseClass.BindDropDown(ddlThanaFooter, "Thana", @"SELECT Thana NAME, ID FROM upazila ORDER BY NAME ASC");
                baseClass.BindDropDown(ddlThana, "Thana", @"SELECT Thana NAME, ID FROM upazila ORDER BY NAME ASC");

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                DropDownList ddlThanaFooter = (DropDownList)e.Row.FindControl("ddlThanaFooter");
                DropDownList ddlThana = (DropDownList)e.Row.FindControl("ddlThana");
                HiddenField thanaId = (HiddenField)e.Row.FindControl("thanaId");
                baseClass.BindDropDown(ddlThanaFooter, "Thana", @"SELECT Thana NAME, ID FROM upazila ORDER BY NAME ASC");
                baseClass.BindDropDown(ddlThana, "Thana", @"SELECT Thana NAME, ID FROM upazila ORDER BY NAME ASC");
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    ddlThana.Items.FindByText(thanaId.Value).Selected = true;
                }
            }
        }
    }
}