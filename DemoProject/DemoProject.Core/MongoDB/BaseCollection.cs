using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProject.Core.MongoDB
{
    public class BaseCollection
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        public string RowId => Id.ToString();
    }
}
