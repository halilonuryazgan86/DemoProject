using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProject.Core.MongoDB
{
    public class MongoDBConnectionSetting
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DBName { get; set; }
        public string CollectionName { get; set; }
    }
}
