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


public class Payee
{
    public string PayeeId { get; set; }
    public string DefaultName { get; set; }
    public string DefaultStreetAddress { get; set; }
    public string DefaultStreetAddressTwo { get; set; }
    public string DefaultCity { get; set; }
    public string DefaultRegion { get; set; }
    public string DefaultCountry { get; set; }
    public string DefaultPostalCode { get; set; }
}
