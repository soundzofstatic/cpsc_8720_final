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
    public partial class AddPayee : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            // Generate List items for State DDL
            foreach (var state in new StateData().GetStates().ToList())
            {

                ddlRegion.Items.Add(new ListItem { Text = state.Name.ToString(), Value = state.Code.ToString() });

            }

        }

        protected void CreatePayee_Click(object sender, EventArgs e)
        {

            // Check to see if Payee exists

            Payee newPayee = new Payee();

            // If payee not exists, create new payee
            if (String.IsNullOrEmpty(hdnExistingPayeeId.Value))
            {
                newPayee.PayeeId = System.Guid.NewGuid().ToString().ToUpper();
                newPayee.DefaultName = txtName.Text;
                newPayee.DefaultStreetAddress = txtStreetAddress.Text;
                newPayee.DefaultStreetAddressTwo = txtStreetAddress2.Text;
                newPayee.DefaultCity = txtCity.Text;
                newPayee.DefaultPostalCode = txtPostalCode.Text;
                newPayee.DefaultRegion = ddlRegion.SelectedValue;
                newPayee.DefaultCountry = ddlCountry.Text; // Should be converted to a DDL in the future when more countries supported

                // Store into DB
                PayeeDb.InsertPayee(newPayee);
            }

            // Create UserPayee Association
            UserPayee newUserPayee = new UserPayee();
            newUserPayee.UserPayeeId = System.Guid.NewGuid().ToString().ToUpper();
            newUserPayee.UserId = User.Identity.GetUserId();
            newUserPayee.PayeeId = String.IsNullOrEmpty(hdnExistingPayeeId.Value) ? newPayee.PayeeId : hdnExistingPayeeId.Value;
            newUserPayee.Nickname = txtNickname.Text;
            newUserPayee.PayeeAccountNumber = txtAccountNumber.Text;

            // Store into DB
            UserPayeeDb.InsertUserPayee(newUserPayee);

            // Trigger confirmation Modal

            // Clear Values from Form
            txtName.Text = "";
            txtStreetAddress.Text = "";
            txtStreetAddress2.Text = "";
            txtCity.Text = "";
            txtPostalCode.Text = "";
            ddlRegion.SelectedIndex = 0;
            txtNickname.Text = "";
            txtAccountNumber.Text = "";

            // Reset GridView1 and search query just in case
            txtSearchQuery.Text = "";
            GridView1.DataBind();            

        }


        protected void CancelPayee_Click(object sender, EventArgs e)
        {

            // Clear Values from Form
            txtAccountNumber.Text = "";
            txtNickname.Text = "";
            txtName.Text = "";
            txtStreetAddress.Text = "";
            txtStreetAddress2.Text = "";
            txtCity.Text = "";
            txtPostalCode.Text = "";
            ddlRegion.SelectedIndex = 0;
            txtNickname.Text = "";
            txtAccountNumber.Text = "";

            // Reset GridView1 and search query just in case
            txtSearchQuery.Text = "";
            GridView1.DataBind();

            // Set Filled out Form items to ReadOnly
            txtName.ReadOnly = false;
            txtStreetAddress.ReadOnly = false;
            txtStreetAddress2.ReadOnly = false;
            txtCity.ReadOnly = false;
            txtPostalCode.ReadOnly = false;
            ddlRegion.Attributes.Add("enabled", "enabled");

        }

        protected void SearchPayee_Click(object sender, EventArgs e)
        {

            GridView1.DataBind();

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

                // Grab the PayeeId selected and query the DB again for it
                //
                // todo - Is there a way to reference the <Payee> object from the List<Payee> 
                // used to render the GridView? That would prevent re-querying for the Payee.
                //
                String selectedPayeeId = GridView1.DataKeys[index]["PayeeId"].ToString();

                Payee selectedPayee = PayeeDb.GetPayeeById(selectedPayeeId);

                // Fill the Form out
                txtName.Text = selectedPayee.DefaultName;
                txtStreetAddress.Text = selectedPayee.DefaultStreetAddress;
                txtStreetAddress2.Text = selectedPayee.DefaultStreetAddressTwo;
                txtCity.Text = selectedPayee.DefaultCity;
                txtPostalCode.Text = selectedPayee.DefaultPostalCode;
                ddlRegion.SelectedValue = selectedPayee.DefaultRegion;
                hdnExistingPayeeId.Value = selectedPayee.PayeeId;

                // Set Filled out Form items to ReadOnly
                txtName.ReadOnly = true;
                txtStreetAddress.ReadOnly = true;
                txtStreetAddress2.ReadOnly = true;
                txtCity.ReadOnly = true;
                txtPostalCode.ReadOnly = true;
                ddlRegion.Attributes.Add("Disabled", "Disabled");

            }

        }
    }
}