using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using OnlineBillPay.Models;


namespace OnlineBillPay.Models
{
    public class Payment
    {
        public string PaymentId { get; set; }
        public string UserPayeeId { get; set; }
        public string FundingSourceId { get; set; }
        public string UserId { get; set; }
        public float Amount { get; set; }
        public DateTime DateCreated { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
    }
}
