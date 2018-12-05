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


public class PhoneNumber
{
    public string PhoneNumberId { get; set; }
    public string UserId { get; set; }
    public string Type { get; set; }
    public string Number { get; set; }
    public string Extension { get; set; }
}
