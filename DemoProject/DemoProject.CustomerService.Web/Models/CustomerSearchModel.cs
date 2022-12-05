using DemoProject.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.CustomerService.Web.Models
{
    public class CustomerSearchModel
    {
        public CustomerInfoType CustomerInfoType { get; set; }
        public string Detail { get; set; }
    }
}
