using DemoProject.Customer;
using DemoProject.Customer.Models;
using DemoProject.CustomerService.Web.Models;
using DemoProject.CustomerService.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.CustomerService.Web.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;
        public CustomerController(ILogger<CustomerController> logger,
            ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet(template: "all")]
        public async Task<List<CustomerModel>> Get() => await _customerService.GetAll();

        [HttpGet(template: "get/{uuid}")]
        public async Task<CustomerModel> Get([FromRoute] string uuid) => await _customerService.Get(new Guid(uuid));

        [HttpPost(template: "add-customer")]
        public async Task<List<CustomerModel>> AddContact([FromBody] CustomerModel request) => await _customerService.AddCustomer(request);

        [HttpPut(template: "update-customer")]
        public async Task<List<CustomerModel>> UpdateContact([FromBody] CustomerModel request) => await _customerService.UpdateCustomer(request);

        [HttpDelete(template: "delete-customer/{uuid}")]
        public async Task<List<CustomerModel>> DeleteContact([FromRoute] string uuid) => await _customerService.DeleteCustomer(new Guid(uuid));

        [HttpGet(template: "specific-search")]
        public async Task<List<CustomerModel>> SpecificSearch([FromBody] CustomerSearchModel request) => await _customerService.SpecificSearch(request);

        [HttpPost(template: "add-customer-info")]
        public async Task<List<CustomerModel>> AddContactInfo([FromBody] CustomerInfoRequestModel request) => await _customerService.AddCustomerInfo(request.UUID, request.CustomerInfo);

        [HttpDelete("delete-customer-info")]
        public async Task<List<CustomerModel>> DeleteContactInfo([FromBody] CustomerInfoRequestModel request) => await _customerService.DeleteCustomerInfo(request.UUID, request.CustomerInfo);

    }
}
