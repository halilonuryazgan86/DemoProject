using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DemoProject.Tests
{
    public class MongoTests
    {
        [Fact]
        public void CollectionListTests()
        {
            ITestRepository testRepository = new TestRepository();
            var result = testRepository.GetList();
        }

        [Fact]
        public void CollectionAddTests()
        {
            ITestRepository testRepository = new TestRepository();
            testRepository.InsertItem(new Test { Text = "deneme 4" });
            var result = testRepository.GetList();
        }
    }

    public class Test : DemoProject.Core.MongoDB.BaseCollection
    {
        [BsonElement("text")]
        public string Text { get; set; }
    }

    public interface ITestRepository : DemoProject.Core.MongoDB.IBaseRepository<Test>
    {

    }

    public class TestRepository : DemoProject.Core.MongoDB.BaseRepository<Test>, ITestRepository
    {
        private DemoProject.Core.MongoDB.MongoDBConnectionSetting _mongoDBConnectionSetting = new DemoProject.Core.MongoDB.MongoDBConnectionSetting
        {

        };

        public TestRepository() : base(new DemoProject.Core.MongoDB.MongoDBConnectionSetting
        {
            CollectionName = "test_collection",
            DBName = "test_db",
            Password = "247bZaWQOjpGwwhi",
            UserName = "haliltest"
        })
        {

        }
    }
}
