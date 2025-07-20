using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ConfigurationLib.Models
{
    public class ConfigItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("value")]
        public string Value { get; set; }

        [BsonElement("isActive")]
        public bool IsActive { get; set; }

        [BsonElement("applicationName")]
        public string ApplicationName { get; set; }
    }
}
