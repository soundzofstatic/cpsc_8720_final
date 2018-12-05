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
    public partial class Payment : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            UserPayee payee = (UserPayee) Session["PaymentInProgress_payee"];

            Debug.WriteLine(payee.Nickname);
            Debug.WriteLine(payee.UserPayeeId);
            Debug.WriteLine(payee.UserId);

            // Validate that the UserId coming from UserPayee matches the one authenticated, else redirect to /Account/Default
            if(payee.UserId != User.Identity.GetUserId())
            {

                Response.StatusCode = 403;
                Response.Redirect("/Account/Default");

            }

            // Fill in Fields about the UserPayee
            txtNickname.Text = payee.Nickname;
            txtAccountNumber.Text = payee.PayeeAccountNumber;
            hdnExistingUserPayeeId.Value = payee.UserPayeeId;

            foreach (var fundingSources in FundingSourceDb.GetFundingSources(User.Identity.GetUserId()).ToList())
            {

                ddlFundingSource.Items.Add(new ListItem { Text = fundingSources.Nickname.ToString(), Value = fundingSources.FundingSourceId.ToString() });

            }

        }

        protected void CreatePayment_Click(object sender, EventArgs e)
        {


            // Create Payment
            OnlineBillPay.Models.Payment newPayment = new OnlineBillPay.Models.Payment();
            newPayment.PaymentId = System.Guid.NewGuid().ToString().ToUpper();
            newPayment.UserPayeeId = hdnExistingUserPayeeId.Value;
            newPayment.FundingSourceId = ddlFundingSource.SelectedValue;
            newPayment.UserId = User.Identity.GetUserId();
            newPayment.Amount = float.Parse(txtPaymentAmount.Text);
            newPayment.DateCreated = DateTime.Now;
            newPayment.Currency = txtCurrency.Text;
            newPayment.Status = "Pending";

            // Store into DB
            PaymentDb.InsertPayment(newPayment);

            UserPayee payee = (UserPayee)Session["PaymentInProgress_payee"];

            // Set Payment success notification message
            Session["Payment_confirmation_message"] = "Your payment to " + payee.Nickname + " for " + newPayment.Amount + "(" + newPayment.Currency + ") is " + newPayment.Status + ". Thank you!";
            Session["Payment_confirmation_message_play_count"] = 0;

            // Dump the UserPayee in Session
            Session["PaymentInProgress_payee"] = null;

            // Redirect to Account Home
            Response.Redirect("/Account/Default");

        }


        protected void CancelPayment_Click(object sender, EventArgs e)
        {

            // Redirect to Account Home
            Response.Redirect("/Account/Default");

        }

        protected void ClearPayment_Click(object sender, EventArgs e)
        {

            // Clear Values from Form
            ddlFundingSource.SelectedIndex = 0;
            txtPaymentAmount.Text = null;

        }

    }
}