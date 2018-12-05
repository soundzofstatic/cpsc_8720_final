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
    public class FundingSourceTypeData
    {
        public List<FundingType> GetFundingTypes()
        {
            return new List<FundingType>
            {

                new FundingType {Type="Bank"},
                new FundingType {Type="Bitcoin"},
                new FundingType {Type="Ethereum"}

            };
        }
    }
}