using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DotNetCore.MongoDB.API.Models
{
    [BsonIgnoreExtraElements]
    public class Teacher
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("address")]
        public Address Address { get; set; }
        [BsonElement("courses")]
        public string[]? Courses { get; set; }
        [BsonElement("gender")]
        public string Gender { get; set; } = string.Empty;
        [BsonElement("age")]
        public int Age { get; set; }
    }
}
