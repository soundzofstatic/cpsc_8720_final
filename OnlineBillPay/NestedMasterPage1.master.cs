using Microsoft.AspNet.Identity.Owin;
using OnlineBillPay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Diagnostics;

namespace OnlineBillPay
{
    public partial class NestedMasterPage1 : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            ApplicationUser currentUser = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(HttpContext.Current.User.Identity.GetUserId());

            // Check if currentUser is suspended, if so redirect out
            if (currentUser.AccountState == "Suspended")
            {

                Session["Suspended_message"] = "Your account is suspended. For more details contact the site admin. Thank you.";
                Session["Suspended_message_count"] = 0;

                Response.Redirect("/Default");

            }

            // Generate Sidebar Links
            List<SitePage> sitePages = new SitePageData().GetSitePages();            

            // Determine if Admin page should be displayed
            if(HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().IsInRole(HttpContext.Current.User.Identity.GetUserId(), "Admin"))
            {

                sitePages.Add(new SitePage
                {
                    LinkLocation = "/Account/Admin/Default",
                    LinkTitle = "Manage Users",
                    LinkActive = false,
                    LinkText = "Manage Users"
                });

            }

            foreach (var page in sitePages.ToList())
            {

                if (page.LinkLocation == Request.Url.PathAndQuery)
                {

                    page.LinkActive = true;

                }

            }

            SidebarNav.DataSource = sitePages;
            SidebarNav.DataBind();

        }
    }
}