using DemoProject.Customer.Models;
using DemoProject.CustomerService.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.CustomerService.Web.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerModel>> GetAll();
        Task<CustomerModel> Get(Guid UUID);
        Task<List<CustomerModel>> AddCustomer(CustomerModel model);
        Task<List<CustomerModel>> UpdateCustomer(CustomerModel model);
        Task<List<CustomerModel>> DeleteCustomer(Guid UUID);
        Task<List<CustomerModel>> SpecificSearch(CustomerSearchModel request);
        Task<List<CustomerModel>> AddCustomerInfo(Guid uuid, CustomerInfoModel customerInfo);
        Task<List<CustomerModel>> DeleteCustomerInfo(Guid uuid, CustomerInfoModel customerInfo);
    }
    public class CustomerServices : ICustomerService
    {
        private DemoProject.Core.MongoDB.MongoDBConnectionSetting _mongoDBConnectionSetting;
        private ICustomerRepository _customerRepository;
        public CustomerServices(DemoProject.Core.MongoDB.MongoDBConnectionSetting mongoDBConnectionSetting,
            ICustomerRepository customerRepository)
        {
            _mongoDBConnectionSetting = mongoDBConnectionSetting;
            _customerRepository = customerRepository;
        }

        private async Task<List<CustomerModel>> GetCustomers() => await _customerRepository.GetListAsync();

        public async Task<List<CustomerModel>> AddCustomer(CustomerModel model)
        {
            await _customerRepository.InsertItemAsync(model);
            return await GetCustomers();
        }

        public async Task<CustomerModel> Get(Guid UUID) => await _customerRepository.GetAsync(x => x.UUID == UUID);

        public async Task<List<CustomerModel>> GetAll() => await GetCustomers();

        public async Task<List<CustomerModel>> UpdateCustomer(CustomerModel model)
        {
            var contact = _customerRepository.GetByFilter(x => x.UUID == model.UUID);
            var _id = contact.Id;
            contact = model;
            contact.Id = _id;
            await _customerRepository.UpdateAsync(contact.RowId, contact);
            return await GetCustomers();
        }

        public async Task<List<CustomerModel>> DeleteCustomer(Guid UUID)
        {
            await _customerRepository.DeleteItemAsync(x => x.UUID == UUID);
            return await GetCustomers();
        }

        public async Task<List<CustomerModel>> SpecificSearch(CustomerSearchModel request)
        {
            var list = await _customerRepository.GetListByFilterAsync(x => x.CustomerInfos.Any(y => y.InfoType == request.CustomerInfoType && y.InfoDetail.Contains(request.Detail)));
            return list;
        }

        public async Task<List<CustomerModel>> AddCustomerInfo(Guid uuid, CustomerInfoModel contactInfo)
        {
            var contact = _customerRepository.GetByFilter(x => x.UUID == uuid);
            if (contact == null)
                throw new Exception($"There is no contact with Id:{uuid}"); //Example exception 

            if (contact.CustomerInfos == null)
                contact.CustomerInfos = new List<CustomerInfoModel>();
            contact.CustomerInfos.Add(contactInfo);
            await _customerRepository.UpdateAsync(contact.RowId, contact);
            return await GetCustomers();
        }

        public async Task<List<CustomerModel>> DeleteCustomerInfo(Guid uuid, CustomerInfoModel contactInfo)
        {
            var contact = await _customerRepository.GetAsync(x => x.UUID == uuid);
            if (contact == null)
                throw new Exception($"There is no contact with Id:{uuid}");

            var selectedContactInfo = contact.CustomerInfos.FirstOrDefault(x => x.InfoType == contactInfo.InfoType && x.InfoDetail == contactInfo.InfoDetail);
            if (selectedContactInfo != null)
                contact.CustomerInfos.Remove(selectedContactInfo);

            await _customerRepository.UpdateAsync(contact.RowId, contact);
            return await GetCustomers();
        }
    }
}
