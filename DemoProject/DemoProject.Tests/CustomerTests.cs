using DemoProject.Core;
using DemoProject.Customer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DemoProject.Tests
{
    public class CustomerTests
    {
        private string _customerServiceUrl = "https://localhost:44322/api/customer";
        private readonly HttpExtension _httpExtension = new HttpExtension();

        [Fact]
        public void CreateCustomer_Success()
        {
            var customerResponseModel = new CustomerHttpResponseModel();
            customerResponseModel.UUID = Guid.NewGuid();
            customerResponseModel.Ad = "test1";
            customerResponseModel.Soyad = "test2";
            customerResponseModel.Firma = "deneme";
            customerResponseModel.ContactInfos = new List<CustomerInfoModel>
            {
                 new CustomerInfoModel
                 {
                      InfoDetail = "telefon",
                       InfoType = CustomerInfoType.Phone
                 },
                 new CustomerInfoModel
                 {
                      InfoDetail = "email@email.com",
                       InfoType = CustomerInfoType.Email
                 },
                 new CustomerInfoModel
                 {
                      InfoDetail = "lokasyon...",
                       InfoType = CustomerInfoType.Location
                 }
            };

            var requestUrl = $"{_customerServiceUrl}/add-customer";

            var result = _httpExtension.GetResponse<List<CustomerHttpResponseModel>, CustomerHttpResponseModel>(new DemoProject.Core.Models.HttpRequest<CustomerHttpResponseModel>
            {
                RequestObject = customerResponseModel,
                RequestType = DemoProject.Core.Models.HttpRequestType.POST,
                RequestUrl = requestUrl,
            }).ResponseObject;
            Assert.IsType<List<CustomerHttpResponseModel>>(result);
        }

        [Fact]
        public void DeleteCustomer_Success()
        {
            string uuid = "42e4951c-243e-4573-a513-5d6fe9d96c56";
            var requestUrl = $"{_customerServiceUrl}/delete-customer/{uuid}";
            var result = _httpExtension.GetResponse<List<CustomerHttpResponseModel>, object>(new DemoProject.Core.Models.HttpRequest<object>
            {
                RequestUrl = requestUrl,
                RequestType = DemoProject.Core.Models.HttpRequestType.DELETE
            }).ResponseObject;
        }

        [Fact]
        public void AddCustomerInfo_Success()
        {
            var requestUrl = $"{_customerServiceUrl}/add-customer-info";
            CustomerInfoRequestModel contactInfoRequestModel = new CustomerInfoRequestModel();
            contactInfoRequestModel.UUID = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            contactInfoRequestModel.CustomerInfo = new CustomerInfoModel
            {
                InfoDetail = "test lokasyon",
                InfoType = CustomerInfoType.Location
            };

            var result = _httpExtension.GetResponse<List<CustomerHttpResponseModel>, CustomerInfoRequestModel>(new DemoProject.Core.Models.HttpRequest<CustomerInfoRequestModel>
            {
                RequestUrl = requestUrl,
                RequestType = DemoProject.Core.Models.HttpRequestType.POST,
                RequestObject = contactInfoRequestModel
            }).ResponseObject;

            Assert.IsType<List<CustomerHttpResponseModel>>(result);
        }

        [Fact]
        public void DeleteContactInfo_Success()
        {
            var requestUrl = $"{_customerServiceUrl}/delete-customer-info";
            CustomerInfoRequestModel contactInfoRequestModel = new CustomerInfoRequestModel();
            contactInfoRequestModel.UUID = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            contactInfoRequestModel.CustomerInfo = new CustomerInfoModel
            {
                InfoDetail = "test lokasyon",
                InfoType = CustomerInfoType.Location
            };

            var result = _httpExtension.GetResponse<List<CustomerHttpResponseModel>, CustomerInfoRequestModel>(new DemoProject.Core.Models.HttpRequest<CustomerInfoRequestModel>
            {
                RequestUrl = requestUrl,
                RequestType = DemoProject.Core.Models.HttpRequestType.DELETE,
                RequestObject = contactInfoRequestModel
            }).ResponseObject;

            Assert.IsType<List<CustomerHttpResponseModel>>(result);
        }

        [Fact]
        public void UpdateCustomer_Success()
        {
            var contactResponseModel = new CustomerHttpResponseModel();
            contactResponseModel.UUID = new Guid("42e4951c-243e-4573-a513-5d6fe9d96c56");
            contactResponseModel.Ad = "test1 updated";
            contactResponseModel.Soyad = "test2 updated";
            contactResponseModel.Firma = "deneme updated";
            contactResponseModel.ContactInfos = new List<CustomerInfoModel>
            {
                 new CustomerInfoModel
                 {
                      InfoDetail = "telefon",
                       InfoType = CustomerInfoType.Phone
                 },
                 new CustomerInfoModel
                 {
                      InfoDetail = "email@email.com",
                       InfoType = CustomerInfoType.Email
                 },
                 new CustomerInfoModel
                 {
                      InfoDetail = "lokasyon...",
                       InfoType = CustomerInfoType.Location
                 }
            };

            var requestUrl = $"{_customerServiceUrl}/update-customer";
            var result = _httpExtension.GetResponse<List<CustomerHttpResponseModel>, CustomerHttpResponseModel>(new DemoProject.Core.Models.HttpRequest<CustomerHttpResponseModel>
            {
                RequestObject = contactResponseModel,
                RequestType = DemoProject.Core.Models.HttpRequestType.PUT,
                RequestUrl = requestUrl,
            }).ResponseObject;
            Assert.IsType<List<CustomerHttpResponseModel>>(result);
        }

        [Fact]
        public void GetCustomers_Success()
        {
            var result = _httpExtension.GetResponse<List<CustomerHttpResponseModel>, object>(new DemoProject.Core.Models.HttpRequest<object>
            {
                RequestUrl = $"{_customerServiceUrl}/all",
                RequestType = DemoProject.Core.Models.HttpRequestType.GET
            }).ResponseObject;

            Assert.IsType<List<CustomerHttpResponseModel>>(result);
        }
    }
}
