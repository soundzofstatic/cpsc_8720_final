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
using System.Collections.Generic;

namespace OnlineBillPay.Account
{
    public partial class MakeManyPayments : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

            // Check if UserID is returned, thus authenticated session is still set
            if (string.IsNullOrEmpty(User.Identity.GetUserId()))
            {

                Response.Redirect("/Account/Login.aspx"); // This sends a 302, should send a 301

            }

            // Set/Overload the UserId for the Select query that will render FundingSources for User
            //ObjectDataSource1.SelectParameters["UserId"].DefaultValue = User.Identity.GetUserId();

            if (!IsPostBack)
            {

                // Generate Repeater Links
                List<UserPayee> payees = UserPayeeDb.GetUserPayees(User.Identity.GetUserId());

                PayeeList.DataSource = payees;
                PayeeList.DataBind();

            }

        }

        protected void ddlFundingSource_DataBinding(object sender, EventArgs e)
        {
            DropDownList ddlFundingSource = (DropDownList)(sender);

            // Fill your ddl here (eg. ddl.Items.Add("abc", xyz");
            // Make sure the value you are going to set the selected item to has been added

            foreach (var fundingSources in FundingSourceDb.GetFundingSources(User.Identity.GetUserId()).ToList())
            {

                ddlFundingSource.Items.Add(new ListItem { Text = fundingSources.Nickname.ToString(), Value = fundingSources.FundingSourceId.ToString() });

            }

        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {


        }

        protected void SubmitMassPayee_Click(object sender, EventArgs e)
        {

            Debug.WriteLine("REPEATER HAS: " + PayeeList.Items.Count);

            int i = 0;

            //for (int i = 0; i < PayeeList.Items.Count; i++)
            foreach (RepeaterItem item in PayeeList.Items)
            {

                // Amount
                TextBox txtAmount = (TextBox)item.FindControl("txtAmount");
                TextBox txtCurrency = (TextBox)item.FindControl("txtCurrency");
                DropDownList ddlFundingSource = (DropDownList)item.FindControl("ddlFundingSource");
                HiddenField hdnField = (HiddenField)item.FindControl("hdnField");

                Debug.WriteLine("AMOUNTS HAS: " + txtAmount.Text); // Has Valye from Form
                Debug.WriteLine("Funding IS: " + ddlFundingSource.SelectedValue); // Has Valye from Form
                Debug.WriteLine("UserPayee IS: " + hdnField.Value); // Has Valye from Form

                // todo - Insert to DB
                // Create Payment
                OnlineBillPay.Models.Payment newPayment = new OnlineBillPay.Models.Payment();
                newPayment.PaymentId = System.Guid.NewGuid().ToString().ToUpper();
                newPayment.UserPayeeId = hdnField.Value;
                newPayment.FundingSourceId = ddlFundingSource.SelectedValue;
                newPayment.UserId = User.Identity.GetUserId();
                newPayment.Amount = float.Parse(txtAmount.Text);
                newPayment.DateCreated = DateTime.Now;
                newPayment.Currency = txtCurrency.Text;
                newPayment.Status = "Pending";

                // Store into DB
                PaymentDb.InsertPayment(newPayment);
                i++;
                
            }

            // Set Payment success notification message
            Session["Payment_confirmation_message"] = "Your " + i + " payments were posted. Thank you!";
            Session["Payment_confirmation_message_play_count"] = 0;

            // Dump the UserPayee in Session
            Session["PaymentInProgress_payee"] = null;

            // Redirect to Account Home
            Response.Redirect("/Account/Default");

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