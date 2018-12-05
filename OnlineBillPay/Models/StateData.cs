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
    public class StateData
    {
        public List<State> GetStates()
        {
            return new List<State>
            {

                new State {Name="Alabama", Code="AL"},
                new State {Name="Alaska", Code="AK"},
                new State {Name="Arizon", Code="AZ"},
                new State {Name="Arkansas", Code="AR"},
                new State {Name="California", Code="CA"},
                new State {Name="Colorado", Code="CO"},
                new State {Name="Connecticut", Code="CT"},
                new State {Name="Delaware", Code="DE"},
                new State {Name="Florida", Code="FL"},
                new State {Name="Georgia", Code="GA"},
                new State {Name="Hawaii", Code="HI"},
                new State {Name="Idaho", Code="ID"},
                new State {Name="Illinois", Code="IL"},
                new State {Name="Indiana", Code="IN"},
                new State {Name="Iowa", Code="IA"},
                new State {Name="Kansas", Code="KS"},
                new State {Name="Kentucky", Code="KY"},
                new State {Name="Louisiana", Code="LA"},
                new State {Name="Maine", Code="ME"},
                new State {Name="Maryland", Code="MD"},
                new State {Name="Massachusetts", Code="MA"},
                new State {Name="Michigan", Code="MI"},
                new State {Name="Minnesota", Code="MN"},
                new State {Name="Mississippi", Code="MS"},
                new State {Name="Missouri", Code="MO"},
                new State {Name="Montana", Code="MT"},
                new State {Name="Nebraska", Code="NE"},
                new State {Name="Nevada", Code="NV"},
                new State {Name="New Hampshire", Code="NH"},
                new State {Name="New Jersey", Code="NJ"},
                new State {Name="New Mexico", Code="NM"},
                new State {Name="New York", Code="NY"},
                new State {Name="North Carolina", Code="NC"},
                new State {Name="North Dakota", Code="ND"},
                new State {Name="Ohio", Code="OH"},
                new State {Name="Oklahoma", Code="OK"},
                new State {Name="Oregon", Code="OR"},
                new State {Name="Pennsylvania", Code="PA"},
                new State {Name="Rhode Island", Code="RI"},
                new State {Name="South Carolina", Code="SC"},
                new State {Name="South Dakota", Code="SD"},
                new State {Name="Tennessee", Code="TN"},
                new State {Name="Texas", Code="TX"},
                new State {Name="Utah", Code="UT"},
                new State {Name="Vermont", Code="VT"},
                new State {Name="Virginia", Code="VA"},
                new State {Name="Washington", Code="WA"},
                new State {Name="West Virginia", Code="WV"},
                new State {Name="Wisconsin", Code="WI"},
                new State {Name="Wyoming", Code="WY"},

                new State {Name="America Samoa", Code="AS"},
                new State {Name="District of Columbia", Code="DC"},
                new State {Name="Federated States of Micronesia", Code="FM"},
                new State {Name="Guam", Code="GU"},
                new State {Name="Marshall Islands", Code="MH"},
                new State {Name="Northern Mariana Islands", Code="MP"},
                new State {Name="Palau", Code="PW"},
                new State {Name="Puerto Rico", Code="PR"},
                new State {Name="Virgin I", Code="VI"}

            };
        }
    }
}