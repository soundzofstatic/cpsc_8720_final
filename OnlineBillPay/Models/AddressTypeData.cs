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
    public class AddressTypeData
    {
        public List<AddressType> GetAddressTypes()
        {
            return new List<AddressType>
            {

                new AddressType {Type="Home"},
                new AddressType {Type="Apt"},
                new AddressType {Type="Suite"},

            };
        }
    }
}