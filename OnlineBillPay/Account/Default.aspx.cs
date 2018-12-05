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
    public partial class Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            // todo - Redirect away if not signed in
            if (string.IsNullOrEmpty(User.Identity.GetUserId()))
            {

                Response.StatusCode = 403;
                Response.Redirect("/Default");

            }

            // Set/Overload the UserId for the Select query that will render FundingSources for User
            ObjectDataSource1.SelectParameters["UserId"].DefaultValue = User.Identity.GetUserId();

            if (Session["Payment_confirmation_message_play_count"] != null)
            {

                Session["Payment_confirmation_message_play_count"] = (int)Session["Payment_confirmation_message_play_count"] + 1;

                if((int)Session["Payment_confirmation_message_play_count"] == 1)
                {
                    // Show ALerts Dialog Box
                    successAlerts.Visible = true;
                    // Display the Message and destroy it
                    pNotification.InnerText = (string)Session["Payment_confirmation_message"];

                    Session["Payment_confirmation_message"] = null;
                    Session["Payment_confirmation_message_play_count"] = null;

                }
            }
        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}