using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigurationLib.Models;
using MongoDB.Driver;

namespace ConfigurationLib.Providers
{
    public class MongoConfigProvider : IConfigProvider
    {
        private readonly IMongoCollection<ConfigItem> _collection;

        public MongoConfigProvider(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            _collection = db.GetCollection<ConfigItem>("ConfigurationItems");
        }

        public List<ConfigItem> LoadAll(string applicationName)
        {
            return _collection
                .Find(x => x.ApplicationName == applicationName && x.IsActive)
                .ToList();
        }

        public void Add(ConfigItem item)
        {
            _collection.InsertOne(item);
        }

        public void Update(ConfigItem item)
        {
            var filter = Builders<ConfigItem>.Filter.Eq(x => x.Id, item.Id);
            _collection.ReplaceOne(filter, item);
        }

        public void Delete(string id)
        {
           var filter = Builders<ConfigItem>.Filter.Eq(x => x.Id, id);
            var result = _collection.DeleteOne(filter);

            if (result.DeletedCount == 0)
                throw new KeyNotFoundException($"MongoDB'de ID {id} ile kayıt bulunamadı.");
        }
    }
}
