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

namespace OnlineBillPay.Account.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            // todo - Redirect away if not signed in
            if (string.IsNullOrEmpty(User.Identity.GetUserId()))
            {

                // todo - Check if user is ADMIN ROLE, otherwise reroute

                Response.StatusCode = 403;
                Response.Redirect("/Default");

            }        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void GridView1_UserResultCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "ToggleAccountState")
            {

                // Grab the index of the selected row
                int index = Convert.ToInt32(e.CommandArgument);

                String selectedUserId = GridView1.DataKeys[index]["UserId"].ToString();
                                
                UserContext selectedUser = UserContextDb.GetUserContext(selectedUserId);
                Debug.WriteLine(selectedUser.UserId + " - " + selectedUser.AccountState);

                // Set the inverse of  selectedUser.AccountState (ie. Active or Suspended)
                selectedUser.AccountState = selectedUser.AccountState == "Active" ? "Suspended" : "Active";

                // Toggle the AccountState for the current UserContext AKA user
                UserContextDb.ToggleUserAccountState(selectedUser);

                GridView1.DataBind();

            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button toggleSuspendBtn = (Button)e.Row.Cells[5].Controls[0];
                toggleSuspendBtn.Text = e.Row.Cells[4].Text == "Active" ? "Suspend" : "Activate"; // 4th column contains AccountState
            }
        }

        protected void GridView2_PreRender(object sender, EventArgs e)
        {
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void GridView2_UserResultCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "ToggleAdminRole")
            {

                // Grab the index of the selected row
                int index = Convert.ToInt32(e.CommandArgument);

                String selectedUserId = GridView1.DataKeys[index]["UserId"].ToString();

                UserContext selectedUser = UserContextDb.GetUserContext(selectedUserId);
                Debug.WriteLine(selectedUser.UserId + " - " + selectedUser.Role);

                // Set the inverse of selectedUser.AccountState (ie. Active or Suspended)
                if(selectedUser.Role == "Admin")
                {

                    // Remove Admin Role
                    UserContextDb.DeleteUserRole(selectedUser);

                } else
                {
                    // Add Admin Role
                    selectedUser.RoleId = "1";
                    selectedUser.Role = "Admin";
                    UserContextDb.AddUserRole(selectedUser);

                }

                GridView2.DataBind();

            }

        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button toggleSuspendBtn = (Button)e.Row.Cells[5].Controls[0];
                toggleSuspendBtn.Text = e.Row.Cells[4].Text == "Admin" ? "Remove Admin" : "Make Admin"; // 4th column contains Role
            }
        }

    }
}