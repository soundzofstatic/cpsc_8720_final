using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// be sure to include these using directives
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using OnlineBillPay.Models;

namespace OnlineBillPay.Models
{
    public class SitePageData
    {
        public List<SitePage> GetSitePages()
        {
            return new List<SitePage>
            {
                new SitePage {
                    LinkLocation ="/Account/Default",
                    LinkTitle ="Account Home page",
                    LinkActive = false,
                    LinkText ="Account Home"
                },new SitePage {
                    LinkLocation ="/Account/PaymentHistory",
                    LinkTitle ="Payment History page",
                    LinkActive = false,
                    LinkText ="Payment History"
                },
                new SitePage {
                    LinkLocation ="/Account/AddPayee",
                    LinkTitle ="Add a Payee page",
                    LinkActive = false,
                    LinkText ="Add Payee"
                },
                new SitePage {
                    LinkLocation ="/Account/MakeSinglePayment",
                    LinkTitle ="Make a Single Payment page",
                    LinkActive = false,
                    LinkText ="Make a Single Payment"
                },
                new SitePage {
                    LinkLocation ="/Account/MakeManyPayments",
                    LinkTitle ="Make a Many Payments page",
                    LinkActive = false,
                    LinkText ="Make Many Payments"
                },
                new SitePage {
                    LinkLocation ="/Account/Addresses",
                    LinkTitle ="Manage Addressess page",
                    LinkActive = false,
                    LinkText ="Manage Addresses"
                },
                new SitePage {
                    LinkLocation ="/Account/PhoneNumbers",
                    LinkTitle ="Manage Phone Numbers page",
                    LinkActive = false,
                    LinkText ="Manage Phone Numbers"
                },
                new SitePage {
                    LinkLocation ="/Account/FundingSources",
                    LinkTitle ="Manage Funding Sources page",
                    LinkActive = false,
                    LinkText ="Manage Funding Sources"
                },
                new SitePage {
                    LinkLocation ="/Account/Payees",
                    LinkTitle ="Manage Payees page",
                    LinkActive = false,
                    LinkText ="Manage Payees"
                },
                new SitePage {
                    LinkLocation ="/Account/ManageUserDetails",
                    LinkTitle ="Manage User Details page",
                    LinkActive = false,
                    LinkText ="Manage User Details"
                }

    };
        }
    }
}