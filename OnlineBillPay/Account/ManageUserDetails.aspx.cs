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
    public partial class ManageUserDetails : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            // Redirect away if not signed in
            if (string.IsNullOrEmpty(User.Identity.GetUserId()))
            {

                Response.StatusCode = 403;
                Response.Redirect("/Default");

            }


            if (!IsPostBack)
            {
                // Grab the UserContext
                UserContext currentUser = UserContextDb.GetUserContext(User.Identity.GetUserId());

                // Fill out the Form
                txtDisplayName.Text = currentUser.DisplayName;
                txtEmail.Text = currentUser.Email;
                txtFirstName.Text = currentUser.FirstName;
                txtLastName.Text = currentUser.LastName;
                txtUserName.Text = currentUser.UserName;
            }

        }

        protected void UpdateUser_Click(object sender, EventArgs e)
        {

            UserContext currentUser = UserContextDb.GetUserContext(User.Identity.GetUserId());

            Debug.WriteLine(currentUser.FirstName);
            Debug.WriteLine("REQUEST: " + txtFirstName.Text);


            // Override the values of properties that are allowed to be updated
            UserContext updatedUser = new UserContext();
            // updated Fields
            updatedUser.DisplayName = txtDisplayName.Text;
            updatedUser.FirstName = txtFirstName.Text;
            updatedUser.LastName = txtLastName.Text;
            // Non-changing fields
            updatedUser.UserId = currentUser.UserId;
            updatedUser.Email = currentUser.Email;
            updatedUser.UserName = currentUser.UserName;
            updatedUser.AccountState = currentUser.AccountState;
            updatedUser.RoleId = currentUser.RoleId;
            updatedUser.Role = currentUser.Role;

            Debug.WriteLine("NEW: " + updatedUser.FirstName);

            // Store into DB
            UserContextDb.UpdateUserContext(currentUser, updatedUser);       

        }

        protected void CancelUpdateUser_Click(object sender, EventArgs e)
        {            

        }

    }
}