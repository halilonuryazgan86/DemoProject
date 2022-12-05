using DemoProject.Core.MongoDB;
using DemoProject.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.CustomerService.Web.Services
{

    public interface ICustomerRepository : IBaseRepository<CustomerModel>
    {

    }
    public class CustomerRepository : BaseRepository<CustomerModel>, ICustomerRepository
    {
        public CustomerRepository(MongoDBConnectionSetting mongoDBConnectionSetting) : base(mongoDBConnectionSetting)
        {
        }
    }
}
