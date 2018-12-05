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
    public class PhoneTypeData
    {
        public List<PhoneType> GetPhoneTypes()
        {
            return new List<PhoneType>
            {

                new PhoneType {Type="Home"},
                new PhoneType {Type="Mobile"},
                new PhoneType {Type="Work"},

            };
        }
    }
}