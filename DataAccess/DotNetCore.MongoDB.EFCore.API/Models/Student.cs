﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DotNetCore.MongoDB.EFCore.API.Models
{
    [BsonIgnoreExtraElements]
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("graduated")]
        public bool IsGraduated { get; set; }
        [BsonElement("courses")]
        public string[]? Courses { get; set; }
        [BsonElement("gender")]
        public string Gender { get; set; } = string.Empty;
        [BsonElement("age")]
        public int Age { get; set; }
    }
}
