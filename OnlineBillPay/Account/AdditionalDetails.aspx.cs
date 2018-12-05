using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using OnlineBillPay.Models;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace OnlineBillPay.Account
{
    public partial class AdditionalDetails : System.Web.UI.Page
    {

       


        protected void Page_Load(object sender, EventArgs e)
        {
            // Get the Signed in user
            Debug.WriteLine(User.Identity.GetUserId());

            // Set/Overload the UserId for the Select query that will render Addresses for User
            ObjectDataSource1.SelectParameters["UserId"].DefaultValue = User.Identity.GetUserId();
            // Set/Overload the UserId for the Select query that will render PhoneNumbers for User
            ObjectDataSource2.SelectParameters["UserId"].DefaultValue = User.Identity.GetUserId();

            // Generate List items for State DDL
            foreach (var state in new StateData().GetStates().ToList())
            {

                ddlRegion.Items.Add(new ListItem {  Text=state.Name.ToString(), Value=state.Code.ToString() });

            }

            // Generate list for Address Types
            foreach (var addressType in new AddressTypeData().GetAddressTypes().ToList())
            {

                ddlAddressType.Items.Add(new ListItem { Text = addressType.Type.ToString(), Value = addressType.Type.ToString() });

            }

            // Generate List items for State DDL
            foreach (var type in new PhoneTypeData().GetPhoneTypes().ToList())
            {

                ddlType.Items.Add(new ListItem { Text = type.Type.ToString(), Value = type.Type.ToString() });

            }

        }


        protected void CreateAddress_Click(object sender, EventArgs e)
        {

            Address newAddress = new Address();
            newAddress.AddressId = System.Guid.NewGuid().ToString().ToUpper();
            newAddress.UserId = User.Identity.GetUserId();
            newAddress.StreetAddress = txtStreetAddress.Text;
            newAddress.Type = ddlAddressType.SelectedValue;
            newAddress.Number = txtSuiteNumber.Text;
            newAddress.City = txtCity.Text;
            newAddress.PostalCode = txtPostalCode.Text;
            newAddress.Region = ddlRegion.SelectedValue;
            newAddress.Country = ddlCountry.Text;

            // Store into DB
            AddressDb.InsertAddress(newAddress);

            // Refresh GridView
            GridView1.DataBind();

            // Clear Values from Form
            txtStreetAddress.Text = "";
            ddlAddressType.SelectedIndex = 0;
            txtSuiteNumber.Text = "";
            txtCity.Text = "";
            txtPostalCode.Text = "";
            ddlRegion.SelectedIndex = 0;
            ddlCountry.Text = "";

        }
        
        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            if (e.Exception != null)
            {
                lblError.Text = DatabaseErrorMessage(e.Exception);
                e.ExceptionHandled = true;
                e.KeepInEditMode = true;
            }
            else if (e.AffectedRows == 0)
                lblError.Text = ConcurrencyErrorMessage();
        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            if (e.Exception != null)
            {
                lblError.Text = DatabaseErrorMessage(e.Exception);
                e.ExceptionHandled = true;
            }
            else if (e.AffectedRows == 0)
                lblError.Text = ConcurrencyErrorMessage();
        }

        protected void ObjectDataSource1_GetAffectedRows(object sender, ObjectDataSourceStatusEventArgs e)
        {
            e.AffectedRows = Convert.ToInt32(e.ReturnValue);
        }

        // PhoneNumbers

        protected void CreatePhoneNumber_Click(object sender, EventArgs e)
        {

            PhoneNumber newPhoneNumber = new PhoneNumber();
            newPhoneNumber.PhoneNumberId = System.Guid.NewGuid().ToString().ToUpper();
            newPhoneNumber.UserId = User.Identity.GetUserId();
            newPhoneNumber.Type = ddlType.SelectedValue;
            newPhoneNumber.Number = txtNumber.Text;
            newPhoneNumber.Extension = txtExtension.Text;

            // Store into DB
            PhoneNumberDb.InsertPhoneNumber(newPhoneNumber);

            // Refresh GridView
            GridView2.DataBind();

            // Clear Values from Form
            ddlType.SelectedIndex = 0;
            txtNumber.Text = "";
            txtExtension.Text = "";

        }

        protected void GridView2_PreRender(object sender, EventArgs e)
        {
            GridView2.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void GridView2_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            if (e.Exception != null)
            {
                lblError.Text = DatabaseErrorMessage(e.Exception);
                e.ExceptionHandled = true;
                e.KeepInEditMode = true;
            }
            else if (e.AffectedRows == 0)
                lblError.Text = ConcurrencyErrorMessage();
        }

        protected void GridView2_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            if (e.Exception != null)
            {
                lblError.Text = DatabaseErrorMessage(e.Exception);
                e.ExceptionHandled = true;
            }
            else if (e.AffectedRows == 0)
                lblError.Text = ConcurrencyErrorMessage();
        }

        protected void ObjectDataSource2_GetAffectedRows(object sender, ObjectDataSourceStatusEventArgs e)
        {
            e.AffectedRows = Convert.ToInt32(e.ReturnValue);
        }

        // Utility Helper Methods
        private string DatabaseErrorMessage(Exception ex)
        {
            string msg = $"<b>A database error has occurred:</b> {ex.Message}";
            if (ex.InnerException != null)
                msg += $"<br />Message: {ex.InnerException.Message}";
            return msg;
        }
        private string ConcurrencyErrorMessage()
        {
            return "Another user may have updated that category. Please try again";
        }

    }
}