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


public class UserPayee
{
    public string UserPayeeId { get; set; }
    public string UserId { get; set; }
    public string PayeeId { get; set; }
    public string Nickname { get; set; }
    public string PayeeAccountNumber { get; set; }
}
