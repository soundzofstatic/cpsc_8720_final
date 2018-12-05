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

            // Generate Sidebar Links
            List<UserPayee> payees = UserPayeeDb.GetUserPayees(User.Identity.GetUserId());
            /*foreach (var payee in payees.ToList())
            {

                if (payee.Nickname == Request.Url.PathAndQuery)
                {

                    page.LinkActive = payee.Nickname;

                }

            }*/

            PayeeList.DataSource = payees;
            PayeeList.DataBind();

        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {


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