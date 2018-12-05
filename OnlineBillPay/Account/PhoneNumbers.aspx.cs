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
    public partial class PhoneNumbers : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("USER ID");
            Debug.WriteLine(User.Identity.GetUserId());

            // Check if UserID is returned, thus authenticated session is still set
            if (string.IsNullOrEmpty(User.Identity.GetUserId()))
            {

                Response.Redirect("/Account/Login.aspx"); // This sends a 302, should send a 301

            }

            // Set/Overload the UserId for the Select query that will render PhoneNumbers for User
            ObjectDataSource1.SelectParameters["UserId"].DefaultValue = User.Identity.GetUserId();

            // Generate List items for State DDL
            foreach (var type in new PhoneTypeData().GetPhoneTypes().ToList())
            {

                ddlType.Items.Add(new ListItem {  Text= type.Type.ToString(), Value= type.Type.ToString() });

            }

        }


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
            GridView1.DataBind();

            // Clear Values from Form
            ddlType.SelectedIndex = 0;
            txtNumber.Text = "";
            txtExtension.Text = "";

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

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            if (e.Exception != null)
            {
                lblError.Text = DatabaseErrorMessage(e.Exception);
                e.ExceptionHandled = true;
            }
        }

        protected void ObjectDataSource1_GetAffectedRows(object sender, ObjectDataSourceStatusEventArgs e)
        {
            e.AffectedRows = Convert.ToInt32(e.ReturnValue);
        }

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