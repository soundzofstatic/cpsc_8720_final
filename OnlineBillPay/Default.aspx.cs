using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace OnlineBillPay
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Suspended_message"] != null)
            {

                Session["Suspended_message_count"] = (int)Session["Suspended_message_count"] + 1;

                if ((int)Session["Suspended_message_count"] >= 1)
                {
                    // Show ALerts Dialog Box
                    errorAlerts.Visible = true;
                    // Display the Message and destroy it
                    pNotification1.InnerText = (string)Session["Suspended_message"];

                    Session["Suspended_message"] = null;
                    Session["Suspended_message_count"] = null;

                }
            }

        }
    }
}