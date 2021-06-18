using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DeveloperTest.Utility;


namespace DeveloperTest.Models
{
    public class BaseCustomerModel
    {
        public string CustomerName { get; set; }
        public int CustomerType { get; set; }
        //public CustomerTypeEnum CustomerType { get; set; }
    }
}
