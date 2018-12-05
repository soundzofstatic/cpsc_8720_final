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
    public partial class MakeSinglePayment : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            ObjectDataSource1.SelectParameters["UserId"].DefaultValue = User.Identity.GetUserId();

        }

      
        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void GridView1_PayeeResultCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Select")
            {

                // Grab the index of the selected row
                int index = Convert.ToInt32(e.CommandArgument);

                // Grab the UserPayeeId selected and query the DB again for it
                String selectedUserPayeeId = GridView1.DataKeys[index]["UserPayeeId"].ToString();

                Debug.WriteLine(selectedUserPayeeId);

                // Set the UserPayeeId into a session and redirect to Payment.aspx
                Session["PaymentInProgress_payee"] = UserPayeeDb.GetUserPayeeById(selectedUserPayeeId);

                Response.Redirect("/Account/Payment");

            }
        }
    }
}