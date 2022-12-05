using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProject.Customer.Models
{
    public class CustomerHttpResponseModel
    {
        [BsonElement("uuid")]
        public Guid UUID { get; set; }
        [BsonElement("ad")]
        public string Ad { get; set; }
        [BsonElement("soyad")]
        public string Soyad { get; set; }
        [BsonElement("firma")]
        public string Firma { get; set; }
        [BsonElement("iletisim_bilgileri")]
        public List<CustomerInfoModel> ContactInfos { get; set; }
    }
    public class CustomerModel : DemoProject.Core.MongoDB.BaseCollection
    {
        [BsonElement("uuid")]
        public Guid UUID { get; set; }
        [BsonElement("ad")]
        public string Ad { get; set; }
        [BsonElement("soyad")]
        public string Soyad { get; set; }
        [BsonElement("firma")]
        public string Firma { get; set; }
        [BsonElement("iletisim_bilgileri")]
        public List<CustomerInfoModel> CustomerInfos { get; set; }

    }

    public class CustomerInfoModel
    {
        [BsonElement("bilgi_tipi")]
        public CustomerInfoType InfoType { get; set; }
        [BsonElement("bilgi_icerigi")]
        public string InfoDetail { get; set; }
    }

    public enum CustomerInfoType
    {
        Phone = 1,
        Email = 2,
        Location = 3
    }

    public class CustomerInfoRequestModel
    {
        public Guid UUID { get; set; }
        public CustomerInfoModel CustomerInfo { get; set; }
    }
}
